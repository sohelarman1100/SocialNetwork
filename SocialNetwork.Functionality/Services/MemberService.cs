using SocialNetwork.Functionality.BusinessObjects;
using SocialNetwork.Functionality.Entities;
using SocialNetwork.Functionality.Exceptions;
using SocialNetwork.Functionality.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Services
{
    public class MemberService : IMemberService
    {
        private IFunctionalityUnitOfWork _functionalityUnitOfWork;
        public MemberService(IFunctionalityUnitOfWork functionalityUnitOfWork)
        {
            _functionalityUnitOfWork = functionalityUnitOfWork;
        }

        public void CreateMember(MemberBO member)
        {
            if (member == null)
                throw new InvalidParameterException("member info was not provided");

            var memberEntity = new Member
            {
                Name = member.Name,
                DateOfBirth = member.DateOfBirth,
                Address = member.Address
            };

            _functionalityUnitOfWork.Members.Add(memberEntity);

            _functionalityUnitOfWork.Save();
        }

        public (IList<MemberBO> records, int total, int totalDisplay) GetAllMembers(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var memberData = _functionalityUnitOfWork.Members.GetDynamic(string.IsNullOrWhiteSpace(searchText) ?
                null : x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from member in memberData.data
                              select new MemberBO
                              {
                                  Id = member.Id,
                                  Name = member.Name,
                                  DateOfBirth = member.DateOfBirth,
                                  Address = member.Address
                              }).ToList();

            return (resultData, memberData.total, memberData.totalDisplay);
        }

        public MemberBO GetMemberForEdit(int id)
        {
            var entityMember = _functionalityUnitOfWork.Members.GetById(id);
            var BusObjMember = new MemberBO
            {
                Id = entityMember.Id,
                Name = entityMember.Name,
                DateOfBirth = entityMember.DateOfBirth,
                Address = entityMember.Address
            };

            return BusObjMember;
        }

        public void UpdateMember(MemberBO memberinfo)
        {
            if (memberinfo == null)
                throw new InvalidOperationException("member is missing");

            var entityMember = _functionalityUnitOfWork.Members.GetById(memberinfo.Id);

            if (entityMember != null)
            {
                entityMember.Name = memberinfo.Name;
                entityMember.DateOfBirth = memberinfo.DateOfBirth;
                entityMember.Address = memberinfo.Address;

                _functionalityUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find Member");
        }

        public void DeleteMember(int id)
        {
            _functionalityUnitOfWork.Members.Remove(id);

            _functionalityUnitOfWork.Save();
        }
    }
}
