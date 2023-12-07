using Microsoft.AspNetCore.Diagnostics;
using Microsoft.VisualBasic;
using Spotify.API.ErrosHandling;
using System.Diagnostics.Eventing.Reader;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;


    if (exception is Spotify.Core.Exception.BussinesException businessException)
    {
        var errorResponse = new ErrosHandling();

        foreach (var item in businessException.Erros)
            errorResponse.Erros.Add(new ErroeMessagem() { campo = item.NomeErroDefaul, Mensagem = item.MensagemErro });

        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(errorResponse);
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { Error = exception?.Message });
    }

}));

app.MapControllers();

app.Run();
