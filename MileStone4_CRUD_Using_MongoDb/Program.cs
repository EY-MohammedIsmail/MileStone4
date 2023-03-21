using MileStone4_CRUD_Using_MongoDb.DataAccess;
using MileStone4_CRUD_Using_MongoDb.Models;
using MileStone4_CRUD_Using_MongoDb.Repository;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ProductsDatabaseSettings>(builder.Configuration.GetSection("ProductsDatabase"));
builder.Services.AddSingleton<ProductRepo>();
builder.Services.AddSingleton<IProduct,ProductRepo>();
builder.Services.AddMediatR(typeof(ProductRepo).Assembly);

//CORS implementation
builder.Services.AddCors(options =>
{
    options.AddPolicy("angular", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("angular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
