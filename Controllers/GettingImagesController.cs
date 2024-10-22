using Microsoft.AspNetCore.Mvc;
using ImageIdentifier.Service;
using System.Reflection.Metadata.Ecma335;
namespace ImageIdentifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GettingImagesController : Controller
    {
        private readonly FtpService _ftpService;
        public GettingImagesController(FtpService ftpService)
        {
            _ftpService = ftpService;
        }

        [HttpGet]
        public ActionResult GetImages() //created an end point that will fetch images
        {
            var images = _ftpService.GetImages();// calling GetImages() service 
            return Ok(images);//returning images
        }
    }
}
