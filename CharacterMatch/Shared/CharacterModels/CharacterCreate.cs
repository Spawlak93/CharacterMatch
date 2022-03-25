using CharacterMatch.Shared.CharacterTraitModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.CharacterModels
{
    public class CharacterCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeriesId { get; set; }

        public string ImgUrl { get; set; }

        //Collection of Character traits to give them traits on create.
        //public ICollection<AddTraitToCharacter> TraitsToAdd { get; set; } = new List<AddTraitToCharacter>();
    }
}
