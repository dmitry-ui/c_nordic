using System;
using System.Xml;

namespace XmlProject3
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load($"c:/1/users.xml");

            XmlElement xRoot = xdoc.DocumentElement;

            foreach(XmlNode xNode in xRoot)
            {
                if(xNode.Name== "description")
                {
                    Console.WriteLine($"description:{xNode.InnerText}");
                }

                if(xNode.Attributes.Count > 0)
                {
                    XmlNode attr = xNode.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        Console.WriteLine($"name:{attr.Value}");
                    }
                }

                foreach (XmlNode xNodeChild in xNode.ChildNodes)
                {
                    if (xNodeChild.Name == "company")
                    {
                        Console.WriteLine($"company:{xNodeChild.InnerText}");
                    }

                    if (xNodeChild.Name == "age")
                    {
                        Console.WriteLine($"age:{xNodeChild.InnerText}");
                    }

                    if (xNodeChild.Attributes != null)
                    {
                        if (xNodeChild.Attributes.Count > 0)
                        {
                            if(xNodeChild.Attributes.GetNamedItem("famale") != null)
                            {
                                Console.WriteLine($"famale:{xNodeChild.Attributes.GetNamedItem("famale").Value}");
                            }
                            
                        }
                    }
                   
                }

            }

            Console.ReadKey();
        }
    }
}
