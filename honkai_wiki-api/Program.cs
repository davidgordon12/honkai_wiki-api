using honkai_wiki_api.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

honkai_wiki_api.Data.HonkaiContext.conString = builder.Configuration.GetConnectionString("Akali");

var origin = "_origin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: origin,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7012", 
                                                "https://localhost:44304",
                                                    "https://roaring-palace.azurewebsites.net");
                      });
});

var app = builder.Build();

ValkyrieService valkyrieService = new();
BattlesuitService battlesuitService = new();
WeaponService weaponService = new();
StigmataService stigmataService = new();

// always use swagger
app.UseSwagger();
app.UseSwaggerUI();

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
    var battlesuits = await battlesuitService.GetAsync();
    return Results.Ok(battlesuits);
});

app.MapGet("/battlesuit/{id}", async (int id) =>
{
    var battlesuit = await battlesuitService.GetAsync(id);
    return Results.Ok(battlesuit);
});

app.MapGet("/weapons", async () =>
{
    var weapons = await weaponService.GetAsync();
    return Results.Ok(weapons);
});

app.MapGet("/weapon/{id}", async (int id) =>
{
    var weapon = await weaponService.GetAsync(id);
    return Results.Ok(weapon);
});

app.MapGet("/stigmatas", async () =>
{
    var stigmatas = await stigmataService.GetAsync();
    return Results.Ok(stigmatas);
});

app.MapGet("/stigmata/{id}", async (int id) =>
{
    var stigmata = await stigmataService.GetAsync(id);
    return Results.Ok(stigmata);
});

app.Run();