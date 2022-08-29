using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerWithAutofac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IServiceCollection serviceCollection = new ServiceCollection();
            //serviceCollection.AddSingleton<ICar, MockCar>();

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MockCar>().As<ICar>();

            //IServiceProvider provider = serviceCollection.Build()
            IContainer container = builder.Build();

            //Resolve anstatt GetService oder GetRequiredService 
            ICar resolvedCar = container.Resolve<ICar>();


        }
    }



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
}