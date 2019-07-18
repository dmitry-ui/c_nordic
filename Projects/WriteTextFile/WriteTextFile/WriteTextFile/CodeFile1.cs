using System;
using System.IO;

class WriteToFile
{
    static void Main()
    {
        //запишем в файл английский алфавит
        FileStream fs = null;
        try
        {
            fs = new FileStream("c:/1/test.txt", FileMode.CreateNew); //файл не должен существовать
            for (char ch = 'A'; ch <= 'Z'; ch++)
                fs.WriteByte((byte)ch);  // в поток записываем байты , а не символы

        }
        catch (IOException ioe)
        {
            Console.WriteLine("Ошибка при записи в файл: " + ioe.Message);
        }
        finally
        {
            if (fs != null) fs.Close(); //если поток ввода-вывода был успешно открыт ранее, то закрываем его
        }
     

    }

}
