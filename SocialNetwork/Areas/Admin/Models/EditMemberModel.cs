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
    public class EditMemberModel
    {
        [Required, Range(1, 500000)]
        public int? Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = "name length should between 1 to 200 charecter")]
        public string Name { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required, MaxLength(200, ErrorMessage = "address length should between 1 to 200 charecter")]
        public string Address { get; set; }

        private readonly IMemberService _memberService;

        public EditMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }

        public EditMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        internal void LoadMemberDataForEdit(int id)
        {
            var data = _memberService.GetMemberForEdit(id);
            Id = data?.Id;
            Name = data?.Name;
            DateOfBirth = data?.DateOfBirth;
            Address = data?.Address;
        }

        internal void Update()
        {
            var memberinfo = new MemberBO
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                DateOfBirth = DateOfBirth.HasValue ? DateOfBirth.Value : DateTime.MinValue,
                Address = Address
            };
            _memberService.UpdateMember(memberinfo);
        }
    }
}
