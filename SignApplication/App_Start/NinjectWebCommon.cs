using System.Configuration;
using SignApplication.Global.Authentication;
using SignApplication.Global.Mappers;
using SignApplication.Global.Repository;
using SignApplication.Global.Repository.ContentTemplates;
using SignApplication.Global.Repository.ContentTypes;
using SignApplication.Global.Repository.Documents;
using SignApplication.Global.Repository.RequestDocContents;
using SignApplication.Global.Repository.Requests;
using SignApplication.Global.Repository.SystemLists;
using SignApplication.Global.Repository.SystemListValues;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Global.Repository.Users;
using SignApplication.Global.Service.Documents;
using SignApplication.Model.DBConnection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SignApplication.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SignApplication.App_Start.NinjectWebCommon), "Stop")]

namespace SignApplication.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<SignAppContext>().ToMethod(c => new SignAppContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)).InRequestScope();
            kernel.Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
            kernel.Bind<IMapper>().To<CommonMapper>().InSingletonScope();

            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IContentTemplateRepository>().To<ContentTemplateRepository>().InRequestScope();
            kernel.Bind<IContentTypeRepository>().To<ContentTypeRepository>().InRequestScope();
            kernel.Bind<IDocumentRepository>().To<DocumentRepository>().InRequestScope();
            kernel.Bind<IRequestDocContentRepository>().To<RequestDocContentRepository>().InRequestScope();
            kernel.Bind<IRequestRepository>().To<RequestRepository>().InRequestScope();
            kernel.Bind<ISystemListRepository>().To<SystemListRepository>().InRequestScope();
            kernel.Bind<IUploadedFileRepository>().To<UploadedFileRepository>().InRequestScope();
            kernel.Bind<ISystemListValueRepository>().To<SystemListValueRepository>().InRequestScope();

            kernel.Bind<IDocumentService>().To<DocumentService>().InRequestScope();
        }        
    }
}
