using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.Core.Entities;

namespace ReviewsMicroservice.Infrastructure.Data;

public class ReviewDbContext : DbContext
{
    private ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerReview> CustomerReviews { get; set; }
}