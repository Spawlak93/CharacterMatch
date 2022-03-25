using CharacterMatch.Shared.SeriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.CharacterModels
{
    public class CharacterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public SeriesListItem Series { get; set; }

        public ICollection<CharacterTraitModels.CharactersTraitListItem> Traits { get; set; }   = new List<CharacterTraitModels.CharactersTraitListItem>();
    }
}
