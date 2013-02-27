using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using Ninject.Modules;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Concrete;
using System.Configuration;
using PizzaStore.Domain.Services;

namespace PizzaStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // A Ninject "kernel" is the thing that can supply object instances
        private IKernel kernel = new StandardKernel(new PizzaStoreServices());

        // ASP.NET MVC calls this to get the controller for each request
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)kernel.Get(controllerType);
        }

        // Configures how abstract service types are mapped to concrete implementations
        private class PizzaStoreServices : NinjectModule
        {
            public override void Load()
            {
                Bind<IMenuItemsRepository>()
                    .To<SqlMenuItemsRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                Bind<ICustomerRepository>()
                    .To<SqlCustomerRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                Bind<IOrderRepository>()
                    .To<SqlOrderRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                Bind<IOrderItemRepository>()
                    .To<SqlOrderItemRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                Bind<IDeliveryRepository>()
                    .To<SqlDeliveryRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                Bind<IOrderDisplayRepository>()
                    .To<SqlOrderDisplayRepository>()
                    .WithConstructorArgument("connectionString",
                        ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                //Bind<IOrderSubmitter>().To<FakeOrderSubmitter>();

                Bind<IOrderSubmitter>().To<EmailOrderSubmitter>().WithConstructorArgument(
                    "mailTo",
                    ConfigurationManager.AppSettings["EmailOrderSubmitter.MailTo"]
                );

            }
        }
    }
}