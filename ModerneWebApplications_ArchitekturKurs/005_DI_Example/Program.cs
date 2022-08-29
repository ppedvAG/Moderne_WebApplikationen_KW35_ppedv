namespace _005_DI_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region BadCar + BadCarService
    //Wir sehen hier eine Feste Kopplung -> BadCarService -> Repair (BadCar car) 
    //Warum eine Feste-Kopllung? -> Klasse BadCarService.Repair kennt die Klasse BadCar
    
    //Negative Eigentschaften einer Festen-Kopplung:
    //   -  Programmierer müssen auf Implementierung wir z.b BadCar warten, damit diese in Repair als Parameter verwendet werden können
    //   -  Wechselwirkungen entstehen, wenn BadCar seine Properties umbenennt (Brand->Marke oder Model zu Modell), müssen in der Methode Repair auch die Paramter angepasst werden) 
    //Programmierer A: Benötigt 5 Tage (Tag 1 bis Tag 5) 
    public class BadCar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PS { get; set; }
    }


    //Programmierer B: Benötigt 3 Tage (Tag 5/6 bis 8/9)
    public class BadCarService
    {

        public void Repair (BadCar car) 
            => Console.WriteLine("Auto wird repariert");
    }
    #endregion

    #region Bessere Variante -> DI 

    //Programmierer A und B haben eine Spezifikation und erstellen auf Basis auf derer wie die Lösung umrißen werden muss
    public interface ICar
    {
        int Id { get; set; }
        string Brand { get; set; }
        string Model { get; set; }

        string PS { get; set; }
        
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }


    //Programmierer A: Tag 1-5
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PS { get; set; }
    }

    //Programmierer B: Tag 1-3 
    public class ClassService : ICarService
    {
        public void Repair(ICar car)
        {
            Console.WriteLine("Repariere Auto");
        }
    }

    //Weiterer Vorteil gegenüber Feste Kopplung
    public class MockCar : ICar
    {

    }
    #endregion
}