using Application.Repositories;
using Application.ViewModels;
using Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SeriesService
    {
        private readonly SeriesRepository _repository;

        public SeriesService(SeriesRepository repository)
        {
            _repository = repository;
        }

        private List<SeriesGenre> GenreHandling(SaveSerieViewModel vm)
        {
            var selectedGenres = new List<SeriesGenre>
            {
                new SeriesGenre { GenreId = vm.PrimaryGenreId }
            };

            if (vm.SecondaryGenreId != 0)
            {
                selectedGenres.Add(new SeriesGenre { GenreId = vm.SecondaryGenreId });
            }

            return selectedGenres;
        }

        public async Task Add(SaveSerieViewModel vm)
        {
            Series series = new()
            {
                Name = vm.Name,
                ImagePath = vm.ImagePath,
                ProducerId = vm.ProducerId,
                VideoLink = vm.VideoLink
            };

            var selectedGenres = GenreHandling(vm);

            series.SeriesGenres = selectedGenres;

            await _repository.AddAsync(series);
        }

        public async Task Update(SaveSerieViewModel vm)
        {
            Series series = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                ImagePath = vm.ImagePath,
                ProducerId = vm.ProducerId,
                VideoLink = vm.VideoLink
            };

            var selectedGenres = GenreHandling(vm);

            series.SeriesGenres = selectedGenres;

            await _repository.UpdateAsync(series);
        }

        public async Task Delete(int id)
        {
            var series = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(series);
        }

        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var series = await _repository.GetByIdAsync(id);
            SaveSerieViewModel vm = new()
            {
                Id = series.Id,
                Name = series.Name,
                ImagePath = series.ImagePath,
                ProducerId = series.ProducerId,
                VideoLink = series.VideoLink
            };

            if (series.SeriesGenres != null)
            {
                var genres = series.SeriesGenres.Select(sg => sg.GenreId).ToList();
                if (genres.Count > 0)
                {
                    vm.PrimaryGenreId = genres[0];
                }
                if (genres.Count > 1)
                {
                    vm.SecondaryGenreId = genres[1];
                }
            }

            return vm;
        }

        public async Task<List<SeriesViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new SeriesViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImagePath = s.ImagePath,
                Producer = s.Producer,
                VideoLink = s.VideoLink,
                Genres = s.Genres
            }).ToList();
        }
    }
}
