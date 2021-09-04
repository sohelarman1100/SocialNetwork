using Autofac;
using SocialNetwork.Functionality.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class DeleteMemberModel
    {
        private readonly IMemberService _memberService;

        public DeleteMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }

        public DeleteMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        internal void DeleteMember(int id)
        {
            _memberService.DeleteMember(id);
        }
    }
}
