using System;
using System.Xml;
class Program
{
    static void Main(string[] args)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("C://1//users.xml");
        // получим корневой элемент
        XmlElement xRoot = xDoc.DocumentElement;
        // обход всех узлов в корневом элементе
        foreach (XmlNode xnode in xRoot)
        {
            // получаем атрибут name
            if(xnode.Name == "description")
            {
                Console.WriteLine(xnode.InnerText);
            }
            if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    Console.WriteLine(attr.Value);
            }
            // обходим все дочерние узлы элемента user
            foreach (XmlNode childnode in xnode.ChildNodes)
            {
                // если узел - company
                if (childnode.Name == "company")
                {
                    Console.WriteLine($"Компания: {childnode.InnerText}");
                }
                // если узел age
                if (childnode.Name == "age")
                {
                    Console.WriteLine($"Возраст: {childnode.InnerText}");
                }
                foreach (XmlNode childnode2 in childnode.ChildNodes)
                {
                    if (childnode2.Name == "city")
                    {
                        Console.WriteLine($"Город: {childnode2.InnerText}");
                    }
                    // если узел age
                    if (childnode2.Name == "street")
                    {
                        Console.WriteLine($"Улица: {childnode2.InnerText}");
                    }
                    if (childnode2.Name == "house")
                    {
                        Console.WriteLine($"Дом: {childnode2.InnerText}");
                    }
                    if (childnode2.Name == "flat")
                    {
                        Console.WriteLine($"Кв: {childnode2.InnerText}");
                    }
                }

            }
            Console.WriteLine();
        }
        Console.Read();
    }
}