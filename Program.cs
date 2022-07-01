using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("people.xml");
            var people = xml.Descendants("person");
            var qualificationId = people.SelectMany(person => person.Elements("teacher"))
                                        .SelectMany(teacher => teacher.Elements("qualifications"))
                                        .SelectMany(qualifications => qualifications.Elements("qualification"))
                                        .Select(qualification => qualification.Element("id").Value);
            var uniqueQualificationId = qualificationId.Distinct();
            foreach (var item in uniqueQualificationId)
            {
                Console.WriteLine(item);
            }
        }
    }
}
