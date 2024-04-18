using Lab10.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your ApplicationContext here
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

ApplicationContext context = new ApplicationContext();
context.Database.EnsureCreated();

// Register your repositories here
builder.Services.AddTransient<IBaseRepository<Animal>, BaseRepository<Animal>>();
builder.Services.AddTransient<IBaseRepository<Aviary>, BaseRepository<Aviary>>();



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