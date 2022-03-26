using CharacterMatch.Server.Data;
using CharacterMatch.Server.Models;
using CharacterMatch.Shared.TraitModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.TraitServices
{
    public class TraitService : ITraitService
    {
        private readonly ApplicationDbContext _ctx;
        public TraitService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public async Task<bool> CreateTraitAsync(TraitCreate model)
        {
            var entity = new Trait { Name = model.Name };
            _ctx.Traits.Add(entity);
            return await _ctx.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteTraitAsync(int traitId)
        {
            var entity = await _ctx.Traits.FindAsync(traitId);
            if (entity == null)
                return false;
            _ctx.Remove(entity);
            return await _ctx.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<TraitListItem>> GetAllTraitsAsync()
        {
            return await _ctx.Traits.Select(t => new TraitListItem { Name = t.Name }).ToListAsync();
        }

        public async Task<TraitDetail> GetTraitByIdAsync(int traitId)
        {
            var entity = await _ctx.Traits.Include(t => t.Characters).ThenInclude(c => c.Character).FirstOrDefaultAsync(t => t.Id == traitId);

            if (entity == null)
                return null;

            var model = new TraitDetail
            {
                Name = entity.Name,
                Id = entity.Id,
                Characters = entity.Characters.Select(c => new Shared.CharacterModels.CharacterListItem { Id = c.CharacterId, Name = c.Character.Name }).ToList()
            };
            return model;

        }

        public async Task<bool> UpdateTraitAsync(TraitUpdate model)
        {
            var entity = await _ctx.Traits.FindAsync(model.Id);
            if (entity == null)
                return false;

            entity.Name = model.Name;
            entity.Id = model.Id;
            return await _ctx.SaveChangesAsync() == 1;
        }
    }
}
