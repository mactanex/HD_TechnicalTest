using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetCrawler_API.DataAccess
{
    /// <summary>
    /// Fluent builder for easy design of queries to the twitter api
    /// </summary>
    public class QueryBuilder
    {
        private string query = "";

        private QueryBuilder(string baseUrl)
        {
            this.query = baseUrl + "?";
        }
        public static QueryBuilder Init(string baseUrl)
        {
            return new QueryBuilder(baseUrl);
        }


        public string Build() {
            this.query.Remove(this.query.LastIndexOf('&'));
            return this.query;
        }

        public QueryBuilder SearchTerm(string searchTerm, string twitterOperator)
        {
            this.query += "query=" + searchTerm + " " + twitterOperator + "&";
            return this;
        }

        public QueryBuilder TweetFields(string tweetFields)
        {
            this.query += "tweet.fields=" + tweetFields + "&";
            return this;
        }

        public QueryBuilder Expansions(string expansions)
        {
            this.query += "expansions=" + expansions + "&";
            return this;
        }

        public QueryBuilder MediaFields(string mediaFields)
        {
            this.query += "media.fields=" + mediaFields + "&";
            return this;
        }

        public QueryBuilder UserFields(string userFields)
        {
            this.query += "user.fields=" + userFields + "&";
            return this;
        }

        public QueryBuilder MaxResults(int maxResults)
        {
            this.query += "max_results=" + maxResults + "&";
            return this;
        }

        public QueryBuilder NextToken(string nextToken)
        {
            if (nextToken.Length > 1)
            {
                this.query += "next_token=" + nextToken + "&";
            }
            
            return this;
        }
    }
}
