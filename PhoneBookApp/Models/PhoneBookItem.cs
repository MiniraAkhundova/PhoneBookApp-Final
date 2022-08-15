using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Models;

public class PhoneBookItem
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(255, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Phone]
    public string PhoneNumber { get; set; } = null!;

    public DateTime AdditionDate { get; set; }
}
