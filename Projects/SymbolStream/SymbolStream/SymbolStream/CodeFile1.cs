// Простая сервисная программа ввода с клавиатуры и вывода на диск,
// демонстрирующая применение класса StreamWriter.
using System;
using System.IO;
class KtoD
{
    static void Main()
    {
        //1 способ
        /*
        string str;
        FileStream fout;
        // Открыть сначала поток файлового ввода-вывода.
        try
        {
            fout = new FileStream("test.txt", FileMode.Create);
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
            return;
        }
        // Заключить поток файлового ввода-вывода в оболочку класса StreamWriter.
        StreamWriter fstr_out = new StreamWriter(fout);
        try
        {
            Console.WriteLine("Введите текст, а по окончании — 'стоп'.");
            do
            {
                Console.Write(": ");
                str = Console.ReadLine();
                if (str != "стоп")
                {
                    str = str + "\r\n"; // добавить новую строку и перевести каретку
                    fstr_out.Write(str);
                }
            } while (str != "стоп");
        }
        catch (IOException exc)
        {
            Console.WriteLine("Ошибка ввода-вывода:\n" + exc.Message);
        }
        finally
        {
            fstr_out.Close();
        }

    */

        //2 способ:  Открыть файл средствами класса StreamWriter.
        string str;
        StreamWriter sw = null;
        try
        {
            sw = new StreamWriter("test2.txt");
            Console.WriteLine("Введите текст, а по окончании — 'стоп'.");
            do
            {
                Console.Write(": ");
                str = Console.ReadLine();
                if (str != "стоп")
                {
                    str = str + "\r\n"; // добавить новую строку и перевести каретку
                    sw.Write(str);
                }
            } while (str != "стоп");
        }
        catch(IOException ioe)
        {
            Console.WriteLine("ошибку открытия файла: {0}", ioe.Message);
        }
        finally
        {
            if (sw != null) sw.Close();
        }

       


    }
}
