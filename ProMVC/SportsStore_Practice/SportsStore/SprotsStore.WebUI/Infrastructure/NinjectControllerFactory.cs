using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddingBindings();


        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            return controllerType == null ? null : (IController) _kernel.Get(controllerType);
        }

        private void AddingBindings()
        {
          _kernel.Bind<IProductRepository>().To<EFProductRepository>();


            EmailsSettings emailSettings = new EmailsSettings
                                               {
                                                   WriteAsFile =
                                                       bool.Parse(
                                                           ConfigurationManager.AppSettings["Email.WriteAsFile"] ??
                                                           "false")
                                               };
            _kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

        }
    }
}