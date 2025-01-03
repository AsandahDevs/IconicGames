using System.ComponentModel.DataAnnotations;

namespace Games.Models;

public class Game {
    public int Id {get;set;}
    [Required]
    public string GameTitle {get;set;} = null!;
    [Required]
    public string ReleaseYear {get;set;} = null!;
    [Required]
    public List<string> Developers {get;set;} = null!;
    [Required]
    public string Publisher {get;set;} = null!;
    public decimal? Revenue {get;set;}
}