var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
honkai_wiki_api.Data.HonkaiContext.conString = builder.Configuration.GetConnectionString("Akali");

var app = builder.Build();

honkai_wiki_api.Services.ValkyrieService valkyrieService = new();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/valkyries", async () =>
{
    var valkyries = await valkyrieService.GetValkyriesAsync();
    return valkyries;
});

app.Run();
