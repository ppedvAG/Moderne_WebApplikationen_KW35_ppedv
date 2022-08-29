namespace _004_ISP_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IVehicle
    {
        void Fly();
        void Swimm();
        void Drive();
    }

    public class MultiVehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("fahren");
        }

        public void Fly()
        {
            Console.WriteLine("fliegen");
        }

        public void Swimm()
        {
            Console.WriteLine("schwimmen");
        }
    }

    public class BadAmphipischesFahrzeug : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("fahren");
        }

        public void Swimm()
        {
            Console.WriteLine("schwimmen");
        }


        //Leer-Implementierung
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }

    //Bessere Variante

    public interface IFly
    {
        void Fly();
    }

    public interface ISwim
    {
        void Swimm();   
    }

    public interface IDrive
    {
        void Drive();
    }

    public class AmphibischesFahrzeug : ISwim, IDrive //Es können mehrere Interfaces eingesetzt werden 
    {
        public void Drive()
        {
            Console.WriteLine("fährt");
        }

        public void Swimm()
        {
            Console.WriteLine("schwimmt");
        }
    }
}
