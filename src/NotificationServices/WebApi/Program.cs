using NotificationServices.Application.Dependencyinjection;
using Postgres.Application;
using Postgres.Application.Context;

var builder = WebApplication.CreateBuilder(args);

//Сервис базы данных
builder.Services.AddPostgresApplication(builder.Configuration);

builder.Services.AddNotificationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Создание базы данных при запуске приложения
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PostgresContext>();
    context.CreateDatabaseIfNotExists(); // Вызов метода для создания базы данных
}

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
