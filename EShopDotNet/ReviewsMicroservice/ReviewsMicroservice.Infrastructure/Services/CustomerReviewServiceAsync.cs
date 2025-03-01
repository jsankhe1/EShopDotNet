using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Models;
using ReviewsMicroservice.Core.Contracts.Interfaces;
using ReviewsMicroservice.Core.Contracts.Services;
using ReviewsMicroservice.Core.Entities;
using ReviewsMicroservice.Core.Models.RequestModel;

namespace ReviewsMicroservice.Infrastructure.Services;

public class CustomerReviewServiceAsync : ICustomerReviewServiceAsync
{
    private readonly IMapper _mapper;
    private readonly ICustomerReviewRepository _reviewRepository;

    public CustomerReviewServiceAsync(IMapper mapper, ICustomerReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
    }


    public async Task<IEnumerable<ReviewResponseModel>> GetAllAsync()
    {
        var reviews = await _reviewRepository.GetAll().ToListAsync();
        return _mapper.Map<IEnumerable<ReviewResponseModel>>(reviews);

    }

    public async Task<int> InsertAsync(CustomerReviewRequestModel customerReviewRequestModel)
    {
        var reviewIn = _mapper.Map<CustomerReview>(customerReviewRequestModel);
        return await _reviewRepository.InsertAsync(reviewIn);
    }

    public async Task<int> UpdateAsync(CustomerReviewRequestModel customerReviewRequestModel)
    {
        var reviewIn = _mapper.Map<CustomerReview>(customerReviewRequestModel);
        return await _reviewRepository.UpdateAsync(reviewIn);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _reviewRepository.DeleteByIdAsync(id);
    }

    public async Task<ReviewResponseModel?> GetByIdAsync(int id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        return _mapper.Map<ReviewResponseModel>(review);
    }

    public async Task<IEnumerable<ReviewResponseModel>> GetByUserIdAsync(string userId)
    {
        var reviewsByUser = await _reviewRepository.GetAll()
            .AsNoTracking()
            .Where(r => r.CustomerId == userId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<ReviewResponseModel>>(reviewsByUser);
    }

    public async Task<IEnumerable<ReviewResponseModel>> GetByProductIdAsync(string productId)
    {
        var reviewsByProduct = await _reviewRepository.GetAll()
            .AsNoTracking()
            .Where(r => r.ProductId == productId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<ReviewResponseModel>>(reviewsByProduct);
    }

    public async Task<IEnumerable<ReviewResponseModel>> GetByYearAsync(int year)
    {
        var reviewsByProduct = await _reviewRepository.GetAll()
            .AsNoTracking()
            .Where(r => r.ReviewDate.Year == year)
            .ToListAsync();
        return _mapper.Map<IEnumerable<ReviewResponseModel>>(reviewsByProduct);
    }

    public async Task<int> ApproveReviewAsync(int id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);

        if (review == null)
        {
            return await Task.FromResult(0);
        }

        review.ReviewState = ReviewState.Approved;
        return await _reviewRepository.UpdateAsync(review);
    }

    public async Task<int> RejectReviewAsync(int id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);

        if (review != null)
        {
            _reviewRepository.DeleteByIdAsync(id);
        }

        return await _reviewRepository.UpdateAsync(review);
    }
}