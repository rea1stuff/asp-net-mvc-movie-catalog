var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

ConfigureMiddlewares();

app.Run();



void ConfigureServices()
{
    
}

void ConfigureMiddlewares()
{
    
}