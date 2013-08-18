using System;
using System.IO;
using System.Diagnostics;

using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;
using System.Collections.Generic;
using System.Net;

public class DropboxDataPersister
{
    // Register your own Dropbox app at https://www.dropbox.com/developers/apps
    // with "Full Dropbox" access level and set your app keys and app secret below
    private const string DropboxAppKey = "fozesr44kd2ljgd";
    private const string DropboxAppSecret = "wclfa9qx06q6qsh";

    private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

    private Stream imageStream;
    private string fileName;

    public DropboxDataPersister(Stream imageStream, string fileName)
    {
        this.imageStream = imageStream;
        this.fileName = fileName;
    }

    private static void CopyStream(Stream input, Stream output)
    {
        input.CopyTo(output);
    }

    public static void DeleteDirectory(string target_dir)
    {
        string[] files = Directory.GetFiles(target_dir);
        string[] dirs = Directory.GetDirectories(target_dir);

        foreach (string file in files)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (string dir in dirs)
        {
            DeleteDirectory(dir);
        }

        Directory.Delete(target_dir, false);
    }

    public string UploadFile()
    {
        DropboxServiceProvider dropboxServiceProvider =
            new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

        // Authenticate the application (if not authenticated) and load the OAuth token
        //if (!File.Exists(OAuthTokenFileName))
        //{
        //    AuthorizeAppOAuth(dropboxServiceProvider);
        //}
        OAuthToken oauthAccessToken = new OAuthToken("fvjpvp0isfjsgyd7", "2u9zc9h1r0say01");

        // Login in Dropbox
        IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

        // Display user name (from his profile)
        DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
        Console.WriteLine("Hi " + profile.DisplayName + "!");

        // Create new folder
        string newFolderName = "RecipeImages";

        Directory.CreateDirectory("../../DropboxLisa");
        using (FileStream output = File.OpenWrite("../../DropboxLisa/" + DateTime.Now.Ticks + this.fileName ))
        {
            CopyStream(imageStream, output);
        }

        // Upload a file
        string[] files = Directory.GetFiles("../../DropboxLisa");
        List<Entry> uploadedFiles = new List<Entry>();
        foreach (var file in files)
        {
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new FileResource(Path.GetFullPath(file)),
                "/" + newFolderName + "/" + Path.GetFileName(file)).Result;
            uploadedFiles.Add(uploadFileEntry);
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);
        }

        //Delete the file
        DeleteDirectory("\\DropboxLisa");


        string fileUrl = string.Empty;

        foreach (var file in uploadedFiles)
        {
            DropboxLink fileShareUrl = dropbox.GetMediaLinkAsync(file.Path).Result; // files    
            fileUrl = fileShareUrl.Url;
        }

        return fileUrl;
    }

    private static OAuthToken LoadOAuthToken()
    {
        string[] lines = File.ReadAllLines(OAuthTokenFileName);
        OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
        return oauthAccessToken;
    }

    private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
    {
        // Authorization without callback url
        OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;

        OAuth1Parameters parameters = new OAuth1Parameters();
        string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
            oauthToken.Value, parameters);
        Process.Start(authenticateUrl);

        AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
        OAuthToken oauthAccessToken =
            dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;

        string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
        File.WriteAllLines(OAuthTokenFileName, oauthData);
    }
}