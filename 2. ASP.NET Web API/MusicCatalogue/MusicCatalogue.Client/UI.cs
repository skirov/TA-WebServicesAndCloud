using System;

namespace MusicCatalogue.Client
{
    public static class UI
    {
        public static void ShowAlbumsContentJSON()
        {
            //With Json
            AlbumsHttpClient albumsClient = new AlbumsHttpClient("http://localhost:20098/", MediaTypeEnum.Json);

            foreach (var album in albumsClient.GetAllAlbums())
            {
                Console.WriteLine("Album Producer - {0}; Title - {1}; Year - {2}", album.Producer, album.Title, album.Year);

                foreach (var song in album.Songs)
                {
                    Console.WriteLine("    Song Title - {0}; Year - {1}; Genre - {2}", song.Title, song.Year, song.Genre);

                    foreach (var artist in song.Artists)
                    {
                        Console.WriteLine("    - Artist Name - {0}; Country - {1}; Date of birth - {2}", artist.Name, artist.Country, artist.DateOfBirth);
                    }
                    Console.WriteLine(new string('-', Console.BufferWidth / 2));
                }

                Console.WriteLine(new string('*', Console.BufferWidth));
            }
        }

        public static void ShowAlbumsContentByIdXML(int id)
        {
            //With Xml
            AlbumsHttpClient albumsClient = new AlbumsHttpClient("http://localhost:20098/", MediaTypeEnum.Xml);

            var album = albumsClient.GetAlbumById(id);
            Console.WriteLine("Album Producer - {0}; Title - {1}; Year - {2}", album.Producer, album.Title, album.Year);
            Console.WriteLine("Album Songs: ");

            foreach (var song in album.Songs)
            {
                Console.WriteLine("    Song Title - {0}; Year - {1}; Genre - {2}", song.Title, song.Year, song.Genre);

                foreach (var artist in song.Artists)
                {
                    Console.WriteLine("    - Artist Name - {0}; Country - {1}; Date of birth - {2}", artist.Name, artist.Country, artist.DateOfBirth);
                }
                Console.WriteLine(new string('*', Console.BufferWidth));
            }
        }

        public static void ShowSongsContentJSON()
        {
            //With Json
            SongsHttpClient songsClient = new SongsHttpClient("http://localhost:20098/", MediaTypeEnum.Json);

            foreach (var song in songsClient.GetAllSongs())
            {
                Console.WriteLine("    Song Title - {0}; Year - {1}; Genre - {2}", song.Title, song.Year, song.Genre);

                foreach (var artist in song.Artists)
                {
                    Console.WriteLine("    - Artist Name - {0}; Country - {1}; Date of birth - {2}", artist.Name, artist.Country, artist.DateOfBirth);
                }
                Console.WriteLine(new string('*', Console.BufferWidth));
            }
        }

        public static void ShowSongsContentByIdXML(int id)
        {
            //With Xml
            SongsHttpClient songsClient = new SongsHttpClient("http://localhost:20098/", MediaTypeEnum.Xml);

            var song = songsClient.GetSongsById(id);
            Console.WriteLine("    Song Title - {0}; Year - {1}; Genre - {2}", song.Title, song.Year, song.Genre);

            foreach (var artist in song.Artists)
            {
                Console.WriteLine("    - Artist Name - {0}; Country - {1}; Date of birth - {2}", artist.Name, artist.Country, artist.DateOfBirth);
            }
        }

        public static void ShowArtistsContentJSON()
        {
            //With Json
            ArtistsHttpClient artistsClient = new ArtistsHttpClient("http://localhost:20098/", MediaTypeEnum.Json);

            foreach (var artist in artistsClient.GetAllArtists())
            {
                Console.WriteLine("    - Artist Name - {0}; Country - {1}; Date of birth - {2}", artist.Name, artist.Country, artist.DateOfBirth);

                foreach (var song in artist.Songs)
                {
                    Console.WriteLine("    Song Title - {0}; Year - {1}; Genre - {2}", song.Title, song.Year, song.Genre);
                }

                Console.WriteLine(new string('*', Console.BufferWidth));
            }
        }

        public static void ShowArtistsContentByIdXML(int id)
        {
            //With Xml
            ArtistsHttpClient artistsClient = new ArtistsHttpClient("http://localhost:20098/", MediaTypeEnum.Xml);

            var artist = artistsClient.GetArtistById(id);
            Console.WriteLine("    - Artist Name - {0}; Country - {1}; Date of birth - {2}", artist.Name, artist.Country, artist.DateOfBirth);

            foreach (var song in artist.Songs)
            {
                Console.WriteLine("    Song Title - {0}; Year - {1}; Genre - {2}", song.Title, song.Year, song.Genre);
            }
        }


    }
}
