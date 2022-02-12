using System.ComponentModel.DataAnnotations;

public class Person
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}