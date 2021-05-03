using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using NSwag.Annotations;
using System.Net;

namespace FetchGiphyApp.Controllers
{
    [Route("GifSearcher")]
    public class GifController : Controller
    {
        private readonly ILogger<GifController> _logger;
        private readonly IGifService _gifService;
        public GifController(ILogger<GifController> logger, IGifService gifService)
        {
            _logger = logger;
            _gifService = gifService;
        }

        [HttpGet("/Trending")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(GifResponse), Description = "The Gif Response inclueds images data")]

        public ActionResult GetTrending(int limit)
        {
            //var trendingConfig = GetTrendingConfig();
            return Ok(_gifService.GetTrending(limit));
        }

        [HttpGet("/Search/{queryTerm}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(GifResponse), Description = "The Gif Response inclueds images data")]

        public ActionResult Search(string queryTerm,int? limit)
        {
            //var trendingConfig = GetTrendingConfig();
            return Ok(_gifService.Search(queryTerm,limit));
        }

        //private ITrendingConfiguration GetTrendingConfig()
        //{
        //    throw new NotImplementedException();
        //}








    }
}
