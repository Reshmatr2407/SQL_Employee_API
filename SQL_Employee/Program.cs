
using DataAccess.Models;
using SQL_Employee;

var builder = WebApplication.CreateBuilder(args);

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin() // Allow any origin
               .AllowAnyMethod() // Allow any HTTP method (GET, POST, etc.)
               .AllowAnyHeader(); // Allow any header
    });
});

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddTransient<EmployeeModuleService>();
//builder.Services.AddTransient<EmployeeRepo>();

builder.Services.AddTransient<EmployeeModel>();


builder.Services.AddTransient<DataContext>();

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
app.UseRouting(); // Ensure routing is used before CORS

app.UseCors("MyPolicy"); // Use the CORS policy defined above

app.UseAuthorization();

app.MapControllers();

app.Run();
