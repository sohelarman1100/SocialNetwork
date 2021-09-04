using Autofac;
using SocialNetwork.Functionality.Services;
using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class GetPhotoModel
    {
        private readonly IPhotoService _photoService;

        public GetPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }
        public GetPhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        internal object GetAllPhotos(DataTablesAjaxRequestModel tableModel)
        {
            var data = _photoService.GetAllPhotos(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "MemberId" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                             record.MemberId.ToString(),
                             record.PhotoFileName,
                             record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
