using System;
using System.IO;
using System.Diagnostics;

using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;
using System.Collections.Generic;
using System.Net;
using HtmlAgilityPack;

class DropboxExample
{
    // Register your own Dropbox app at https://www.dropbox.com/developers/apps
    // with "Full Dropbox" access level and set your app keys and app secret below
    private const string DropboxAppKey = "fozesr44kd2ljgd";
    private const string DropboxAppSecret = "wclfa9qx06q6qsh";

    private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

    static void Main()
    {
        string url = "http://db.tt/90tky6ui";

        // For speed of dev, I use a WebClient
        WebClient client = new WebClient();
        string html = client.DownloadString(url);

        int index = html.IndexOf("<img onload");
        int srcIndex = html.IndexOf("src=", index);
        string pseudoLink = html.Substring(srcIndex + 5);
        string link = pseudoLink.Substring(0, pseudoLink.IndexOf('"'));
        //HtmlDocument doc = new HtmlDocument();
        //doc.LoadHtml(html);

        //// Now, using LINQ to get all Images
        //List<HtmlNode> imageNodes = null;
        //imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
        //              where node.Name == "img"
        //              && node.Attributes["class"] != null
        //              && node.Attributes["class"].Value.StartsWith("img_")
        //              select node).ToList();

        //foreach (HtmlNode node in imageNodes)
        //{
        //    Console.WriteLine(node.Attributes["src"].Value);
        //}
    }
}