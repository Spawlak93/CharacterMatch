
using CharacterMatch.Server.Data;
using CharacterMatch.Server.Models;
using CharacterMatch.Shared.SeriesModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.SeriesServices
{
    public class SeriesService : ISeriesService
    {
        private readonly ApplicationDbContext _ctx;
        public SeriesService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public async Task<bool> CreateSeriesAsync(SeriesCreate model)
        {
            var entity = new Series
            {
                Name = model.Name,
                Description = model.Description,
                ImgUrl = model.ImgUrl,
            };
            _ctx.Series.Add(entity);
            return await _ctx.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteSeriesAsync(int seriesId)
        {
            var entity = await _ctx.Series.FindAsync(seriesId);
            if (entity == null)
                return false;
            _ctx.Remove(entity);
            return await _ctx.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<SeriesListItem>> GetAllSeriesAsync()
        {
            return await _ctx.Series.Select(s => new SeriesListItem { Id = s.Id, Name = s.Name }).ToListAsync();
        }

        public async Task<SeriesDetail> GetSeriesByIdAsync(int seriesId)
        {
            var entity = await _ctx.Series.Include(s => s.Characters).FirstOrDefaultAsync(s => s.Id == seriesId);

            if (entity == null)
                return null;

            var model = new SeriesDetail
            {
                Name = entity.Name,
                Id = entity.Id,
                Description = entity.Description,
                ImgUrl = entity.ImgUrl,
                Characters = entity.Characters?.Select(c => new Shared.CharacterModels.CharacterListItem { Id = c.Id, Name = c.Name }).ToList(),
            };
            return model;
        }

        public async Task<bool> UpdateSeriesAsync(SeriesUpdate model)
        {
            var entity = await _ctx.Series.FindAsync(model.Id);
            if (entity == null)
                return false;

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImgUrl = model.ImgUrl;
            return await _ctx.SaveChangesAsync() == 1;

        }
    }
}
