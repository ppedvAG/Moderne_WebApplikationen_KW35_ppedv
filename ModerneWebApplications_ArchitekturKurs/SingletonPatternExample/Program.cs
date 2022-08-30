using System;
namespace SingletonPatternEx
{
    //Warum verwenden eine Singleton-Klasse -> sealed? 

    // 
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private int numberOfInstances = 0;
        //Private constructor is used to prevent
        //creation of instances with 'new' keyword outside this class
        private Singleton()
        {
            Console.WriteLine("Instantiating inside the private constructor.");
            numberOfInstances++;
            Console.WriteLine("Number of instances ={0}", numberOfInstances);
        }
        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("We already have an instance now.Use it.");
                return instance;
            }
        }
    }
    


    public sealed class Singleton2
    {
        private static Singleton2 instance;
        private Singleton2() { }

        public static Singleton2 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton2();
                }
                return instance;
            }
        }
    }

    public sealed class Singleton3
    {
         //We are using volatile to ensure that
         //assignment to the instance variable finishes before it’s 
        //access.

        private static volatile Singleton3 instance;
        private static object lockObject = new Object();
        
        private Singleton3() { }
        
        public static Singleton3 Instance
        {

            get
            {
                if (instance == null)
                {
                    //threads können diesen Code-Block parallel ausführen. -> Mit lock wird das verhindert 
                    lock (lockObject)
                    {
                        if (instance == null)
                            instance = new Singleton3();
                    }
                }
                return instance;
            }
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Pattern Demo***\n");
            //Console.WriteLine(Singleton.MyInt);
            // Private Constructor.So,we cannot use 'new' keyword. 
            Console.WriteLine("Trying to create instance s1.");
            Singleton s1 = Singleton.Instance;
            Console.WriteLine("Trying to create instance s2.");
            Singleton s2 = Singleton.Instance;
            if (s1 == s2)
            {
                Console.WriteLine("Only one instance exists.");
            }
            else
            {
                Console.WriteLine("Different instances exist.");
            }
            Console.Read();
        }
    }
}