using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.CharacterModels
{
    public class CharacterUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int SeriesId { get; set; }

        //maybe include updating the trait values
    }
}
