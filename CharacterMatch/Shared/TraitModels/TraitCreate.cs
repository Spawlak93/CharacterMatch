using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMatch.Shared.TraitModels
{
    public class TraitCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
