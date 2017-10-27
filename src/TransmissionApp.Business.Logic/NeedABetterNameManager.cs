using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using TransmissionApp.Business.Logic.Configuration;
using TransmissionApp.Business.Logic.Configuration.Models;
using TransmissionApp.Business.Logic.Rss;
using TransmissionApp.Business.Contracts;
using TransmissionApp.Business.Logic.Processing;
using System.Linq;

namespace TransmissionApp.Business.Logic
{
    public class NeedABetterNameManager
    {
        ConfigurationManager configurationManager = null;

        public NeedABetterNameManager(IOptions<AppConfiguration> appConfigurationAccessor)
        {
            configurationManager = new ConfigurationManager(appConfigurationAccessor.Value);
        }

        public void Execute()
        {
            var items = GetItemsToBeManaged();
            AddItemsToTorrent(items.Where(x=>x.State==Contracts.Enums.ItemsState.ToAdd));
            RemoveItemsFromTorrent(items.Where(x => x.State == Contracts.Enums.ItemsState.ToRemove));
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
            foreach (var job in configurationManager.ClientConfiguration.Jobs)
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
                    State = Contracts.Enums.ItemsState.ToAdd
                })
                .ToList();
            var toRemove = inTorrent.Where(x => !inRss.Any(t => t.Title == x.Title))
                .Select(x => new ManagedItem()
                {
                    Title = x.Title,
                    Description = "",
                    Path = x.Path,
                    Link = "",
                    State = Contracts.Enums.ItemsState.ToRemove
                })
                .ToList();

            List<ManagedItem> items = new List<ManagedItem>();
            items.AddRange(toAdd);
            items.AddRange(toRemove);
            return items;
        }
    }
}
