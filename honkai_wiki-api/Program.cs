using honkai_wiki_api.Services;
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

ValkyrieService valkyrieService = new();
ValkyrieService battlesuitService = new();
ValkyrieService weaponService = new();
ValkyrieService stigmataService = new();

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
    var valkyries = await valkyrieService.GetAsync();
    return Results.Ok(valkyries);
});

app.MapGet("/valkyrie/{id}", async (int id) =>
{
    var valkyrie = await valkyrieService.GetAsync(id);
    return Results.Ok(valkyrie);
});

app.MapGet("/battlesuits", async () =>
{
    var battlesuits = battlesuitService.GetAsync();
    return Results.Ok(battlesuits);
});

app.MapGet("/battlesuit/{id}", async (int id) =>
{
    var battlesuit = battlesuitService.GetAsync(id);
    return Results.Ok(battlesuit);
});

app.MapGet("/weapons", async () =>
{
    var weapons = weaponService.GetAsync();
    return Results.Ok(weapons);
});

app.MapGet("/weapon/{id}", async (int id) =>
{
    var weapon = weaponService.GetAsync(id);
    return Results.Ok(weapon);
});

app.MapGet("/stigmatas", async () =>
{
    var stigmatas = stigmataService.GetAsync();
    return Results.Ok(stigmatas);
});

app.MapGet("/stigmata/{id}", async (int id) =>
{
    var stigmata = stigmataService.GetAsync(id);
    return Results.Ok(stigmata);
});

app.Run();