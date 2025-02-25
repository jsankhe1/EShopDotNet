using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories;

public class VariationValueRepository : BaseRepository<VariationValue>, IVariationValueRepositoryAsync
{   
    
    private readonly ProductDbContext _productDbContext;


    
    public VariationValueRepository(ProductDbContext productDbContext) : base(productDbContext)
    {
        _productDbContext = productDbContext;
    }
}