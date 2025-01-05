using System.ComponentModel.DataAnnotations;

namespace Games.Models;

public class Publisher
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public ICollection<Game> Game { get; set; } = null!;
}

public class PublisherDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public ICollection<GameDto> Games { get; set; } = null!;
}