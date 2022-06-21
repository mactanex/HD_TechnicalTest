using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetCrawler_API.Models
{
    public class TweetContainer
    {
        public TweetData[] data { get; set; }
        public Includes includes { get; set; }
        public Meta meta { get; set; }

        public TweetResponseDTO ConvertToResponse()
        {
            TweetResponseDTO tweetResponse = new TweetResponseDTO();
            tweetResponse.next_token = meta.next_token;
            tweetResponse.result_count = meta.result_count;
            tweetResponse.tweets = new List<TweetDTO>();
            foreach (var tweetData in data)
            {
                TweetDTO tweet = new TweetDTO();
                tweet.id = tweetData.id;
                tweet.author = includes.users.Where(x => x.id == tweetData.author_id).SingleOrDefault();
                tweet.createdAt = tweetData.created_at;
                tweet.media = new List<Medium>();
                if (tweetData.attachments!=null)
                {
                    foreach (var mediaKey in tweetData.attachments.media_keys)
                    {
                        Medium media = includes.media.Where(x => x.media_key == mediaKey).SingleOrDefault();

                        tweet.media.Add(media);
                    }
                }
                

                tweet.tweetContent = tweetData.text;
                tweetResponse.tweets.Add(tweet);
            }

            return tweetResponse;
        }
    }
}

