using Autofac;
using SocialNetwork.Functionality.BusinessObjects;
using SocialNetwork.Functionality.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class CreateMemberModel
    {
        [Required(ErrorMessage ="please provide your name"), MaxLength(200, ErrorMessage = 
            "Name should be less than 200 charcaters")]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        [Required, MaxLength(200, ErrorMessage = "Address should be less than 200 charcaters")]
        public string Address { get; set; }


        private IMemberService _memberService;

        public CreateMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public CreateMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        internal void CreateMember()
        {
            var member = new MemberBO
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                Address = Address
            };

            _memberService.CreateMember(member);
        }
    }
}
