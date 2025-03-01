using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Core.Entities;

namespace PromotionsMicroservice.Infrastructure.Data;

public class PromotionDbContext : DbContext
{

    public PromotionDbContext(DbContextOptions<PromotionDbContext> options) : base(options)
    {
    }

    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionDetail> PromotionDetails { get; set; }
    
}