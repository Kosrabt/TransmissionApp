using System;
using System.Collections.Generic;
using TransmissionApp.Business.Logic.Rss;
using TransmissionApp.Business.Logic.Processing;
using System.Linq;
using TransmissionApp.Business.Logic.Models;

namespace TransmissionApp.Business.Logic
{
    public class NeedABetterNameExecutor
    {
        NeedABetterNameConfigurator configurator;

        public NeedABetterNameExecutor(NeedABetterNameConfigurator configurator)
        {
            this.configurator = configurator;
        }

        public void Execute()
        {
            var items = GetItemsToBeManaged();
            AddItemsToTorrent(items.Where(x=>x.State==ItemsState.ToAdd));
            RemoveItemsFromTorrent(items.Where(x => x.State == ItemsState.ToRemove));
        }

        private void AddItemsToTorrent(IEnumerable<ManagedItem> items)
        {
            throw new NotImplementedException();
        }

        private void RemoveItemsFromTorrent(IEnumerable<ManagedItem> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResolvedRssItem> GetItemsFromRss()
        {
            List<ResolvedRssItem> items = new List<ResolvedRssItem>();
            var clientConfiguration = configurator.GetClientConfiguration();
            foreach (var job in clientConfiguration.Jobs)
            {
                var rssItems = RssReader.GetRssObject(job.RssUrl);
                items.AddRange(RssItemResolver.ResolveRssItems(job, rssItems));
            }
            return items;
        }

        public IEnumerable<TorrentItem> GetRunningTorrents()
        {
            return new List<TorrentItem>();
        }

        public IEnumerable<ManagedItem> GetItemsToBeManaged()
        {
            var inRss = GetItemsFromRss();
            var inTorrent = GetRunningTorrents();

            var toAdd = inRss.Where(x => !inTorrent.Any(t => t.Title == x.Title))
                .Select(x => new ManagedItem()
                {
                    Title = x.Title,
                    Description = x.Description,
                    Path = x.DownloadPath,
                    Link = x.Link,
                    State = ItemsState.ToAdd
                })
                .ToList();
            var toRemove = inTorrent.Where(x => !inRss.Any(t => t.Title == x.Title))
                .Select(x => new ManagedItem()
                {
                    Title = x.Title,
                    Description = "",
                    Path = x.Path,
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
