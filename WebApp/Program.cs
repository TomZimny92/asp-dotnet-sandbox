using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});

app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));
app.MapGet("/", () => "Hello World! ");
app.MapGet("about/", () => "Established in 1914");



app.Run();
