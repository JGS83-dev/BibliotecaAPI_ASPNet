using Biblioteca.Entities.DTO;

namespace Biblioteca.BL.Interfaces
{
    public interface IAutorService
    {
        public Task<List<AutorDTO>> GetAutoresAsync();
        public Task<AutorDTO> GetAutorByIdAsync(int id);
        public Task<int> InsertAutorAsync(AutorDTO autor);
        public Task<AutorDTO> UpdateAutorAsync(AutorDTO autor);
        public Task<bool> DeleteAutorAsync(int id);
    }
}
