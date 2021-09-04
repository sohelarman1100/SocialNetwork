using SocialNetwork.Data;
using SocialNetwork.Functionality.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.UnitOfWorks
{
    public interface IFunctionalityUnitOfWork : IUnitOfWork
    {
        public IMemberRepository Members { get; }
        public IPhotoRepository Photos { get; }
    }
}
