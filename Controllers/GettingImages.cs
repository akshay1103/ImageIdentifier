using Microsoft.AspNetCore.Mvc;
using ImageIdentifier.Service;
using System.Reflection.Metadata.Ecma335;
namespace ImageIdentifier.Controllers
{
    [Route("api/[controlle]")]
    [ApiController]
    public class GettingImagesController : Controller
    {
        private readonly FtpService _ftpService;
        public GettingImagesController(FtpService ftpService)
        {
            _ftpService = ftpService;
        }

        [HttpGet]
        public ActionResult GetImages()
        {
            var images = _ftpService.GetImages();
            return Ok(images);
        }
    }
}
