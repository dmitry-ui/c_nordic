using System;
using System.Xml;
namespace XmlProject4
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load($"C:/1/users4.xml");
            //Console.WriteLine(xdoc);
            XmlElement xRoot = xdoc.DocumentElement;

            // Console.WriteLine($"количество атрибутов у рута  {xRoot.Attributes.Count}");
            if (xRoot.Attributes.Count != 0)
            {
                XmlNode attr1 = xRoot.Attributes.GetNamedItem("name");
                if (attr1 != null)
                {
                    Console.WriteLine($"Root name: {attr1.Value}");
                }

                XmlNode attr2 = xRoot.Attributes.GetNamedItem("description");
                if (attr2 != null)
                {
                    Console.WriteLine($"Root description: {attr2.Value}");
                }
            }

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "description")
                {
                    Console.WriteLine($"Элемент description: {xnode.InnerText}");
                }

                if (xnode.Name == "color")
                {
                    Console.WriteLine($"Элемент color: {xnode.InnerText}");
                }

                if (xnode.Attributes.Count > 0)
                {
                    if (xnode.Attributes.GetNamedItem("name") != null)
                    {
                        Console.WriteLine($"атрибут name: {xnode.Attributes.GetNamedItem("name").Value}");
                    }
                    if (xnode.Attributes.GetNamedItem("name1") != null)
                    {
                        Console.WriteLine($"атрибут name1: {xnode.Attributes.GetNamedItem("name1").Value}");
                    }
                }

                foreach (XmlNode ChildNode in xnode.ChildNodes)
                {
                    foreach (XmlNode ChildNode1 in xnode.ChildNodes)
                    {
                        if (ChildNode1.Attributes != null)
                        {
                            if (ChildNode1.Attributes.Count > 0)
                            {
                                if (ChildNode1.Attributes.GetNamedItem("name") != null)
                                {
                                    Console.WriteLine($"name: {ChildNode1.Attributes.GetNamedItem("name").Value}");
                                }
                            }
                        }

                        if (ChildNode1.Name == "company")
                        {
                            Console.WriteLine($"Элемент company: {ChildNode1.InnerText}");
                        }

                    }
                }
            }

            Console.ReadKey();
        }
    }
}
