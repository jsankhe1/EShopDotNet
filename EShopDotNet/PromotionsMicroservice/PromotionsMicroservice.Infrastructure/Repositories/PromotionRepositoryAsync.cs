using PromotionsMicroservice.Core.Contracts.Interfaces;
using PromotionsMicroservice.Core.Entities;
using PromotionsMicroservice.Infrastructure.Data;

namespace PromotionsMicroservice.Infrastructure.Repositories;

public class PromotionRepositoryAsync : BaseRepositoryAsync<Promotion>, IPromotionRepository
{
    private readonly PromotionDbContext _promotionDbContext;

    public PromotionRepositoryAsync(PromotionDbContext promotionDbContext) : base(promotionDbContext)
    {
        _promotionDbContext = promotionDbContext;
    }
}