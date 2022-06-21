using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetCrawler_API.Models
{
    public class TweetData
    {
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public Attachments attachments { get; set; }
    }


}
