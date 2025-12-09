using Microsoft.Extensions.Options;
using NewsAPI.Services;
using NewsAPI.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    lambda =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        lambda.IncludeXmlComments(xmlPath);
    }
);

builder.Services.AddSingleton<IAnnouncementCollectionService, AnnouncementCollectionService>();
builder.Services.Configure<MongoDBSettings>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
    builder.Services.Configure<MongoDBSettings>(options =>
    {
        // Connection string is loaded from the environment:
        // PowerShell: echo $Env:MONGO_CONNECTION_STRING
        // To set the MongoDB connection string environment variable:
        // PowerShell:  setx MONGO_CONNECTION_STRING "the-connection-string"
        var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("MONGO_CONNECTION_STRING environment variable is not set.");
        }

        options.ConnectionString = connectionString;

        var databaseName = builder.Configuration["MongoDBSettings:DatabaseName"];
        if (string.IsNullOrEmpty(databaseName))
        {
            throw new InvalidOperationException("MongoDBSettings:DatabaseName configuration is not set.");
        }

        options.DatabaseName = databaseName;
    });
});
builder.Services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
                              policy =>
                              {
                                  policy.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials();
                              });
});

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Announcements Api");
    });
}



app.UseCors("CorsPolicy");

app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.Zero,
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapHub<NotificationsHub>("/hub/notifications");

app.MapControllers();

app.Run();
