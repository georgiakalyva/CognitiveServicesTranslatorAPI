﻿using System;
using System.Net.Http;

namespace GetSupportedLanguages
{ /// For more tutorials and news find me:
  /// Blog: http://www.codestories.gr
  /// Facebook: https://www.facebook.com/codestoriesgr/
  /// Twitter: https://twitter.com/GeorgiaKalyva
  /// LinkedIn: https://www.linkedin.com/in/georgiakalyva
  /// </summary>
    class Program
    {
        static void Languages()
        {
            string host = "https://api.cognitive.microsofttranslator.com";
            string route = "/languages?api-version=3.0";
            string subscriptionKey = "enter your subscription key";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(host + route);
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                var response = client.SendAsync(request).Result;
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonResponse);
                Console.WriteLine("Press any key to continue.");
            }
        }
        static void Main(string[] args)
        {
            Languages();
            Console.ReadLine();
        }
    }
}
