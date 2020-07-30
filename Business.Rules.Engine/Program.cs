using Business.Rules.Engine.Handlers;
using Business.Rules.Engine.Installer;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine
{
    public class Program
    {
        private static IWindsorContainer container;

        static void Main(string[] args)
        {
            SetupContainer();
            var handler = container.Resolve<ProductPaymentHandler>();

            Console.WriteLine("Welcome");

            do
            {
                Console.WriteLine("Please select the product.");
                Console.WriteLine("1. Hard Disk \n2. Pendrive \n3. Fault In Our Stars \n4. Harry Potter \n5. Activate membership" +
                    "\n6. Upgrade Membership \n7. Learning to Ski Video \n8. Basics of cooking");
                
                var input = Convert.ToInt32(Console.ReadLine());
                handler.Handle(input);

                Console.WriteLine("Press Y to continue");
            }
            while (Console.ReadLine().ToUpper() == "Y");

            Console.WriteLine();
        }

        private static void SetupContainer()
        {
            container = new WindsorContainer();
            container.Install(
                new RepositoriesInstaller(),
                new BusinessRuleEngineInstaller());
        }
    }
}
