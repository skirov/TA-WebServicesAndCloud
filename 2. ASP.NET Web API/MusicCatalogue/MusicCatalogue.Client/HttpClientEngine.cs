using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MusicCatalogue.Client
{
    public abstract class HttpClientEngine
    {
        protected HttpClient client;
        protected MediaTypeEnum mediaTypeEnum;
        protected string mediaType;
        protected string apiPath;

        public HttpClientEngine(string apiPath, MediaTypeEnum mediaType)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiPath);

            if (mediaType == MediaTypeEnum.Json)
            {
                this.mediaType = "application/json";
            }
            else
            {
                this.mediaType = "application/xml";
            }

            this.apiPath = apiPath;
            this.mediaTypeEnum = mediaType;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));
        }
    }
}
