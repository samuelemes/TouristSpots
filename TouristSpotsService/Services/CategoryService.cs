using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService.Interfaces;

namespace TouristSpotsService
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository produtoRepository) : base(produtoRepository)
        {
            _repository = produtoRepository;
        }
    }
}