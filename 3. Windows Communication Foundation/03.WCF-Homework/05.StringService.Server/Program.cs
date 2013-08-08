using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace _05.StringService.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run Visual Studio as administrator

            Uri serviceAddress = new Uri("http://localhost:1234/count");
            ServiceHost selfHost = new ServiceHost(typeof(_03.StringService.StringService), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                Console.WriteLine("The service is started at endpoint " + serviceAddress);

                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
