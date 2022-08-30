using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAPISample.Data;

//.NET 5 auf .NET 6 WebApplication + WebApplicationBuilder stellen einen Breaking Change da

//Verbesserungen zu .NET 5: 
//Laden von unterschiedlichen Konfigurations-Quellen wurde beschleunigt. In .NET 5 wurde IConfiguration mehrmals aufgebaut (bei jeden neuen Konfigurationsquelle) 
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//.NET 5 auf .NET 6 WebApplication + WebApplicationBuilder stellen einen Breaking Change da

//Verbesserungen zu .NET 5: 
//Laden von unterschiedlichen Konfigurations-Quellen wurde beschleunigt. In .NET 5 wurde IConfiguration mehrmals aufgebaut (bei jeden neuen Konfigurationsquelle) 
builder.Services.AddDbContext<MovieDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbContext") ??
        throw new InvalidOperationException("Connection string 'MovieDbContext' not found."));
});

//.NET 5 auf .NET 6 WebApplication + WebApplicationBuilder stellen einen Breaking Change da

//Verbesserungen zu .NET 5: 
//Laden von unterschiedlichen Konfigurations-Quellen wurde beschleunigt. In .NET 5 wurde IConfiguration mehrmals aufgebaut (bei jeden neuen Konfigurationsquelle) 


//In wie weit ist .NET 6 Abw�rtskompatibel?

//.NET 3.0 bis 5.0
//builder.Host -> IHostBuilder
//builder.Host = CreateHostBuilder(....);


//.NET 2.1
//builder.WebHost -> IWebHostBuilder


// Add services to the container.
#region In .NET 5 w�re das -> public void ConfigureServices(IServiceCollection services)
builder.Services.AddControllers(); //Controller-Klasse f�r WebAPI 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Swagger zum Testen der WebAPI 
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
WebApplication app = builder.Build();
#endregion


#region In .NET w�re das -> public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); //Eine Anfrage findet die richtige Controller-Klasse und Action-Methoden 
#endregion

app.Run();
