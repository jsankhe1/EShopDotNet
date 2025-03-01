using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories;

public class ProductVariationRepository : BaseRepository<ProductVariationValues>, IProductVariationRepositoryAsync
{   
    
    private readonly ProductDbContext _productDbContext;
    


    public ProductVariationRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }
}