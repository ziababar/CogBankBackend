﻿using System;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;


namespace CogBankTextAnalytics
{
    static class Program
    {

        static void Main(string[] args)
        {
            var reader = new StreamReader(@"C:\test.csv");

            // For this demo, the following is the Azure Text Analytics API information
            // Endpoint: https://eastus2.api.cognitive.microsoft.com/text/analytics/v2.0
            // Name: CogBankTextAnalytics
            // Key1: 7ab8815bff994de0a37aad20d4704b3e
            // Key2: 95a18817fe9343729fb10c9b3f3f418a


            using ()
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Eastus2;
            client.SubscriptionKey = "7ab8815bff994de0a37aad20d4704b3e";

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Extracting sentiment
            Console.WriteLine("\n\n===== SENTIMENT ANALYSIS ======");

            SentimentBatchResult result3 = client.Sentiment(
                    new MultiLanguageBatchInput(

                        new List<MultiLanguageInput>()
                        {
                          new MultiLanguageInput("en", "0", "I had the best day of my life."),
                          new MultiLanguageInput("en", "1", "This was a waste of my time. The speaker put me to sleep."),
                        }));


            // Printing sentiment results
            foreach (var document in result3.Documents)
            {
                Console.WriteLine("Document ID: {0} , Sentiment Score: {1:0.00}", document.Id, document.Score);
                Console.WriteLine("Document Description: " + client.Sentiment.);
            }

            // Wait for the user
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();

        }

        //static async void MakeRequest()
        //{
        //    var client = new HttpClient();
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    // Request headers
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

        //    var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment?" + queryString;

        //    HttpResponseMessage response;

        //    // Request body
        //    byte[] byteData = Encoding.UTF8.GetBytes("{body}");

        //    using (var content = new ByteArrayContent(byteData))
        //    {
        //        content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >");
        //        response = await client.PostAsync(uri, content);
        //    }

        //}
    }
}
