using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Functionality.Contexts;
using SocialNetwork.Functionality.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Repositories
{
    public class MemberRepository : Repository<Member, int>, IMemberRepository
    {
        public MemberRepository(IFunctionalityContext context)
            : base((DbContext)context)
        {
        }
    }
}
