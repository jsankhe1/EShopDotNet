using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepositoryAsync
{    
    
    private readonly ProductDbContext _productDbContext;

    public ProductRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }
}