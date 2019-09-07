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
        //new указывает,что сокрытие метода в базовом классе преднамеренное
        new public string GetProperties()
        {
            return $"TypesOfTransport: {TypeOfTransport}\nTypeCars: {TypeCars}\nRegNumber: {RegNumber}" +
                $"\nQuantityPassangeers: {QuantityPassangeers}\nTypeOfEngine: {TypeOfEngine}\nPowerOfEngine: {PowerOfEngine}";
        }

        //но все равно можно обратиться к сокрытому методу базового класса
        public string GetPropertiesBase()
        {
            return base.GetProperties();  //исп base
        }

    }
}
