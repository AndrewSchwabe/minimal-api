using Microsoft.EntityFrameworkCore;

public class PersonRepository : DbContext
{
    public PersonRepository(DbContextOptions<PersonRepository> options)
    : base(options) { }

    public DbSet<Person> Persons => Set<Person>();
}