using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Google.Apis;
using Google.Apis.Services;
using System.Text.Json;
using Google.Apis.YouTube.v3.Data;
using Google.Apis.Auth.OAuth2;
using System.Dynamic;

namespace youtube_player
{
    public class YoutubeInterface
    {
        private string key = "AIzaSyBA6P8o_Arpabu2yitY1RmKgUH_ZiUygpM";

        private YouTubeService CreateConnection()
        {
            return new YouTubeService(new BaseClientService.Initializer 
            { 
                ApiKey= key,
                ApplicationName = "Youtube Player"
            });
        }

        public async Task<SearchListResponse> GetVideoReference(string name)
        {
            
            var yt = CreateConnection();
            var request = yt.Search.List("snippet");
            request.Q = name;
            request.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            request.MaxResults = 10;
            return await request.ExecuteAsync();
        }

        public string ConvertToUrl(SearchResult result)
        {
            return "https://www.youtube.com/watch?v=" + result.Id.VideoId;
        }

        public bool ValidateResponse(SearchListResponse response)
        {
            return response.Items.Count != 0;
        }
    }
}