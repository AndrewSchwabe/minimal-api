var builder = WebApplication.CreateBuilder(args);

// Register the required services for Swagger and Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger and SwaggerUI
app.UseSwagger();
app.UseSwaggerUI();

// Adding a default route greet the user
app.MapGet("/", () =>  Results.Ok(new { Message = "Welcome to your phonebook!"}));

app.Run();
