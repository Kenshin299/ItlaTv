using Application.Repositories;
using Application.ViewModels;
using Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProducerService
    {
        private readonly ProducerRepository _repository;

        public ProducerService(ProducerRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(SaveProducerViewModel vm)
        {
            Producer producer = new()
            {
                Name = vm.Name
            };

            await _repository.AddAsync(producer);
        }

        public async Task Update(SaveProducerViewModel vm)
        {
            Producer producer = new()
            {
                Id = vm.Id,
                Name = vm.Name
            };

            await _repository.UpdateAsync(producer);
        }

        public async Task Delete(int id)
        {
            var producer = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(producer);
        }

        public async Task<SaveProducerViewModel> GetByIdSaveViewModel(int id)
        {
            var producer = await _repository.GetByIdAsync(id);
            SaveProducerViewModel vm = new()
            {
                Id = producer.Id,
                Name = producer.Name
            };

            return vm;
        }

        public async Task<List<ProducerViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new ProducerViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Series = s.Series
            }).ToList();
        }
    }
}
