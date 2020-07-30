using Business.Rules.Engine.Handlers;
using Business.Rules.Engine.Processors;
using Business.Rules.Engine.ProductAction;
using Business.Rules.Engine.Repository;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Installer
{
    public class BusinessRuleEngineInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Register(Component.For<IPaymentSlipGenerator>().ImplementedBy<PaymentSlipGenerator>());


            container.Register(Component.For <IPhysicalProductProcessor>().ImplementedBy<PhysicalProductProcessor>());
            

            container.Register(Component.For<ProductPaymentHandler>());
        }
    }
}
