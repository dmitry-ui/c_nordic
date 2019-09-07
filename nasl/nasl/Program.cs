using System;
using nasl.Cars;
using nasl.Transports;

namespace nasl
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport TR = new Transport();
            TR.TypeOfTransport = Transport.TypesOfTransport.Car;
            TR.RegNumber = "Н993ХА34";
            TR.TypeOfEngine = Transport.Engines.Dvs;
            TR.PowerOfEngine = 2500;
            Console.WriteLine(TR.GetProperties());

            Console.WriteLine();

            Car CR = new Car();
            CR.TypeOfTransport = Transport.TypesOfTransport.Car;
            CR.RegNumber = "Н993ХА34";
            CR.TypeOfEngine = Transport.Engines.Dvs;
            CR.PowerOfEngine = 2500;
            CR.TypeCars = Car.Cars.Sedan;
            CR.QuantityPassangeers = 5;
            Console.WriteLine(CR.GetProperties());

            Console.WriteLine();

            //по сути  вызываем сокрытый метод базового класса
            Console.WriteLine(CR.GetPropertiesBase());


            Console.ReadKey();
        }
    }
}
