using CharacterMatch.Shared.SeriesModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.SeriesServices
{
    public interface ISeriesService
    {
        Task<IEnumerable<SeriesListItem>> GetAllSeriesAsync();
        Task<SeriesDetail> GetSeriesByIdAsync(int seriesId);
        Task<bool> CreateSeriesAsync(SeriesCreate model);
        Task<bool> UpdateSeriesAsync(SeriesUpdate model);
        Task<bool> DeleteSeriesAsync(int seriesId);

    }
}
