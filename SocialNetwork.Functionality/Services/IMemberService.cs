using SocialNetwork.Functionality.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Services
{
    public interface IMemberService
    {
        void CreateMember(MemberBO member);
        (IList<MemberBO> records, int total, int totalDisplay) GetAllMembers(int pageIndex, 
            int pageSize, string searchText, string sortText);
        MemberBO GetMemberForEdit(int id);
        void UpdateMember(MemberBO memberinfo);
        void DeleteMember(int id);
    }
}
