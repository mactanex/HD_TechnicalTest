using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TweetCrawler_API.Models;

namespace TweetCrawler_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly IRepository<TweetContainer> tweetRepository;

        public TweetController(IRepository<TweetContainer> tweetRepository)
        {
            this.tweetRepository = tweetRepository;
        }

        [HttpGet]
        public IActionResult Search([FromQuery] string searchTerm, string nextToken = "")
        {
            try
            {
                return Ok(tweetRepository.Get(searchTerm, nextToken).ConvertToResponse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpGet]
        public IActionResult SearchWithImage([FromQuery] string searchTerm, string nextToken = "")
        {
            try
            {
                return Ok(tweetRepository.GetWithImages(searchTerm, nextToken).ConvertToResponse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
