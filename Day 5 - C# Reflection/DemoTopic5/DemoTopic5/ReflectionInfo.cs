using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTopic5
{
    [Custom]
    public class ReflectionInfo
    {
        [Custom]
        private int _id;
        private string _name;

        [Custom]
        public int PublicId;
        public string PublicName;

        [Custom]
        public ReflectionInfo()
        {

        }
        public ReflectionInfo(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Custom]
        public void Write()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
        }

        public void Write(string name)
        {
            Console.WriteLine("Name: " + name);
        }
    }
}
