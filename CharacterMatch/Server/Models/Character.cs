using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterMatch.Server.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        [ForeignKey(nameof(Series))]
        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }

        public virtual ICollection<CharacterTrait> Traits { get; set; }= new List<CharacterTrait>();
    }
}
