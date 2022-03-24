using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterMatch.Server.Models
{
    public class Trait
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Name { get; set;}
        public virtual ICollection<CharacterTrait> Characters { get; set; } = new List<CharacterTrait>();

    }
}
