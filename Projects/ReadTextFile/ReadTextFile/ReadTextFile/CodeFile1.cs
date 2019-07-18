using System;
using System.IO;
class ReadTExtFile
{
    static void Main(String[] arg)  //параметр - полный путь к файлу
    {
        /*
        //1 способ - два блока try
        //чтение текстового файла и вывод его на экран

        if (arg.Length !=1)
        {
            Console.WriteLine("Не указан файл");  //файл передаем через параметр
            return;
        }
        int i;
        FileStream fin;  //создаем поток
        try
        {
            fin = new FileStream(arg[0], FileMode.Open); //открываем существующий файл
        }
        catch (IOException exc)
        {
            Console.WriteLine("He удается открыть файл");
            Console.WriteLine(exc.Message);
            return; // Файл не открывается, завершить программу
        }
        try
        {
            //считываем символы по одному и отображаем их 
            do
            {
                i = fin.ReadByte(); //считываем по байтам
                if (i != -1) Console.Write((char)i);  //из потока возващаются числа, переводим их в символы
            }
            while (i != -1); // до тех пор пока они не закончатся
        }
        catch (IOException excq)
            {
                Console.WriteLine("Ошибка чтения файла");
                Console.WriteLine(excq.Message);
            }
        finally { fin.Close(); }  //гарантированно закрываем файл
        */


        //// 2 способ - все в один блок try

        int j;
        FileStream fs = null;
        if(arg.Length != 1)
        {
            Console.WriteLine("введите корректный путь");
            return;
        }

        try
        {
            fs = new FileStream(arg[0], FileMode.Open);
            do
            {
                j = fs.ReadByte();
                if (j != -1) Console.Write((char)j);
            }
            while (j != -1);
            

        }
        catch (IOException ioe)
        {
            Console.WriteLine("Ошибка ввода - вывода: " + ioe.Message);
        }
        finally
        {
            if(fs !=null) fs.Close();
        }


    }
}