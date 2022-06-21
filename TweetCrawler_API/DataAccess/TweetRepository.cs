using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TweetCrawler_API.DataAccess;
using TweetCrawler_API.Models;

namespace TweetCrawler_API
{
    public class TweetRepository : IRepository<TweetContainer>
    {
        IConfiguration configuration;

        public TweetRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TweetContainer Get(string searchTerm, string nextToken)
        {
            TweetContainer tweetList = new TweetContainer(); 
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.GetValue<string>("Twitter_bearer_token"));

                string twitterQuery = QueryBuilder.Init("https://api.twitter.com/2/tweets/search/recent")
                                                  .SearchTerm(searchTerm, "")
                                                  .TweetFields("attachments,created_at")
                                                  .Expansions("author_id,attachments.media_keys")
                                                  .MediaFields("duration_ms,url")
                                                  .UserFields("description,profile_image_url")
                                                  .NextToken(nextToken)
                                                  .Build();

                using (var response = httpClient.GetAsync(twitterQuery).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    tweetList = JsonConvert.DeserializeObject<TweetContainer>(apiResponse);
                }
            }
           return tweetList;
        }

        public TweetContainer GetWithImages(string searchTerm, string nextToken)
        {
            TweetContainer tweetList = new TweetContainer();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.GetValue<string>("Twitter_bearer_token"));

                string twitterQuery = QueryBuilder.Init("https://api.twitter.com/2/tweets/search/recent")
                                                  .SearchTerm(searchTerm, "has:images")
                                                  .TweetFields("attachments,created_at")
                                                  .Expansions("author_id,attachments.media_keys")
                                                  .MediaFields("duration_ms,url")
                                                  .UserFields("description,profile_image_url")
                                                  .NextToken(nextToken)
                                                  .Build();

                using (var response = httpClient.GetAsync(twitterQuery).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    tweetList = JsonConvert.DeserializeObject<TweetContainer>(apiResponse);
                }
            }
            return tweetList;
        }
    }
}
