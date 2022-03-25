using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.SeriesModels
{
    public class SeriesCreate
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
