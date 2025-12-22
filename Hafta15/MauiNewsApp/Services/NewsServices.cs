using MauiNewsApp.Model;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MauiNewsApp.Services
{
    public class NewsServices
    {

        public static async Task<string> GetRSSDataAsJSON(string url)
        {
            HttpClient client = new HttpClient();
            var message= await client.GetAsync(url);
            
            message.EnsureSuccessStatusCode();

            var xmlData = await message.Content.ReadAsStringAsync();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlData);
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlDocument);

            return jsonData;
        }


        public static async Task< List<Item>> GetCategoryNews(NewsCategory category)
        {
            var jsonData = await GetRSSDataAsJSON(category.Url);

            Root myDeserializedClass =  JsonConvert.DeserializeObject<Root>(jsonData);

            return myDeserializedClass.rss.channel.item;
        }
    }
}
