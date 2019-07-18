//Использование FileStream для копирования файлов
using System;
using System.IO;
class CopyFile
{
    static void Main(string[] arg)
    {
        int i;
        FileStream f1=null; //что копируем
        FileStream f2=null; //куда копируем
        if (arg.Length !=2)
        {
            Console.WriteLine("Для запуска программы необходимы два параметра.");
            return;
        }
        try
        {
            f1 = new FileStream(arg[0], FileMode.Open);
            f2 = new FileStream(arg[1], FileMode.CreateNew);
            do
            {
                i = f1.ReadByte();
                if (i != -1) f2.WriteByte((byte)i);
            }
            while (i != -1);
        }
        catch (IOException ioe)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n " + ioe.Message);
        }
        finally
        {
            if (f1 != null) f1.Close();
            if (f2 != null) f2.Close();
        }
    }
}