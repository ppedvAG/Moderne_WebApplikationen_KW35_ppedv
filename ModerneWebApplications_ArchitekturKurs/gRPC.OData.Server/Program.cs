using gRPC.OData.Server.Data;
using gRPC.OData.Server.Models;
using gRPC.OData.Server.Services;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IShelfBookRepository, ShelfBookInMemoryRepository>();
builder.Services.AddControllers().AddOData( opt => {
    opt.EnableQueryFeatures().AddRouteComponents("odata", EdmModelBuilder.GetEdmModel());
});
builder.Services.AddGrpc();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGrpcService<BookstoreService>();

app.MapControllers();

app.Run();
