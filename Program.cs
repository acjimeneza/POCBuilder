using pocBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add configuration oftions
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()+"/Configuration")
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange:true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");


// Created services by scope

builder.Services.AddSingleton<ILoggerTest>( provider => new GeneralLogger(builder.Configuration, provider.GetRequiredService<ILogger<GeneralLogger>>()));

builder.Services.AddControllers();

// Add services to the container.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
