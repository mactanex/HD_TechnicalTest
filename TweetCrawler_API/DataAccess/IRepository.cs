using System.Collections.Generic;
using TweetCrawler_API.Models;

namespace TweetCrawler_API
{
    public interface IRepository<T>
    {
        T Get(string searchTerm, string nextToken);
        T GetWithImages(string searchTerm, string nextToken);
    }
}