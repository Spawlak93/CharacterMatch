using CharacterMatch.Server.Data;
using CharacterMatch.Server.Models;
using CharacterMatch.Shared.CharacterModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _ctx;
        public async Task<bool> CreateCharacterAsync(CharacterCreate model)
        {
            var entity = new Character
            {
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                Description = model.Description,
                SeriesId = model.SeriesId,
            };
            _ctx.Characters.Add(entity);
            if (await _ctx.SaveChangesAsync() != 1)
                return false;

            foreach (var trait in model.TraitsToAdd)
                _ctx.CharacterTraits.Add(new CharacterTrait { CharacterId = entity.Id, TraitId = trait.TraitId, Value = trait.Value });

            return await _ctx.SaveChangesAsync() == model.TraitsToAdd.Count;
        }

        public async Task<bool> DeleteCharacterAsync(int characterId)
        {
            var entity = await _ctx.Characters.FindAsync(characterId);
            if (entity == null)
                return false;

            _ctx.Characters.Remove(entity);
            return await _ctx.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<CharacterListItem>> GetAllCharactersAsync()
        {
            return await _ctx.Characters.Select(c => new CharacterListItem { Id = c.Id, Name = c.Name, SeriesId = c.SeriesId}).ToListAsync();
        }

        public async Task<IEnumerable<CharacterWithTraits>> GetAllCharactersWithTraitsAsync()
        {
            return await _ctx.Characters.Include(c => c.Traits).Select(c => new CharacterWithTraits { Id = c.Id, Name = c.Name, SeriesId = c.SeriesId, Traits = c.Traits.Select(t => new Shared.CharacterTraitModels.AddTraitToCharacter { TraitId = t.TraitId, Value = t.Value }).ToList() }).ToListAsync();
        }

        public async Task<CharacterDetail> GetCharacterByIdAsync(int characterId)
        {
            var entity = await _ctx.Characters.Include(c => c.Series).Include(c => c.Traits).ThenInclude(t => t.Trait).FirstOrDefaultAsync(c => c.Id == characterId);
            if(entity == null)
                return null; //possibly use keynotfound exception
            var model = new CharacterDetail
            {
                Id = entity.Id,
                Description = entity.Description,
                ImgUrl = entity.ImgUrl,
                Series = new Shared.SeriesModels.SeriesListItem { Id = entity.Series.Id, Name = entity.Series.Name },
                Name = entity.Name,
                Traits = entity.Traits?.Select(t => new Shared.CharacterTraitModels.CharactersTraitListItem { Value = (byte)t.Value, TraitId = t.TraitId, TraitName = t.Trait.Name }).ToList(),
            };
            return model;
        }

        public async Task<CharacterUpdate> GetCharacterUpdateByIdAsync(int characterId)
        {
            var detail = await GetCharacterByIdAsync(characterId);
            var update = new CharacterUpdate
            {
                Id = detail.Id,
                Name = detail.Name,
                Description = detail.Description,
                ImgUrl = detail.ImgUrl,
                SeriesId = detail.Series.Id,
                Traits = detail.Traits.Select(t => new Shared.CharacterTraitModels.AddTraitToCharacter { TraitId = t.TraitId, Value = t.Value, }).ToList(),
            };
            return update;
        }

        public async Task<bool> UpdateCharacterAsync(CharacterUpdate model)
        {
            var entity = await _ctx.Characters.Include(c => c.Traits).FirstOrDefaultAsync(c => c.Id == model.Id);

            if (entity == null)
                throw new KeyNotFoundException();

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImgUrl = model.ImgUrl;
            entity.SeriesId = model.SeriesId;
            foreach(var modelTrait in model.Traits)
            {
                var entityTrait = entity.Traits.SingleOrDefault(t => t.TraitId == modelTrait.TraitId);
                if(entityTrait != null)
                {
                    entityTrait.Value = modelTrait.Value;
                }
                else
                {
                    _ctx.CharacterTraits.Add(new CharacterTrait { CharacterId = entity.Id, TraitId = modelTrait.TraitId, Value = modelTrait.Value });
                }
            }

            var numberOfChanges = await _ctx.SaveChangesAsync();
            return numberOfChanges > 0;
        }
    }
}
