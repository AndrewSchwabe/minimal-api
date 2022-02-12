using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register the required services for Swagger and Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the Person repository
builder.Services.AddDbContext<PersonRepository>(options => options.UseInMemoryDatabase("PersonRepository"));

var app = builder.Build();

// Configure Swagger and SwaggerUI
app.UseSwagger();
app.UseSwaggerUI();

// Adding a default route greet the user
app.MapGet("/", () => Results.Ok(new { Message = "Welcome to the person API!"}));

// Route to fetch a single person by id
app.MapGet("/person/{id}", async (Guid id, PersonRepository repo) => Results.Ok(await repo.Persons.FirstOrDefaultAsync(p => p.Id == id)));

// Route to fetch all people
app.MapGet("/person", async (PersonRepository repo) => Results.Ok(await repo.Persons.ToListAsync()));

// Route to create new person
app.MapPost("/person", async (Person person, PersonRepository repo) =>
{
    if (person == null)
        Results.BadRequest();
    await repo.Persons.AddAsync(person);
    await repo.SaveChangesAsync();
    Results.Ok();
});

app.Run();