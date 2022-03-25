using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.SeriesModels
{
    public class SeriesDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<CharacterModels.CharacterListItem> Characters { get; set; } = new List<CharacterModels.CharacterListItem>();
    }
}
