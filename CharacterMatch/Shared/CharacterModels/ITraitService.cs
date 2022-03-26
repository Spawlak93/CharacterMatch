using CharacterMatch.Shared.TraitModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.TraitServices
{
    public interface ITraitService
    {
        Task<IEnumerable<TraitListItem>> GetAllSeriesAsync();
        Task<TraitDetail> GetSeriesByIdAsync(int traitId);
        Task<bool> CreateSeriesAsync(TraitCreate model);
        Task<bool> UpdateSeriesAsync(TraitUpdate model);
        Task<bool> DeleteSeriesAsync(int traitId);
    }
}
