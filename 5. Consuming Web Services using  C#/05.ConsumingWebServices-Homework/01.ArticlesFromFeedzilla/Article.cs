using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ArticlesFromFeedzilla
{
    public class Article
    {
        public string Publish_date { get; set; }
        public string Source { get; set; }
        public string Source_url { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
    }

    public class JSONResponse
    {
        public List<Article> Articles { get; set; }
    }
}
