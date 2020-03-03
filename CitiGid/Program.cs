using CitiGid.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiGid
{
    class Program
    {
        static void Main(string[] args)
        {
            DBLog dBLog = new DBLog();
            Console.WriteLine("\nПарсим логи Ситигида:\n");

            Console.Write("Введите Id_min: ");
            int minId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите  Id_max: ");
            int maxId = Convert.ToInt32(Console.ReadLine());

            dBLog.WriteParsedTable(minId, maxId);

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
