using System;
using System.Xml;

namespace XmlProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("c://2//task.xml");
            XmlElement xmlRoot = xmldoc.DocumentElement;

            foreach (XmlNode xnode in xmlRoot)
            {
                if (xnode.Name == "description")
                    Console.WriteLine($"Описание: {xnode.InnerText}");
                foreach (XmlNode xnodechild in xnode.ChildNodes)
                {
                    if (xnodechild.Name == "tasktype")
                        Console.WriteLine($"Тип: {xnodechild.InnerText}");

                    //object i = xnodechild.Attributes.Count;
                    if (xnodechild.Attributes.Count > 0)
                    {
                        XmlNode attr = xnodechild.Attributes.GetNamedItem("name");
                        if (attr != null)
                        {
                            Console.WriteLine($"name: {attr.Value}");
                        }
                    }

                    /*
                     if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    Console.WriteLine(attr.Value);
            }
                     */

                    foreach (XmlNode xnodechild2 in xnodechild.ChildNodes)
                    {

                        if (xnodechild2.Name == "w6key")
                            Console.WriteLine($"w6key: {xnodechild2.InnerText}");
                        if (xnodechild2.Name == "order")
                            Console.WriteLine($"order: {xnodechild2.InnerText}");
                        if (xnodechild2.Name == "service")
                            Console.WriteLine($"service: {xnodechild2.InnerText}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
