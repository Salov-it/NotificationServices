using NotificationServices.Application.Dependencyinjection;
using Postgres.Application;
using Postgres.Application.Context;

var builder = WebApplication.CreateBuilder(args);

//������ ���� ������
builder.Services.AddPostgresApplication(builder.Configuration);

builder.Services.AddNotificationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �������� ���� ������ ��� ������� ����������
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PostgresContext>();
    context.CreateDatabaseIfNotExists(); // ����� ������ ��� �������� ���� ������
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
