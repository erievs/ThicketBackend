
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using ShittyVineRI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery();

builder.Services.AddDbContext<ShittyVineRIDb>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddMvcCore();

// to create db on your other machine
// https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli


builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "ShittyVineRI";
    config.Title = "ShittyVineRI v1";
    config.Version = "v1";
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

var app = builder.Build();


app.UseHttpLogging();

app.UseOpenApi();

app.UseSwaggerUi(config =>
{
    config.DocumentTitle = "TodoAPI";
    config.Path = "/swagger";
    config.DocumentPath = "/swagger/{documentName}/swagger.json";
    config.DocExpansion = "list";
});

// all static because why not

TimeLine.TimeLineGraph(app);

AccountStuff.Registration(app);

AccountStuff.SignIn(app);

UploadHandler.HandleVineUploads(app);

UploadHandler.HandleThumbnailUploads(app);

UploadHandler.HandlePostingVideos(app);

FileDeliveryStuff.VideoDeliveryService(app);

FileDeliveryStuff.ThumbnailDeliveryService(app);





app.Run();