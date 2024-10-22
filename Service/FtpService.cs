using FluentFTP;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace ImageIdentifier.Service
{
    public class FtpService
    {
        private readonly string _ftpHost;
        private readonly string _ftpUser;
        private readonly string _ftpPass;
        private readonly string _imageDirectroy;
        public FtpService(IConfiguration configuration)  //here i have configuration the static data with appSetting.json
        {
            _ftpHost = configuration["FtpSettings:Host"];
            _ftpUser = configuration["FtpSettings:User"];
            _ftpPass = configuration["FtpSettings:Password"];
            _imageDirectroy = configuration["FtpSettings:ImageDirectory"];

        }
        public List<string> GetImages() //here used generic collection to dynamically add those images
        {       
            var images = new List<string>();
            using (var client = new FtpClient(_ftpHost, _ftpUser, _ftpPass))//passing values to ctor
            {
                client.Connect();//connects to FTP server
                foreach(var item in client.GetListing(_imageDirectroy))
                {
                    if (item.Type == FtpObjectType.File) //here we can iterate this loop over the directory also 
                    {
                        images.Add($"{_ftpHost}{_imageDirectroy}{item.Name}");//created path to Images
                    }
                }
            }
            return images; //this service retruns  the images to the controller that are calling the service
        }
    }
}
