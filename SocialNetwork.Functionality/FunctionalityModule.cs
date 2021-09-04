using Autofac;
using SocialNetwork.Functionality.Contexts;
using SocialNetwork.Functionality.Repositories;
using SocialNetwork.Functionality.Services;
using SocialNetwork.Functionality.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality
{
    public class FunctionalityModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FunctionalityModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FunctionalityContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<FunctionalityContext>().As<IFunctionalityContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MemberRepository>().As<IMemberRepository>().InstancePerLifetimeScope();

            builder.RegisterType<FunctionalityUnitOfWork>().As<IFunctionalityUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<MemberService>().As<IMemberService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>().InstancePerLifetimeScope();

            builder.RegisterType<FunctionalityUnitOfWork>().As<IFunctionalityUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<PhotoService>().As<IPhotoService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
