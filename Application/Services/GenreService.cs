using Application.Repositories;
using Application.ViewModels;
using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService
    {
        private readonly GenreRepository _repository;

        public GenreService(GenreRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(SaveGenreViewModel vm)
        {
            Genre genre = new()
            {
                Name = vm.Name
            };

            await _repository.AddAsync(genre);
        }

        public async Task Update(SaveGenreViewModel vm)
        {
            Genre genre = new()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            await _repository.UpdateAsync(genre);
        }

        public async Task Delete(int id)
        {
            var genre = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(genre);
        }

        public async Task<SaveGenreViewModel> GetByIdSaveViewModel(int id)
        {
            var genre = await _repository.GetByIdAsync(id);
            SaveGenreViewModel vm = new()
            {
                Id = genre.Id,
                Name = genre.Name
            };

            return vm;
        }

        public async Task<List<GenreViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new GenreViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }
    }
}
