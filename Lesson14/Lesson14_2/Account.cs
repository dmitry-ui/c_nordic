using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_2
{
    class Account<T> 
    {
        public T Id;

        public string Name;

        public Account(T id, string name)
        {
            Id = id;
            Name = name;
        }

        public void WriteProperties()
        { 
            Console.WriteLine("Id={0}, Name={1}",Id ,Name);
        }
    }
}
