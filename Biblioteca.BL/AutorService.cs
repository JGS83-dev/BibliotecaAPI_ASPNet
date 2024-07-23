using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL
{
    public class AutorService: IAutorService
    {
        private readonly IAutorRepository repository;
        private readonly IMapper mapper;

        public AutorService(IAutorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<AutorDTO>> GetAutoresAsync()
        {
            try
            {
                var result = await repository.GetAutoresAsync();
                return mapper.Map<List<Autor>, List<AutorDTO>>(result);
            }
            catch (Exception ex) { 
                return new List<AutorDTO>();
            }
        }

        public async Task<AutorDTO> GetAutorByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetAutorByIdAsync(id);
                return mapper.Map<Autor, AutorDTO>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertAutorAsync(AutorDTO autor)
        {
            try
            {
                var entity = mapper.Map<AutorDTO, Autor>(autor);
                return await repository.InsertAutorAsync(entity);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<AutorDTO> UpdateAutorAsync(AutorDTO autor)
        {
            try
            {
                var entity = mapper.Map<AutorDTO, Autor>(autor);
                var result = await repository.UpdateAutorAsync(entity);
                return mapper.Map<Autor, AutorDTO>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAutorAsync(int id)
        {
            try
            {
                return await repository.DeleteAutorAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
