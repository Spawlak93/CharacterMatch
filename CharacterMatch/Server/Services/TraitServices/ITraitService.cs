using CharacterMatch.Shared.TraitModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.TraitServices
{
    public interface ITraitService
    {
        Task<IEnumerable<TraitListItem>> GetAllTraitsAsync();
        Task<TraitDetail> GetTraitByIdAsync(int traitId);
        Task<bool> CreateTraitAsync(TraitCreate model);
        Task<bool> UpdateTraitAsync(TraitUpdate model);
        Task<bool> DeleteTraitAsync(int traitId);
    }
}
