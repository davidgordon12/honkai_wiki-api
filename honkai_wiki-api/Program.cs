var origin = "_origin";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
honkai_wiki_api.Data.HonkaiContext.conString = builder.Configuration.GetConnectionString("Akali");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: origin,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44304");
                      });
});

var app = builder.Build();

honkai_wiki_api.Services.ValkyrieService valkyrieService = new();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(origin);
app.UseHttpsRedirection();

app.MapGet("/valkyries", async () =>
{
    var valkyries = await valkyrieService.GetValkyriesAsync();
    return Results.Ok(valkyries);
});

app.MapGet("/valkyrie/{id}", async (int id) =>
{
    var valkyrie = await valkyrieService.GetValkyrieAsync(id);
    return Results.Ok(valkyrie);
});

app.Run();
