using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetCrawler_API.Models
{
    public class TweetDTO
    {
        public string id { get; set; }
        public User author { get; set; }
        public DateTime createdAt { get; set; }

        public List<Medium> media { get; set; }

        public string tweetContent { get; set; }
    }
}
