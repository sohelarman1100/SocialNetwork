using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SocialNetwork.Functionality.BusinessObjects;
using SocialNetwork.Functionality.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class EditPhotoModel
    {
        [Required, Range(1, 500000)]
        public int? Id { get; set; }

        [Required, Range(1, 500000)]
        public int? MemberId { get; set; }
        public string PhotoFileName { get; set; }
        public IFormFile PhotoFile { get; set; }

        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
            _hostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
        }

        public EditPhotoModel(IPhotoService photoService, IWebHostEnvironment hostEnvironment)
        {
            _photoService = photoService;
            _hostEnvironment = hostEnvironment;
        }

        internal void LoadPhotoDataForEdit(int id)
        {
            var data = _photoService.GetPhotoForEdit(id);
            Id = data?.Id;
            MemberId = data?.MemberId;
            PhotoFileName = data?.PhotoFileName;
        }

        internal void Update()
        {
            //start operation for deleting image from wwwroot/images
            var photoInfo = _photoService.GetPhotoForDelete(Id.Value);
            var imgPath = Path.Combine(_hostEnvironment.WebRootPath, "images", photoInfo.PhotoFileName);
            if (System.IO.File.Exists(imgPath))
                System.IO.File.Delete(imgPath);
            //finish operation for deleting image from wwwroot/images

            //saving image to wwwroot/images
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(PhotoFile.FileName);
            string extension = Path.GetExtension(PhotoFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            PhotoFileName = fileName;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                PhotoFile.CopyTo(fileStream);
            }
            //saving image to wwwroot/images is finish


            var photoinfo = new PhotoBO
            {
                Id = Id.HasValue ? Id.Value : 0,
                MemberId = MemberId.HasValue ? MemberId.Value : 0,
                PhotoFileName = PhotoFileName
            };
            _photoService.UpdatePhoto(photoinfo);
        }
    }
}
