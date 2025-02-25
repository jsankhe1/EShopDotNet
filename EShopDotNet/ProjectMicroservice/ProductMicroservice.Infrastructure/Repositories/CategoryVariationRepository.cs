using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories;

public class CategoryVariationRepository : BaseRepository<CategoryVariation>, ICategoryVariationRepository
{
    private readonly ProductDbContext _productDbContext;

    public CategoryVariationRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }
}