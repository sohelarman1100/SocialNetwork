using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhotoController : Controller
    {
        private readonly ILogger<PhotoController> _logger;

        public PhotoController(ILogger<PhotoController> logger)
        {
            _logger = logger;
        }
        public IActionResult CreatePhoto()
        {
            var model = new CreatePhotoModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreatePhoto(CreatePhotoModel model)
        {
            if (ModelState.IsValid)
            {
                bool IsCreatePhoto = false;
                try
                {
                    model.CreatePhoto();
                    IsCreatePhoto = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Photo");
                    _logger.LogError(ex, "Create Photo Failed");
                }
                if (IsCreatePhoto)
                    return RedirectToAction(nameof(CreatePhoto));
            }

            return View(model);
        }

        public IActionResult GetPhotoDataView()
        {
            var model = new GetPhotoModel();
            return View(model);
        }

        public JsonResult GetPhotoData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new GetPhotoModel();
            var data = model.GetAllPhotos(dataTablesModel);
            return Json(data);
        }

        public IActionResult AllPhotosWithEditAndDeleteButton()
        {
            var model = new GetPhotoModel();
            return View(model);
        }

        public IActionResult EditPhoto(int id)
        {
            var model = new EditPhotoModel();
            model.LoadPhotoDataForEdit(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditPhoto(EditPhotoModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
                return RedirectToAction(nameof(AllPhotosWithEditAndDeleteButton));
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeletePhoto(int id)
        {
            var model = new DeletePhotoModel();

            model.DeletePhoto(id);

            return RedirectToAction(nameof(AllPhotosWithEditAndDeleteButton));
        }
    }
}
