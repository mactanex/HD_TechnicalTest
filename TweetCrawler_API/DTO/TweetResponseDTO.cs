using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetCrawler_API.Models
{
    public class TweetResponseDTO
    {
        public int result_count { get; set; }
        public string next_token { get; set; }

        public List<TweetDTO> tweets { get; set; }
    }
}
