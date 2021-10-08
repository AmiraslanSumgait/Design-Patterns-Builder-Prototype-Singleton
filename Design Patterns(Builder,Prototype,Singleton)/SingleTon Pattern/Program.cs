using System;

namespace SingleTon_Pattern
{
    public sealed class Singleton
    {
        private static volatile Singleton _instance = null;
        private static object _syncRoot = new Object();
        public string Name { get; set; }
        public string Surname { get; set; }
        /// <summary>
        /// Constructor must be private.
        /// </summary>
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new Singleton {  Name="Amiraslan",Surname="Aliyev"};
                    }
                }
                return _instance;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Console.WriteLine(s1.Name);
        }
    }
}
