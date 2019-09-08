using nasl.Transports;
using System;
using System.Collections.Generic;
using System.Text;

namespace nasl.Cars
{
    class Car : Transport
    {
        public enum Cars { Sedan, Hachback, Classic}

        public Cars TypeCars { get; set; }

        public int QuantityPassangeers;
        
        //как только мы создаем свой конструктор, конструктор по умолчанию (без параметров перестает существовать )
        //и если он нужен, то его надо создать вречную
        public Car(Cars typy, int kol, string rn, Engines en, int p) : base (TypesOfTransport.Car, rn, en, p)
        {
            TypeCars = typy;
            QuantityPassangeers = kol;
        }

        public Car() { }//теперь в основной программе Car CR = new Car();  - снова заработало

        //переопределяем метод из базового класса - override   \nTypeCars: {TypeCars} \nQuantityPassangeers: {QuantityPassangeers}
        public override string GetProperties()
        {
            return base.GetProperties() + $"\nTypeCars: { TypeCars} \nQuantityPassangeers: { QuantityPassangeers}";
        }
    }
}
