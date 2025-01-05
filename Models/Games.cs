using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Models;

public class Game
{
    public int Id { get; set; }
    [Required]
    public string GameTitle { get; set; } = null!;
    [Required]
    public string ReleaseYear { get; set; } = null!;
    [Required]
    public List<string> Developers { get; set; } = null!;
    [ForeignKey("PublisherId")]
    public Publisher Publisher { get; set; } = null!;
    public int PublisherId { get; set; }
    public decimal? Revenue { get; set; }
}

public class GameDto
{
    public int Id { get; set; }
    [Required]
    public string GameTitle { get; set; } = null!;
    [Required]
    public string ReleaseYear { get; set; } = null!;
    [Required]
    public List<string> Developers { get; set; } = null!;
    [Required]
    public string PublisherName = null!;
    public decimal? Revenue { get; set; }
}