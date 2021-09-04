using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Functionality.Contexts;
using SocialNetwork.Functionality.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.UnitOfWorks
{
    public class FunctionalityUnitOfWork : UnitOfWork, IFunctionalityUnitOfWork
    {
        public IMemberRepository Members { get; private set; }
        public IPhotoRepository Photos { get; private set; }
        public FunctionalityUnitOfWork(IFunctionalityContext context,
            IMemberRepository members, IPhotoRepository photos) : base((DbContext)context)
        {
            Members = members;
            Photos = photos;
        }
    }
}
