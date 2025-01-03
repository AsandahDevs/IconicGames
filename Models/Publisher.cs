using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Models;

public class Publisher {
    public int Id {get;set;}
    [Required]
    public string Name {get;set;} = null!;
    [ForeignKey("GameId")]
    public ICollection<Game> Game {get;set;} = null!;
    public int GameId {get;set;}
}