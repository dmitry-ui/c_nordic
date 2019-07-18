using System;
class ConsoleInputOutput
{
    static void Main()
    {
        Char val;
        string str;
        Console.WriteLine("Введите символ и нажмите ввод:");
        val = (char)Console.Read(); //при этом в поток попадут еще два символа - перевода коретки и строки (построчная буферизация)
        Console.WriteLine("Вы ввели символ: {0}", val);

        Console.Read(); //нужно чтобы удалить из буфера символ перевода коретки
        Console.Read(); //нужно чтобы удалить из буфера символ перевода строки

        // проще всего воспользоваться методами класса Console
        Console.WriteLine("Введите строку и нажмите ввод:");
        str = Console.ReadLine();
        Console.WriteLine("Вы ввели cтроку: {0}", str);

        //можно и так:       
        //////воспользуемся для чтения из потока базовым классом TextReader
       
        string str1;
        Console.WriteLine("Введите строку и нажмите ввод:");
        str1 = Console.In.ReadLine();
        Console.WriteLine("Вы ввели строку: {0}", str1);

        //считаем отдельно введенные с клавиатуры символы без построчной буферизации (моментально)
        //При нажатии клавиши метод ReadKey() немедленно возвращает введенный с клавиатуры символ. 
        //И в этом случае пользователю уже не нужно нажимать дополнительно клавишу <Enter>.
        //Таким образом, метод ReadKey() позволяет считывать и обрабатывать ввод с клавиатуры в реальном масштабе времени.

        ConsoleKeyInfo keypress;
        Console.WriteLine("Введите несколько символов, " + "а по окончании - <Q>.");
        do
        {
            keypress = Console.ReadKey(); // считать данные о нажатых клавишах
            Console.WriteLine(" Вы нажали клавишу: " + keypress.KeyChar);
            // Проверить нажатие модифицирующих клавиш.
            if ((ConsoleModifiers.Alt & keypress.Modifiers) != 0)
                Console.WriteLine("Нажата клавиша <Alt>.");
            if ((ConsoleModifiers.Control & keypress.Modifiers) != 0)
                Console.WriteLine("Нажата клавиша <Control>.");
            if ((ConsoleModifiers.Shift & keypress.Modifiers) != 0)
                Console.WriteLine("Нажата клавиша <Shift>.");
        } while (keypress.KeyChar != 'Q');

        //
        int a = 10, b = 0;
        int result;
        Console.Out.WriteLine("Деление на нуль приведет " + "к исключительной ситуации.");
        try
        {
            result = a / b; // сгенерировать исключение при попытке деления на нуль
        }
        catch (DivideByZeroException exc)
        {
            Console.Error.WriteLine(exc.Message);
        }


    }

}