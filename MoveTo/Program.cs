using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveTo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"./conf.xml");
            XmlNodeList nodeListFolderLink = xDoc.SelectNodes("/links/folderLink");
            XmlNodeList nodeListMoveTo = xDoc.SelectNodes("/links/moveTo");
            string folderLink = @"C:\Users\tower\source\repos\MoveTo\MoveTo\bin\Debug\default";
            string moveTo = @"C:\Users\tower\Pictures\test";
            // selected folders
            foreach (XmlNode node in nodeListFolderLink)
            {
                Console.WriteLine("Take All");
                Console.WriteLine(node.InnerText);
                folderLink = node.InnerText;
            }
            foreach (XmlNode node in nodeListMoveTo)
            {
                Console.WriteLine("Move To");
                Console.WriteLine(node.InnerText);
                moveTo = node.InnerText;
            }   
            DirectoryInfo diTop = new DirectoryInfo(folderLink);
            try
            {
                foreach (var fi in diTop.EnumerateFiles())
                {
                    string leer = @"\";
                    System.IO.File.Copy(fi.FullName, moveTo + leer + fi.Name, true);
                }
            }
            catch (UnauthorizedAccessException UnAuthTop)
            {
                Console.WriteLine("{0}", UnAuthTop.Message);

            }
            Console.WriteLine("OK");

            Console.ReadLine();
        }
   }
}
