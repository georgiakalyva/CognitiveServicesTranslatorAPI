using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
namespace SentenceBreaker
{/// <summary>
 /// This sample is the code presented in this tutorial by CodeStories.gr
 /// Tutorial Link: 
 ///
 /// For more tutorials and news find me:
 /// Blog: http://www.codestories.gr
 /// Facebook: https://www.facebook.com/codestoriesgr/
 /// Twitter: https://twitter.com/GeorgiaKalyva
 /// LinkedIn: https://www.linkedin.com/in/georgiakalyva
 /// </summary>
    class Program
    {
        static void Break()
        {
            string host = "https://api.cognitive.microsofttranslator.com";
            string route = "/breaksentence?api-version=3.0&language=en";
            string subscriptionKey = "enter your subscription key";

            System.Object[] body = new System.Object[] { new { Text = @"How are you? I am fine. What did you do today?" } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(host + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                var response = client.SendAsync(request).Result;
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonResponse);
                Console.WriteLine("Press any key to continue.");
            }
        }
        static void Main(string[] args)
        {
            Break();
            Console.ReadLine();

        }
    }
}
