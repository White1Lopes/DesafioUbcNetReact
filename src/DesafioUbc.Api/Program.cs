using DesafioUbc.Api.Startup;
using DesafioUbc.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationDbContext();
builder.Services.AddIoc();
builder.Services.AddAuthorizationConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDocumentConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Seed();

app.Run();