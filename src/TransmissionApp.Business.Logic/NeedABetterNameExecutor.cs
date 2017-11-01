using System;
using System.Collections.Generic;
using TransmissionApp.Business.Logic.Rss;
using TransmissionApp.Business.Logic.Processing;
using System.Linq;
using TransmissionApp.Business.Logic.Models;
using TransmissionApp.Business.Logic.Configuration.Models;
using TransmissionApp.TorrentClients.Models;
using TransmissionApp.TorrentClients.TransmissionClient;
using System.Diagnostics;

namespace TransmissionApp.Business.Logic
{
    public class NeedABetterNameExecutor
    {
        NeedABetterNameConfigurator configurator;
        RpcClient client;

        public NeedABetterNameExecutor(NeedABetterNameConfigurator configurator)
        {
            this.configurator = configurator;
            var clientConfig = configurator.GetClientConfiguration();
            client = new RpcClient(clientConfig.TransmissionUrl, clientConfig.Login, clientConfig.Password);          
        }

        public IEnumerable<ManagedItem> Execute()
        {
            var items = GetItemsToBeManaged();
            AddItemsToTorrent(items.Where(x=>x.State==ItemsState.ToAdd));
            RemoveItemsFromTorrent(items.Where(x => x.State == ItemsState.ToRemove));
            return items;
        }

        private void AddItemsToTorrent(IEnumerable<ManagedItem> items)
        {            
            foreach (var item in items)
            {
                Debugger.Log(1, "Torrent", $"Item Add: {item.Path}");
                NewTorrent torrent = new NewTorrent()
                {
                    Filename = item.Link,
                    DownloadDirectory = item.Path
                };
                client.TorrentAddAsync(torrent);
            }
        }

        private void RemoveItemsFromTorrent(IEnumerable<ManagedItem> items)
        {
            foreach (var item in items)
            {
                Debugger.Log(1, "Torrent", $"Item remove: {item.Path}");
                NewTorrent torrent = new NewTorrent()
                {
                    Filename = item.Link,
                    DownloadDirectory = item.Path
                };
               // client.TorrentAddAsync(torrent);
            }
        }

        public IEnumerable<TorrentInfo> GetRunningTorrents()
        {
            var torrents = client.TorrentGetAsync().GetAwaiter().GetResult();
            return torrents.Torrents;           
        }

        public IEnumerable<ResolvedRssItem> GetItemsFromRssCollection()
        {
            List<ResolvedRssItem> items = new List<ResolvedRssItem>();
            var clientConfiguration = configurator.GetClientConfiguration();
            foreach (var job in clientConfiguration.Jobs)
            {                
                items.AddRange(GetItemFromRss(job));
            }
            return items;
        }

        public IEnumerable<ResolvedRssItem> GetItemFromRss(JobConfiguration job)
        {
            var rssItems = RssReader.GetRssObject(job.RssUrl);
            return RssItemResolver.ResolveRssItems(job, rssItems);
        }

        public IEnumerable<ManagedItem> GetItemsToBeManaged()
        {
            var inRss = GetItemsFromRssCollection();
            var inTorrent = GetRunningTorrents();

            var toAdd = inRss.Where(x => !inTorrent.Any(t => t.Name == x.Title))
                .Select(x => new ManagedItem()
                {
                    TorrentId = 0,
                    Title = x.Title,
                    Description = x.Description,
                    Path = x.DownloadPath,
                    Link = x.Link,
                    State = ItemsState.ToAdd
                })
                .ToList();

            var toRemove = inTorrent.Where(x => !inRss.Any(t => t.Title == x.Name))
                .Select(x => new ManagedItem()
                {
                    TorrentId = x.ID,
                    Title = x.Name,
                    Description = "",
                    Path = x.DownloadDir,
                    Link = "",
                    State = ItemsState.ToRemove
                })
                .ToList();

            List<ManagedItem> items = new List<ManagedItem>();
            items.AddRange(toAdd);
            items.AddRange(toRemove);
            return items;
        }
    }
}
