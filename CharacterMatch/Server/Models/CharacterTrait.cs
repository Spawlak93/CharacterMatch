using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterMatch.Server.Models
{
    public class CharacterTrait
    {
        public int CharacterId { get; set; }

        public int TraitId { get; set;}

        public virtual Character Character { get; set; }

        public virtual Trait Trait { get; set; }

        [Range(0,5)]
        public int Value { get; set; }
    }
}
