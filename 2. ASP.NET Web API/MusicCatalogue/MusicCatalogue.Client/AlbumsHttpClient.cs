using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MusicCatalogue.Client
{
    public class AlbumsHttpClient : HttpClientEngine
    {
        public AlbumsHttpClient(string apiPath, MediaTypeEnum mediaType)
            : base(apiPath, mediaType)
        {
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            var result = base.client.GetAsync("/api/Albums")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Album>>()
                .Result;

            return result;
        }

        public Album GetAlbumById(int id)
        {
            var result = base.client.GetAsync("/api/Albums/" + id)
                .Result
                .Content
                .ReadAsAsync<Album>()
                .Result;

            return result;
        }

        public void UpdateAlbumRecord(int id, Album album)
        {
            album.AlbumId = id;
            if (base.mediaTypeEnum == MediaTypeEnum.Json)
            {
                var res = base.client.PutAsJsonAsync("/api/Albums/" + id, album).Result;
            }
            else
            {
                var res = base.client.PutAsXmlAsync("/api/Albums/" + id, album).Result;
            }
        }

        public void AddToAlbums(Album album)
        {
            if (base.mediaTypeEnum == MediaTypeEnum.Json)
            {
                var res = base.client.PostAsJsonAsync("/api/Albums", album).Result;
            }
            else
            {
                var res = base.client.PostAsXmlAsync("/api/Albums", album).Result;
            }
        }

        public void DeleteFromAlbum(int id)
        {
            var res = base.client.DeleteAsync("/api/Albums/" + id).Result;
        }
    }
}
