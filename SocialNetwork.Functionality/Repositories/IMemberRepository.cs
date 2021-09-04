using SocialNetwork.Data;
using SocialNetwork.Functionality.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Repositories
{
    public interface IMemberRepository : IRepository<Member, int>
    {
    }
}
