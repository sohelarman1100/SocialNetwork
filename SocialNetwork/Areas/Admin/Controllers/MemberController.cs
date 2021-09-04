using SocialNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }
        public IActionResult CreateMember()
        {
            var model = new CreateMemberModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateMember(CreateMemberModel model)
        {
            if (ModelState.IsValid)
            {
                bool IsCreateMember = false;
                try
                {
                    model.CreateMember();
                    IsCreateMember = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Member");
                    _logger.LogError(ex, "Create Member Failed");
                }
                if (IsCreateMember)
                    return RedirectToAction(nameof(CreateMember));
            }

            return View(model);
        }

        public IActionResult GetMemberDataView()
        {
            var model = new GetMemberModel();
            return View(model);
        }

        public JsonResult GetMemberData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new GetMemberModel();
            var data = model.GetAllMembers(dataTablesModel);
            return Json(data);
        }

        public IActionResult AllMembersWithEditAndDeleteButton()
        {
            var model = new GetMemberModel();
            return View(model);
        }

        public IActionResult EditMember(int id)
        {
            var model = new EditMemberModel();
            model.LoadMemberDataForEdit(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditMember(EditMemberModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
                return RedirectToAction(nameof(AllMembersWithEditAndDeleteButton));
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteMember(int id)
        {
            var model = new DeleteMemberModel();

            model.DeleteMember(id);

            return RedirectToAction(nameof(AllMembersWithEditAndDeleteButton));
        }
    }
}
