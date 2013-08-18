using System;
using System.Net.Http;

namespace _01.ArticlesFromFeedzilla
{
    public static class UI
    {
        public static void LoadUI()
        {
            //Console.WriteLine("Parameters:");
            //Console.WriteLine("culture_code - Optional. Restricts the results to the given culture. Default is en_us.");
            //Console.WriteLine("q - Required . The text to search for in articles.");
            //Console.WriteLine("count - Optional. Specifies the number of articles to retrieve. May not be greater than 100. (Note the the number of articles returned may be smaller than the requested count). Default is 20.");
            //Console.WriteLine("since - Optional. Returns articles that was published since the given date. Date should be formatted as YYYY-MM-DD");
            //Console.WriteLine("order - Optional. The sort order of the list to be returned. Can be one of the following:");
            //Console.WriteLine("relevance - The list will be ordered by article relevancy (most relevant is first). This is the default value.");
            //Console.WriteLine("date - The list will be ordered by article publication date (most recent is first).");
            //Console.WriteLine("client_source - Optional. A string representing the client that uses this request.");
            //Console.WriteLine("title_only - Optional. A value (1 - true, 0 - false) indicating whether to fetch article title only (no summary or content). Default is 0.");

            //Console.WriteLine();

            Console.WriteLine("Please enter a query string. E.g. - q=Michael");
            Console.WriteLine();

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/");
        
            Console.WriteLine();

            Console.Write("Query string - ");
            string queryString = Console.ReadLine();
            FeedUtils.PrintStudents(httpClient, queryString);
        }
    }
}
