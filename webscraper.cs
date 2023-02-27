// download htmlagilitypack in the nugetpackage manager

using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace Webscraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // using weather.com as the example, with current location of montgomery, AL

            //send get request to weather.com
            String url = "https://weather.com/weather/today/l/229d98c080fe2c298000be41854858e60aba6bd0a867b53a8666de41ff918fbe";
            var httpClient = new HttpClient();

            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);


            // get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='TodayDetailsCard--feelsLikeTempValue--2icPt']");
            var tempurature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + tempurature);

            // get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var conditions = conditionElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            //get location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location: " + location);
        }
    }

}
