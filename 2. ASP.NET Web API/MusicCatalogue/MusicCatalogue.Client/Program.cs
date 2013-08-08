using MusicCatalogue.Models;
using System;

namespace MusicCatalogue.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Add records
            //using (MusicCatalogueContext context = new MusicCatalogueContext())
            //{
            //    //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicCatalogueContext, Configuration>());


            //    Song newSong = new Song();
            //    newSong.Title = "Bing Bang";
            //    newSong.Genre = "Shit";
            //    newSong.Year = 2013;

            //    Artist newArtist = new Artist();
            //    newArtist.Country = "Kazahstan";
            //    newArtist.DateOfBirth = DateTime.Now;
            //    newArtist.Name = "Korky Buchek";

            //    Album newAlbum = new Album();
            //    newAlbum.Producer = "Pesho Mainata";
            //    newAlbum.Title = "Turbo Kazak";
            //    newAlbum.Year = 1972;

            //    newSong.Artists.Add(newArtist);

            //    newAlbum.Songs.Add(newSong);

            //    newArtist.Albums.Add(newAlbum);

            //    context.Albums.Add(newAlbum);
            //    context.Artists.Add(newArtist);
            //    context.Songs.Add(newSong);

            //    context.SaveChanges();
            //}
            #endregion

            #region GET demos
            //UI.ShowAlbumsContentJSON();
            //UI.ShowAlbumsContentByIdXML(1);

            //UI.ShowSongsContentJSON();
            //UI.ShowSongsContentByIdXML(1);

            //UI.ShowArtistsContentJSON();
            //UI.ShowArtistsContentByIdXML(1);
            #endregion

            #region PUT, POST, DELETE Demost For Albums
            //AlbumsHttpClient albumsClient = new AlbumsHttpClient("http://localhost:20098/", MediaTypeEnum.Xml);

            //Album newAlbum = new Album();
            //newAlbum.Title = "Turbo hita na uetoto";
            //newAlbum.Year = 2013;
            //newAlbum.Producer = "PK0007KC";

            //albumsClient.UpdateAlbumRecord(1, newAlbum);
            //albumsClient.AddToAlbums(newAlbum);
            //albumsClient.DeleteFromAlbum(19);
            #endregion

            #region PUT, POST, DELETE Demost For Artists
            //ArtistsHttpClient artistsClient = new ArtistsHttpClient("http://localhost:20098/", MediaTypeEnum.Xml);

            //Artist newArtist = new Artist();
            //newArtist.Country = "Laplandia";
            //newArtist.DateOfBirth = DateTime.Now;
            //newArtist.Name = "Boho Boho";

            //artistsClient.AddToArtists(newArtist);
            //artistsClient.DeleteFromArtists(12);
            #endregion

            #region PUT, POST, DELETE Demost For Songs
            //SongsHttpClient songsClient = new SongsHttpClient("http://localhost:20098/", MediaTypeEnum.Xml);

            //Song newSong = new Song();
            //newSong.Title = "Zlata pesen maina";
            //newSong.Year = 2000;
            //newSong.Genre = "Zyl genre";

            //songsClient.UpdateSongRecord(1, newSong);
            //songsClient.AddToSongs(newSong);
            //songsClient.DeleteFromSongs(1);
            #endregion

        }
    }
}