using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalAPITutorial;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
async Task<List<SuperHero>> GetAllHeroes(DataContext context) =>
    await context.SuperHeroes.ToListAsync();
app.MapGet("/",() => "welcome to super hero");
app.MapGet("/superhero", async(DataContext context)=>
    await context.SuperHeroes.ToListAsync());
app.MapGet("/superhero/{id}", async(DataContext context, int id)=>
    await context.SuperHeroes.FindAsync(id) is SuperHero hero ?
        Results.Ok(hero):
            Results.NotFound("sorry,hero not found :/"));
app.MapPost("/superhero", async (DataContext context, SuperHero hero) =>
{
    context.SuperHeroes.Add(hero);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllHeroes(context));

});
app.MapPut("/superhero/{id}", async(DataContext context, SuperHero hero, int id)=>
{
    var dbhero = await context.SuperHeroes.FindAsync(id);
    if (dbhero == null)
        return Results.NotFound("No hero found :/");
    dbhero.Firstname = hero.Firstname;
    dbhero.Lastname = hero.Lastname;
    dbhero.Heroname = hero.Heroname;
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllHeroes(context));
});

app.MapDelete("/superhero/{id}", async (DataContext context, int id) =>
{
    var dbhero = await context.SuperHeroes.FindAsync(id);
    if (dbhero == null)
        return Results.NotFound("?????");
           context.SuperHeroes.Remove(dbhero);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllHeroes(context));
});

app.Run();

