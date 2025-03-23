using HRPortal.Application.Extensions;
using HRPortal.DTO.Extensions;
using HRPortal.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region PersistenceExtensions
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddGenericRepositoryPatternExtension();
builder.Services.AddRepositoriesExtension();
builder.Services.AddUnitOfWorkExtension();
#endregion

#region DTOExtensions
builder.Services.AddMapsterExtension();
#endregion

#region ApplicationExtension
builder.Services.AddMediatorExtension();
builder.Services.AddFluentValidationExtension();
#endregion

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
