using System;

namespace Prototype_Pattern
{
    interface IPrototype
    {
        IPrototype Clone();
    }
    class Computer : IPrototype
    {
        public int Ram { get; set; }
        public bool Ssd { get; set; }
        public int HddSize { get; set; }
        public string Processor { get; set; }
        public Computer()
        {

        }
        public Computer(Computer prototype)
        {
            Ram = prototype.Ram;
            Ssd = prototype.Ssd;
            HddSize = prototype.HddSize;
            Processor = prototype.Processor;
        }
        public IPrototype Clone() => new Computer(this);
        public override string ToString() => @$"
       Ram: {Ram}
       Ssd: {Ssd}
       HddSize: {HddSize}
       Processor: {Processor}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer { Processor = "Intel Core i7", HddSize = 1024, Ssd = true, Ram = 16 };
            Computer copyComputer = computer.Clone() as Computer;
            computer.Ram = 32;
            Console.WriteLine(computer);
            Console.WriteLine(copyComputer);
        }
    }
}
