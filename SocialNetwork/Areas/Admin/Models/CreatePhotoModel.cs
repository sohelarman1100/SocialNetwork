using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Functionality.BusinessObjects;
using SocialNetwork.Functionality.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class CreatePhotoModel
    {
        [Required , Range(1,500000)]
        public int MemberId { get; set; }

        public string PhotoFileName { get; set; }
        
        [NotMapped]
        public IFormFile PhotoFile { get; set; }


        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CreatePhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
            _hostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
        }
        public CreatePhotoModel(IPhotoService photoService, IWebHostEnvironment hostEnvironment)
        {
            _photoService = photoService;
            _hostEnvironment = hostEnvironment;
        }
       
        internal void CreatePhoto()
        {
            //saving image to wwwroot/images
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(PhotoFile.FileName);
            string extension = Path.GetExtension(PhotoFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            PhotoFileName = fileName;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path,FileMode.Create))
            {
                PhotoFile.CopyTo(fileStream);
            }

            //saving image path to database

            var photo = new PhotoBO
            {
                MemberId = MemberId,
                PhotoFileName = PhotoFileName
            };

            _photoService.CreatePhoto(photo);
        }
    }
}
