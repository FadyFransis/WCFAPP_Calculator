using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFHost.Contracts
{
    [ServiceContract(Namespace = "http://wcfdemo/calculator")]
    public interface ICalculatorService
    {
        [OperationContract]
        double Add(double a, double b);

        [OperationContract]
        double Divide(double a, double b);

        [OperationContract]
        string Greet(Person person);
    }

    [DataContract(Namespace = "http://wcfdemo/calculator")]
    public class Person
    {
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public int Age { get; set; }
    }
}