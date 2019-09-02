using System;

namespace Lesson10_Home01
{
    class Program
    {
        static void Main(string[] args)
        {
            //People MyPeople = new People();
            //MyPeople.SetInfoFromConsole();
            //MyPeople.OutputDecriptionToConsole();


            //ввод данных
            People[] PeopleDim = new People[3];
            for (int i = 0; i < PeopleDim.Length; i++)
            {
                PeopleDim[i] = new People(); //важно
                PeopleDim[i].SetInfoFromConsole();
            }
            
            //вывод
            for (int i = 0; i < PeopleDim.Length; i++)
                PeopleDim[i].OutputDecriptionToConsole();
           
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
    class People
    {
        private string _name;
        private int _ageNow;
        private string name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    throw new Exception("Введены некорректные данные. Необходимо ввести имя...");
            }
        }
        private int age
        {
            get { return _ageNow; }
            set
            {
                if( value >=0 && value< 300)
                    _ageNow = value;
                else
                    throw new Exception("Введен некорректный возраст");
            } 
        }
        private int ageIn4Years
        {
            get
            {
                return (_ageNow +4);
            }
        }
        public string Description
        {
            get
            {
                return $"Возраст {name} равен {age}. Через 4 года его возраст будет {ageIn4Years}.";
            }
        }
        public void OutputDecriptionToConsole()
        {
            Console.WriteLine(Description);
        }
        public void SetInfoFromConsole()
        {
            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            try
            {
                age = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода! Необходимо ввести число.");
                throw new Exception("Ошибка ввода! Необходимо ввести число.");
            }
           
        }
    }
}
