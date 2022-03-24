using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterMatch.Server.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

    }
}
