using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<ProductCategory>, ICategoryRepositoryAsync
{
    private readonly ProductDbContext _productDbContext;

    public CategoryRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }
}