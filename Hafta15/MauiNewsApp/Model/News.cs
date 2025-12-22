using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace MauiNewsApp.Model
{
    public class NewsCategory
    {
        public string Category { get; set; }
        public string Url { get; set; }

        public NewsCategory(string category, string url)
        {
            Category = category;
            Url = url;
        }
    }


    public class Channel
    {
        public string lastBuildDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string language { get; set; }
        public List<Item> item { get; set; }
    }

    public class ContentEncoded
    {
        [JsonProperty("#cdata-section")]
        public string cdatasection { get; set; }
    }

    public class Description
    {
        [JsonProperty("#cdata-section")]
        public string cdatasection { get; set; }
    }

    public class Enclosure
    {
        [JsonProperty("@url")]
        public string url { get; set; }

        [JsonProperty("@length")]
        public string length { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
    }

    public class Item
    {
        public string guid { get; set; }
        public string pubDate { get; set; }
        public string title { get; set; }
        public Description description { get; set; }

        [JsonProperty("media:content")]
        public MediaContent mediacontent { get; set; }
        public Enclosure enclosure { get; set; }
        public string link { get; set; }
        public string author { get; set; }

        [JsonProperty("content:encoded")]
        public ContentEncoded contentencoded { get; set; }
    }

    public class MediaContent
    {
        [JsonProperty("@url")]
        public string url { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }

        [JsonProperty("@expression")]
        public string expression { get; set; }

        [JsonProperty("@width")]
        public string width { get; set; }

        [JsonProperty("@height")]
        public string height { get; set; }
    }

    public class Root
    {
        [JsonProperty("?xml")]
        public Xml xml { get; set; }
        public Rss rss { get; set; }
    }

    public class Rss
    {
        [JsonProperty("@version")]
        public string version { get; set; }

        [JsonProperty("@xmlns:content")]
        public string xmlnscontent { get; set; }

        [JsonProperty("@xmlns:media")]
        public string xmlnsmedia { get; set; }
        public Channel channel { get; set; }
    }

    public class Xml
    {
        [JsonProperty("@version")]
        public string version { get; set; }

        [JsonProperty("@encoding")]
        public string encoding { get; set; }
    }


}
