//////////////////////переменные
using System;

class Example2
{
    static void Main()
    {
        /*   int x; // здесь объявляется переменная
           int у; // здесь объявляется еще одна переменная
           x = 100; // здесь переменной х присваивается значение 100
           Console.WriteLine("х содержит " + x);
           у = x / 2;
           Console.Write("у содержит х / 2: ");
           Console.WriteLine(у);
        */

        //
        /*
        int ivar; // объявить целочисленную переменную
        double dvar; // объявить переменную с плавающей точкой
        ivar = 100; // присвоить переменной ivar значение 100
        dvar = 100.0; // присвоить переменной dvar значение 100.0
        Console.WriteLine("Исходное значение ivar: " + ivar);
        Console.WriteLine("Исходное значение dvar: " + dvar);
        Console.WriteLine(); // вывести пустую строку
                             // Разделить значения обеих переменных на 3.
        ivar = ivar / 3;
        dvar = dvar / 3.0;
        Console.WriteLine("Значение ivar после деления: " + ivar);
        Console.WriteLine("Значение dvar после деления: " + dvar);
        */
        //
        /*
        double radius;
        double area;
        radius = 10.0;
        area = radius * radius * 3.1416;
        Console.WriteLine("Площадь равна " + area);
        */
        ////////////////////////////////////Условия
        /*int a, b, c;
        a = 2;
        b = 3;
        if (a < b) Console.WriteLine("а меньше b");
        // He подлежит выводу.
        if (a == b) Console.WriteLine("этого никто не увидит");
        Console.WriteLine();
        c = a - b; // с содержит -1
        Console.WriteLine("с содержит -1");
        if (c >= 0) Console.WriteLine("значение с неотрицательно");
        if (c < 0) Console.WriteLine("значение с отрицательно");
        Console.WriteLine();
        c = b - a; // теперь с содержит 1
        Console.WriteLine("с содержит 1");
        if (c >= 0) Console.WriteLine("значение с неотрицательно");
        if (c < 0) Console.WriteLine("значение с отрицательно ");
        */
        ////////////цикл for  
        /*
        for (int count = 0; count < 5; count++)
            Console.WriteLine("Это подсчет: " + count);
        Console.WriteLine("Готово!");
        */
        //
        /*int i, j, d;
        i = 5;
        j = 10;
        // Адресатом этого оператора if служит кодовый блок.
        if (i != 0)
        {
            Console.WriteLine("i не равно нулю");
            d = j / i;
            Console.WriteLine("j / i равно " + d);
        }
        */
        ////////////////////////Суммаи произведение чисел от 1 до 10
        /*
            int prod;
            int sum;
            int i;
            sum = 0;
            prod = 1;
            for (i = 1; i <= 10; i++)
            {
                sum = sum + i;
                prod = prod * i;
            }
            Console.WriteLine("Сумма равна " + sum);
            Console.WriteLine("Произведение равно " + prod);
        */
        // Продемонстрировать применение идентификатора со знаком @. лучше не использовать
        /*int @if; // применение ключевого слова if
        // в качестве идентификатора
         for (@if = 0; @if < 10; @if++)
                 Console.WriteLine("@if равно " + @if);
        */
        ///////////////////целочисленный тип
        /*long inches;
        long miles;
        miles = 93000000; // 93 000 000 миль до Солнца
                          // 5 280 футов в миле, 12 дюймов в футе,
        inches = miles * 5280 * 12;
        Console.WriteLine("Расстояние до Солнца: " +
        inches + " дюймов.");
        */
        //////////////////////////////плавающая запятая, т.е. дробные числа
        // Определить радиус окружности по площади круга.
        /*
             Double r;
             Double area;
             area = 10.0;
             r = Math.Sqrt(area / 3.1416);
             Console.WriteLine("Радиус равен " + r);
          */
        /////////////
        /*
        Double theta; // угол в радианах
        for (theta = 0.1; theta <= 1.0; theta = theta + 0.1)
        {
            Console.WriteLine("Синус угла " + theta +
            " равен " + Math.Sin(theta));
            Console.WriteLine("Косинус угла " + theta +
            " равен " + Math.Cos(theta));
            Console.WriteLine("Тангенс угла " + theta +
            " равен " + Math.Tan(theta));
            Console.WriteLine();
        }
        */
        //стр 73
        // Использовать тип decimal для расчета скидки.
        /*
            decimal price;
            decimal discount;
            decimal discounted_price;
        // Рассчитать цену со скидкой.
        // без суффикса m эти значения интерпретировались бы как стандартные константы с плавающей точкой, 
        //которые несовместимы с типом данных decimal
            price = 19.95m;
            discount = 0.15m; // норма скидки составляет 15%
            discounted_price = price - (price * discount);
            Console.WriteLine("Цена со скидкой: $" + discounted_price);
            */

        /* Применить тип decimal для расчета будущей стоимости капиталовложений.*/
        /*
            decimal amount;
            decimal rate_of_return;
            int years, i;
            amount = 1000.0m;
            rate_of_return = 0.07m;
            years = 10;
            Console.WriteLine("Первоначальные капиталовложения: $" + amount);
            Console.WriteLine("Норма прибыли: " + rate_of_return);
            Console.WriteLine("В течение " + years + " лет");
            for (i = 0; i < years; i++)
                amount = amount + (amount * rate_of_return);
            Console.WriteLine("Будущая стоимость равна $" + amount);
            */

        // Продемонстрировать применение типа bool.
        /* bool b;
         b = false;
         Console.WriteLine("b равно " + b);
         b = true;
         Console.WriteLine("b равно " + b);
         // Логическое значение может управлять оператором if.
         if (b) Console.WriteLine("Выполняется.");
         b = false;
         if (b) Console.WriteLine("He выполняется.");
         // Результатом выполнения оператора отношения
         // является логическое значение.
         Console.WriteLine("10 > 9 равно " + (10 > 9));
         */

        //возведение в квадрат и куб
        //здесь:   /t -  знак табуляции
        /*int i;
        Console.WriteLine("Число\tКвадрат\tКуб");
        for (i = 1; i < 10; i++)
            Console.WriteLine("{0}\t{1}\t{2}", i, i * i, i * i * i);
        */

        //можно использовать формат C для вывода денежного формата
        /*decimal price;
        decimal discount;
        decimal discounted_price;
        // рассчитать цену со скидкой,
        price = 19.95m;
        discount = 0.15m; // норма скидки составляет 15%
        discounted_price = price - (price * discount);
        Console.WriteLine("Цена со скидкой: {0:C}", discounted_price);
        */


        // Продемонстрировать применение управляющих
        // последовательностей символов в строковых литералах.
        /*
            Console.WriteLine("Первая строка\nВторая строка\nТретья строка");
            Console.WriteLine("Один\tДва\tТри");
            Console.WriteLine("Четыре\tПять\tШесть");
            // Вставить кавычки.
            Console.WriteLine("\"3ачем?\", спросил он.");
        */

        // Продемонстрировать применение буквальных строковых литералов.
        /*
        Console.WriteLine(@"Это буквальный
               строковый литерал,
               занимающий несколько строк.
               ");
        Console.WriteLine(@"А это вывод с табуляцией:
              1 2 3 4
              5 6 7 8
              ");
        Console.WriteLine(@"Отзыв программиста: ""Мне нравится С#.""");
        */
        //
        // Продемонстрировать применение неявно типизированных переменных.
        /*
            // Эти переменные типизированы неявно. Они отнесены
            // к типу double, поскольку инициализирующие их
            // выражения сами относятся к типу double.
            var s1 = 4.0;
            var s2 = 5.0;
            // Итак, переменная hypot типизирована неявно и
            // относится к типу double, поскольку результат,
            // возвращаемый методом Sqrt(), имеет тип double.
            var hypot = Math.Sqrt((s1 * s1) + (s2 * s2));
            Console.Write("Гипотенуза треугольника со сторонами " +
            s1 + " by " + s2 + " равна ");
            Console.WriteLine("{0:#.###}.", hypot);
            // Следующий оператор не может быть скомпилирован,
            // поскольку переменная s1 имеет тип double и
            // ей нельзя присвоить десятичное значение.
            // s1 = 12.2М; // Ошибка!
            */

        // Продемонстрировать область действия кодового блока.
        /*int x; // Эта переменная доступна для всего кода внутри метода Main().
        x = 10;
        if (x == 10)
        { // начать новую область действия
            int у = 20; // Эта переменная доступна только в данном кодовом блоке.
                        // Здесь доступны обе переменные, х и у.
            Console.WriteLine("х и у: " + x + " " + у);
        x = у * 2;
        }
        // у = 100; // Ошибка! Переменна у здесь недоступна.
        // А переменная х здесь по-прежнему доступна.
        Console.WriteLine("х равно " + x);            */

        // Продемонстрировать время существования переменной.
        /*
        int x;
        for (x = 0; x < 3; x++)
        {
            int у = -1; // Переменная у инициализируется при каждом входе в блок.
            Console.WriteLine("у равно: " + у); // Здесь всегда выводится -1
            у = 100;
            Console.WriteLine("у теперь равно: " + у);
        }
        */

        // Продемонстрировать неявное преобразование типа long в тип double.
        /*long L;
        double D;
        L = 100123285L;
        D = L;
        Console.WriteLine("L и D: " + L + " " + D);
        */

        // Продемонстрировать приведение типов.
        /*double x, y;
        byte b;
        int i;
        char ch;
        uint u;
        short s;
        long l;
        x = 10.0;
        y = 3.0;
        // Приведение типа double к типу int, дробная часть числа теряется.
        i = (int)(x / y);
        Console.WriteLine("Целочисленный результат деления х / у: " + i);
        Console.WriteLine();
        // Приведение типа int к типу byte без потери данных,
        i = 255;
        b = (byte)i;
        Console.WriteLine("b после присваивания 255: " + b +
        " -- без потери данных.");
        // Приведение типа int к типу byte с потерей данных,
        i = 257;
        b = (byte)i;
        Console.WriteLine("b после присваивания 257: " + b +
        " -- с потерей данных.");
        Console.WriteLine();

        // Приведение типа uint к типу short без потери данных.
        u = 32000;
        s = (short)u;
        Console.WriteLine("s после присваивания 32000: " +
        s + " -- без потери данных.");
        // Приведение типа uint к типу short с потерей данных,
        u = 64000;
        s = (short)u;
        Console.WriteLine("s после присваивания 64000: " +
        s + " -- с потерей данных.");
        Console.WriteLine();
        // Приведение типа long к типу uint без потери данных.
        l = 64000;
        u = (uint)l;
        Console.WriteLine("u после присваивания 64000: " + u +
        " -- без потери данных.");
        // Приведение типа long к типу uint с потерей данных.
        l = -12;
        u = (uint)l;
        Console.WriteLine("и после присваивания -12: " + u +
        " -- с потерей данных.");
        Console.WriteLine();
        // Приведение типа int к типу char,
        b = 88; // код ASCII символа X
        ch = (char)b;
        Console.WriteLine("ch после присваивания 88: " + ch);        */

        //
        // Пример приведения типов в выражениях.
        /*    double n;
        for (n = 1.0; n <= 10; n++)
        {
            Console.WriteLine("Квадратный корень из {0} равен {1}", n, Math.Sqrt(n));
            Console.WriteLine("Целая часть числа: {0}", (int)Math.Sqrt(n));
            Console.WriteLine("Дробная часть числа: {0}", Math.Sqrt(n) - (int)Math.Sqrt(n));
            Console.WriteLine();
        }
        */

        //ГЛАВА 4 ОПЕРАТОРЫ
        // Продемонстрировать применение оператора %.
        /*int iresult, irem;
        double dresult, drem;
        iresult = 10 / 3;
        irem = 10 % 3;
        dresult = 10.0 / 3.0;
        drem = 10.0 % 3.0;
        Console.WriteLine("Результат и остаток от деления 10/3: " +
        iresult + " " + irem);
        Console.WriteLine("Результат и остаток от деления 10.0 / 3.0: " +
        dresult + " " + drem);
        */

        // Продемонстрировать отличие между префиксной
        // и постфиксной формами оператора инкремента (++).
           /* int x, y;
            int i;
            x = 1;
            y = 0;
            Console.WriteLine("Ряд чисел, полученных " +
            "с помощью оператора у = у + х++;");
            for (i = 0; i < 10; i++)
            {
                y = y + x++; // постфиксная форма оператора ++
                Console.WriteLine(y + " ");
            }
            Console.WriteLine();
            x = 1;
            y = 0;
            Console.WriteLine("Ряд чисел, полученных " +
            "с помощью оператора у = у + ++х;");
            for (i = 0; i < 10; i++)
            {
                y = y + ++x; // префиксная форма оператора ++
                Console.WriteLine(y + " ");
            }
            Console.WriteLine();            */
            //стр 140

        }
    }