using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.ResultModels
{
    public class QuizCharacterResult
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int SeriesId { get; set; }
        public int LikenessScore { get; set; }
    }
}
