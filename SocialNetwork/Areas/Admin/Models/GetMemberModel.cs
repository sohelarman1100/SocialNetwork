using SocialNetwork.Models;
using Autofac;
using SocialNetwork.Functionality.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class GetMemberModel
    {
        private readonly IMemberService _memberService;

        public GetMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public GetMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        internal object GetAllMembers(DataTablesAjaxRequestModel tableModel)
        {
            var data = _memberService.GetAllMembers(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "DateOfBirth", "Address" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                             record.Name,
                             record.DateOfBirth.ToString(),
                             record.Address,
                             record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
