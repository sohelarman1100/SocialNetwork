using Autofac;
using Microsoft.AspNetCore.Hosting;
using SocialNetwork.Functionality.BusinessObjects;
using SocialNetwork.Functionality.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class DeletePhotoModel
    {
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DeletePhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
            _hostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
        }

        public DeletePhotoModel(IPhotoService photoService, IWebHostEnvironment hostEnvironment)
        {
            _photoService = photoService;
            _hostEnvironment = hostEnvironment;
        }
        internal void DeletePhoto(int id)
        {
            //start operation for deleting image from wwwroot/images
            var photoInfo = _photoService.GetPhotoForDelete(id);
            var imgPath = Path.Combine(_hostEnvironment.WebRootPath, "images", photoInfo.PhotoFileName);
            if (System.IO.File.Exists(imgPath))
                System.IO.File.Delete(imgPath);
            //finish operation for deleting image from wwwroot/images

            //deleting record from database
            _photoService.DeletePhoto(id);
        }
    }
}
