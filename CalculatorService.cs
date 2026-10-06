using System;
using System.ServiceModel;
using WCFHost.Contracts;

namespace WCFHost
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CalculatorService : ICalculatorService
    {
        public double Add(double a, double b)
        {
            Console.WriteLine($"[Server] Add({a}, {b})");
            return a + b;
        }

        public double Divide(double a, double b)
        {
            Console.WriteLine($"[Server] Divide({a}, {b})");
            if (b == 0)
                throw new FaultException("Division by zero is not allowed.");
            return a / b;
        }

        public string Greet(Person person)
        {
            Console.WriteLine($"[Server] Greet({person?.FirstName})");
            if (person == null)
                throw new FaultException("Person cannot be null.");
            return $"Hello {person.FirstName} {person.LastName}, age {person.Age}!";
        }
    }
}