using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TransmissionApp.Business.Logic.Rss.Models;

namespace TransmissionApp.Business.Logic.Rss
{
    public static class RssReader
    {
        public static IEnumerable<RssItem> GetRssObject(string url)
        {
            try
            {
                return XDocument.Load(url).Descendants("item").Select(x => new RssItem(x));
            }
            catch (System.Net.WebException)
            {
                return new List<RssItem>();
            }
        }
    }
}