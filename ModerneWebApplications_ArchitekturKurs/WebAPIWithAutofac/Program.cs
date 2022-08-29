using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace WebAPIWithAutofac
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                //Show-Case -> registrieren eines Autofac-Container in ASP.NET Core 
                builder.RegisterType<MockCar>().As<ICar>().SingleInstance();
                //builder.RegisterType<MockCar>().As<ICar>().InstancePerLifetimeScope();
                //builder.RegisterType<MockCar>().As<ICar>().OwnedByLifetimeScope();
                //builder.RegisterType<MockCar>().As<ICar>().InstancePerDependency();
                //builder.RegisterType<MockCar>().As<ICar>().InstancePerMatchingLifetimeScope();
                //builder.RegisterType<MockCar>().As<ICar>().InstancePerOwned();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
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