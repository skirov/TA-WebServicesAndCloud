namespace _01.ArticlesFromFeedzilla
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;

    public static class FeedUtils
    {
        public static async void PrintStudents(HttpClient httpClient, string queryString)
        {
            Console.WriteLine("Waiting for information");
            var responseJSONArticles = await httpClient.GetAsync("search.json?" + queryString);

            JSONResponse personDeserialized = JsonConvert.DeserializeObject<JSONResponse>(await responseJSONArticles.Content.ReadAsStringAsync());

            foreach (var article in personDeserialized.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
                Console.WriteLine();
                Console.WriteLine(new string('-', Console.BufferWidth));
            }
        }
    }
}
