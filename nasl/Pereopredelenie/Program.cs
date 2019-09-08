using System;
using nasl.Cars;
using nasl.Transports;

namespace nasl
{
    class Program
    {
        static void Main(string[] args)
        {
            //Transport TR = new Transport();
            //TR.TypeOfTransport = Transport.TypesOfTransport.Car;
            //TR.RegNumber = "Н993ХА34";
            //TR.TypeOfEngine = Transport.Engines.Dvs;
            //TR.PowerOfEngine = 2500;
            //Console.WriteLine(TR.GetProperties());

            //Console.WriteLine();

            //Car CR = new Car();
            //CR.TypeOfTransport = Transport.TypesOfTransport.Car;
            //CR.RegNumber = "Н993ХА34";
            //CR.TypeOfEngine = Transport.Engines.Dvs;
            //CR.PowerOfEngine = 2500;
            //CR.TypeCars = Car.Cars.Sedan;
            //CR.QuantityPassangeers = 5;
            //Console.WriteLine(CR.GetProperties());

            Console.WriteLine();
            //если в производном классе определен конструктор с параметрами, но он не вызывает конструктор базового класса
            //то будут проинициализированы только переменные из производного класса
            Car CR1 = new Car(Car.Cars.Hachback, 7, "номер 123",Transport.Engines.Dvs, 1000 );
            Console.WriteLine(CR1.GetProperties());

            Transport[] MyGarage = new Transport[3];
            MyGarage[0] = new Transport(Transport.TypesOfTransport.Bus, "re456v34", Transport.Engines.Diesel, 6800);
            MyGarage[1] = new Car(Cars.Car.Cars.Classic, 3, "МА123НН48", Cars.Car.Engines.Dvs, 2300);
            MyGarage[2] = new Car(Cars.Car.Cars.Sedan, 5, "х088ма34", Cars.Car.Engines.Diesel, 4300);

            Console.WriteLine();

            foreach (Transport tr in MyGarage)
            {
                Console.WriteLine(tr.GetType());
                Console.WriteLine(tr.GetProperties());
                Console.WriteLine();
                //if (tr is Car)
                //    Console.WriteLine("Car");
                //else if (tr is Transport)
                //    Console.WriteLine("Transport");
            }


            Console.ReadKey();
        }
    }
}
