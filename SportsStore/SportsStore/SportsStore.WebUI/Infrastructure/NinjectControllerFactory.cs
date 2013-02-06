using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Configuration;
using System.Linq;
using System.Web;
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
        //
        // GET: /NinjectControllerFactory/

        private IKernel ninjectKernel; 

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }

        private void AddBinding()
        {
           
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>(); 
            EmailSettings emailSettings = new EmailSettings { 
                WriteAsFile 
                = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false") 
                };
            
            ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().
                WithConstructorArgument("settings",emailSettings);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                       ? null
                       : (IController) ninjectKernel.Get(controllerType);
        }
    }
}
