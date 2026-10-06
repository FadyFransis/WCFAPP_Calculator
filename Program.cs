using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFHost
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(CalculatorService)))
            {
                try
                {
                    host.Open();

                    Console.WriteLine("CalculatorService is running.");
                    foreach (ServiceEndpoint ep in host.Description.Endpoints)
                        Console.WriteLine($"  {ep.Binding.Name,-15} {ep.Address}");
                    Console.WriteLine("\nPress <Enter> to stop...");
                    Console.ReadLine();

                    host.Close();
                }
                catch (AddressAccessDeniedException)
                {
                    Console.WriteLine("Access denied to the HTTP URL. Run as Administrator, or reserve it:");
                    Console.WriteLine(@"  netsh http add urlacl url=http://+:8080/CalculatorService user=%USERDOMAIN%\%USERNAME%");
                    host.Abort();
                }
                catch (CommunicationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    host.Abort();
                }
            }
        }
    }
}