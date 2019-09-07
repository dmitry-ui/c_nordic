using System;
using System.Collections.Generic;
using System.Text;

namespace nasl.Transports
{
    class Transport
    {
        public enum Engines { Diesel, Dvs}
        public enum TypesOfTransport { Car, Lorry, Bus, Motocicle}
        public TypesOfTransport TypeOfTransport{ get; set; }
        public string RegNumber { get; set; }
        public Engines TypeOfEngine { get; set; }
        public int PowerOfEngine { get; set; }
        public Transport() { }
        public Transport(TypesOfTransport tt, string rn, Engines en, int p )
        {
            TypeOfTransport = tt;
            RegNumber = rn;
            TypeOfEngine = en;
            PowerOfEngine = p;
        }

        //разрешаем переопределять метод в дочерних классах - virtual
        public virtual string GetProperties()
        {
            return $"TypesOfTransport: {TypeOfTransport}\nRegNumber: {RegNumber}\nTypeOfEngine: {TypeOfEngine}\nPowerOfEngine: {PowerOfEngine}";
        }
    }
}
