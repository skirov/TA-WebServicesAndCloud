using MusicCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MusicCatalogue.Client
{
    public class ArtistsHttpClient : HttpClientEngine
    {
        public ArtistsHttpClient(string apiPath, MediaTypeEnum mediaType)
            : base(apiPath, mediaType)
        {
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            var result = base.client.GetAsync("/api/Artists")
                .Result
                .Content
                .ReadAsAsync<IEnumerable<Artist>>()
                .Result;

            return result;
        }

        public Artist GetArtistById(int id)
        {
            var result = base.client.GetAsync("/api/Artists/" + id)
                .Result
                .Content
                .ReadAsAsync<Artist>()
                .Result;

            return result;
        }

        public void UpdateArtistRecord(int id, Artist artist)
        {
            artist.ArtistId = id;
            if (base.mediaTypeEnum == MediaTypeEnum.Json)
            {
                var res = base.client.PutAsJsonAsync("/api/Artists/" + id, artist).Result;
            }
            else
            {
                var res = base.client.PutAsXmlAsync("/api/Artists/" + id, artist).Result;
            }
        }

        public void AddToArtists(Artist artist)
        {
            if (base.mediaTypeEnum == MediaTypeEnum.Json)
            {
                var res = base.client.PostAsJsonAsync("/api/Artists", artist).Result;
            }
            else
            {
                var res = base.client.PostAsXmlAsync("/api/Artists", artist).Result;
            }
        }

        public void DeleteFromArtists(int id)
        {
            var res = base.client.DeleteAsync("/api/Artists/" + id).Result;
        }
    }
}
