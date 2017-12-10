using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.Net;
using Fizzler.Systems.HtmlAgilityPack;

namespace eBayParser.Classes
{
    public static class EBayItemParser
    {
        public static List<EBayItem> Parse(string url)
        {
            List<EBayItem> eBayItems = new List<EBayItem>();

            WebClient client = new WebClient();
            string content = client.DownloadString(url);
            var pageDoc = new HtmlDocument();
            pageDoc.LoadHtml(content);

            //for each item on web page
            foreach (var item in pageDoc.DocumentNode.QuerySelectorAll("#ListViewInner > li"))
            {
                EBayItem eBayItem = new EBayItem();
                eBayItem.title = ParseTitle(item);
                eBayItem.link = ParseLink(item);
                eBayItem.price = ParsePrice(item);
                eBayItem.quantity = ParseQuantity(eBayItem.link);

                eBayItems.Add(eBayItem);
            }

            return eBayItems;
        }


        private static string ParseTitle(HtmlNode doc)
        {
            var title = doc.QuerySelectorAll("h3.lvtitle > a");
            return title == null || title.Count() == 0 ? "" : title.First().InnerText;
        }

        private static string ParseLink(HtmlNode doc)
        {
            var link = doc.QuerySelectorAll(".lvtitle a");
            return link == null || link.Count() == 0 ? "" : link.First().GetAttributeValue("href", "").Trim();
        }

        private static string ParsePrice(HtmlNode doc)
        {
            var price = doc.QuerySelectorAll(".lvprice > span");
            return price== null || price.Count() == 0 ? "" : price.First().InnerText.Trim();
        }

        private static string ParseQuantity(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var qt = doc.DocumentNode.QuerySelectorAll("#qtySubTxt");
            return qt == null || qt.Count() == 0 ? "" : qt.First().InnerText.Trim();
        }
    }
}