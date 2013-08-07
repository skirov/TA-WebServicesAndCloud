using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MusicCatalogue.Client
{
    public class SongsHttpClient : HttpClientEngine
    {
        public SongsHttpClient(string apiPath, MediaTypeEnum mediaType)
            : base(apiPath, mediaType)
        {
        }

        public IEnumerable<Song> GetAllSongs()
        {
            var result = base.client.GetAsync("/api/Songs")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Song>>()
                .Result;

            return result;
        }

        public Song GetSongsById(int id)
        {
            var result = base.client.GetAsync("/api/Songs/" + id)
                .Result
                .Content
                .ReadAsAsync<Song>()
                .Result;

            return result;
        }

        public void UpdateSongRecord(int id, Song song)
        {
            song.SongId = id;
            if (base.mediaTypeEnum == MediaTypeEnum.Json)
            {
                var res = base.client.PutAsJsonAsync("/api/Songs/" + id, song).Result;
            }
            else
            {
                var res = base.client.PutAsXmlAsync("/api/Songs/" + id, song).Result;
            }
        }

        public void AddToSongs(Song song)
        {
            if (base.mediaTypeEnum == MediaTypeEnum.Json)
            {
                var res = base.client.PostAsJsonAsync("/api/Songs", song).Result;
            }
            else
            {
                var res = base.client.PostAsXmlAsync("/api/Songs", song).Result;
            }
        }

        public void DeleteFromSongs(int id)
        {
            var res = base.client.DeleteAsync("/api/Songs/" + id).Result;
        }
    }
}
