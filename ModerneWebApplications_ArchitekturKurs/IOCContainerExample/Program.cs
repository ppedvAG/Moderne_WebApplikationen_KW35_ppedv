using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Was ist ein IOC Container?
            //Services und auch Klassen, werden in einem IOC Container abgelegt und sind im weiteren Programmverlauf verfügbar 

            //Was wird in einem IOC Container hinzugefügt?
            //-Services (ILogger<T> oder IDBContextFactory, DbContext<T> usw. aber auch einfache Klassen-Objekte (nicht die beste Wahl). 

            //Gibt es Problemstellungen in unserem IOC Container? Und wie löse ich diese. 

            //Welche Strukturen 




            #region ServiceCollection / ServiceProvider
            
            
            //Sammelt alle Dienste und Objekte -> Wird im Initialisierungphase verwendet 
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICar, MockCar>();


            //services.BuildServiceProvider(); -> Ab hier ist die Initialisierungsphase zuende!
            IServiceProvider serviceProvider = services.BuildServiceProvider();


            //Danach können wir nur noch auf die Dienste zugreifen, die im IOC-Container verfügbar sind. 
            //Zugriff auf den IOC - Container: 

            //Variante -> GetService: Wenn ein Service im IOC Container nicht gefunden wird, wird NULL zurückgegeben 
            IDateTimeService? dateTimeService = serviceProvider.GetService<IDateTimeService>();  

            //Variante -> GetRequiredService: Wenn ein Service im IOC Container nicht gefunden wird, wird eine Exception geworfen (Dieser wird in ASP.NET Core verwendet) 

            IDateTimeService dateTimeService2 = serviceProvider.GetRequiredService<IDateTimeService>();
            #endregion

            #region Singleton / Scoped / Transient 

            ServiceCollection secondServiceCollection = new ServiceCollection();
            secondServiceCollection.AddTransient<IDateTimeService, DateTimeService>();

            //Service ist als Singleton registriert und wird nur einmalig instanziiert (Konstruktor wird nur einmal aufgerufen) 
            //Singleton hat ein Vorteil -> Wenn wir ein Service verwenden, mit großen Initialisierungsaufwand, wäre dieser als Singleton performanter, als 
            //bei Scope oder Transient 

            //Service als Scope zu registrieren sind Services, die pro Request einmal instanziiert werden. 
            //Use Cases -> EF verwendet im Befehl AddDbContext -> AddScope 

            
            
            IDateTimeService dateTimeService1 = serviceProvider.GetRequiredService<IDateTimeService>();
            Console.WriteLine(dateTimeService1.GetCurrentTime());

            Task.Delay(5000).Wait();

            dateTimeService1 = serviceProvider.GetRequiredService<IDateTimeService>();
            Console.WriteLine(dateTimeService1.GetCurrentTime());

            //IOC Conainer wurde für ASP.NET Core entwickelt und erzielt in einer Konsolen-Anwendung weniger einen Effekt. 
            #endregion


            #region Probleme mit IOC

            #region Problem
            //Ich verwende hier ein Objekt und kein Service, damit ich anhand der Car-Variablen sehe,
            //welches Objekt gerade gilt und welches überschrieben wurde 

            IServiceCollection services1 = new ServiceCollection();
            services1.AddSingleton<ICar, MockCar>();
            services1.AddSingleton<ICar, Car>(); //Car überschreibt den Eintrag von MockCar


            IServiceProvider serviceProvider1 = services1.BuildServiceProvider();

            //MockCar oder Car? 
            ICar? car = serviceProvider1.GetService<ICar>();
            #endregion





            #region Lösung

            IServiceCollection services2 = new ServiceCollection();
            services2.AddScoped<IScopeCar, MySecondCar>();
            services2.AddSingleton<ISingletonCar, MyCar>();
            
            
            IServiceProvider serviceProvider2 = services2.BuildServiceProvider();

            IScopeCar? car1 = serviceProvider2.GetService<IScopeCar>();
            ISingletonCar? car2 = serviceProvider2.GetService<ISingletonCar>();

            #endregion


            #region Weitere Lösungen

            //Enumerable Lösung:
            //- https://www.infoworld.com/article/3597989/use-multiple-implementations-of-an-interface-in-aspnet-core.html
            //- https://www.alwaysdeveloping.net/p/multiple-implementations/

            // Generischer Ansatz: Weitere sehr zu empfehldende Lösung: 
            // https://dejanstojanovic.net/aspnet/2018/december/registering-multiple-implementations-of-the-same-interface-in-aspnet-core/
            #endregion

            #endregion



        }
    }



    //ICar <-> MockCar + ICar <-> Car
    #region Lösung wir man Multiple implementierungen zu einem Interface in einem IOC verwenden kann 
    public interface ISingletonCar : ICar
    {

    }

    public interface IScopeCar : ICar
    {

    }

    public interface ITransient : ICar
    {

    }

    public class MyCar : ISingletonCar
    {
        public int Id { get; set; } = 123;
        public string Brand { get; set; } = "Porsche";
        public string Model { get; set; } = "311";
        public int PS { get; set; } = 350;
    }

    public class MySecondCar : IScopeCar
    {
        public int Id { get; set; } = 456;
        public string Brand { get; set; } = "Mercedez";
        public string Model { get; set; } = "E-Klasse";
        public int PS { get; set; } = 360;
    }
    #endregion

    public interface ICar
    {
        int Id { get; set; }
        string Brand { get; set; }
        string Model { get; set; }

        int PS { get; set; }

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
        public int PS { get; set; }
    }

    //Programmierer B: Tag 1-3 
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            Console.WriteLine("Repariere Auto");
        }
    }

    //Weiterer Vorteil gegenüber Feste Kopplung
    public class MockCar : ICar
    {
        public int Id { get; set; } = 1;
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "POLO";
        public int PS { get; set; } = 123;
    }


    public interface IDateTimeService
    {
        public string GetCurrentTime();
    }

    public class DateTimeService : IDateTimeService
    {
        private DateTime dateTime;

        public DateTimeService()
        {
            dateTime = DateTime.Now;
        }
        public string GetCurrentTime()
        {
            return dateTime.ToString();
        }
    }
}