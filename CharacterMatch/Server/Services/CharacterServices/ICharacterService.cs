using CharacterMatch.Shared.CharacterModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterListItem>> GetAllCharactersAsync();
        Task<IEnumerable<CharacterWithTraits>> GetAllCharactersWithTraitsAsync();
        Task<CharacterDetail> GetCharacterByIdAsync(int characterId);

        Task<bool> CreateCharacterAsync(CharacterCreate model);
        Task<bool> UpdateCharacterAsync(CharacterUpdate model);
        Task<bool> DeleteCharacterAsync(int characterId);
    }
}
