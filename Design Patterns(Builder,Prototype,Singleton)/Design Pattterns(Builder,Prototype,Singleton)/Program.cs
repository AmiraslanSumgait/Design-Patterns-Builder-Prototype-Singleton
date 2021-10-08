using System;

namespace BuilderPattern
{
    class Car
    {
        public int Seats { get; set; }
        public double Engine { get; set; }
        public bool TripComputer { get; set; }
        public string Gps { get; set; }
        public override string ToString() => @$"
        Seats count: {Seats}
        Engine: {Engine}
        Trip Computer: {TripComputer}
        Gps: {Gps}";
    }

    interface IBuilder
    {
        public Car Car { get; set; }
        IBuilder SetSeats(int seats);
        IBuilder SetEngine(double engine);
        IBuilder SetTripComputer(bool tripComputer);
        IBuilder SetGps(string gps);
        IBuilder Reset();
        Car GetResult();
    }
    class Master
    {
        private IBuilder _builder;
        public Master(IBuilder buiilder)
        {
            _builder = buiilder;
        }
        public void ChangeBuilder(IBuilder builder)
        {
            _builder = builder;
        }
        public Car Make(int price)
        {
            _builder.Reset();

            if (price > 5000)
            {
                return _builder
                    .SetSeats(6)
                    .SetGps("Satellite-based")
                    .SetEngine(2.0)
                    .SetTripComputer(false)
                    .GetResult();

            }
            else if (price > 20000)
            {
                return _builder
                    .SetSeats(6)
                    .SetGps("Satellite-based")
                    .SetEngine(4.0)
                    .SetTripComputer(true)
                    .GetResult();
            }


            throw new Exception("Not found");
        }
    }
    class AutomaticCarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car();

        public Car GetResult() => Car;

        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }
        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGps(string gps)
        {
            Car.Gps = gps;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer(bool tripComputer)
        {
            Car.TripComputer = tripComputer;
            return this;
        }
    }
    class ManualCarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car();

        public Car GetResult() => Car;

        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }
        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGps(string gps)
        {
            Car.Gps = gps;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer(bool tripComputer)
        {
            Car.TripComputer = tripComputer;
            return this;
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new AutomaticCarBuilder();
            Car automaticCar = builder.SetEngine(5.4).SetGps("Spytec GPS GL300").GetResult();
            Console.WriteLine(automaticCar);

            IBuilder builder1 = new ManualCarBuilder();
            Master master=new Master(builder);
            Car car = master.Make(10000);
            Console.WriteLine(car);

        }
    }
}
