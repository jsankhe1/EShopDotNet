using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Core.Contracts.Interfaces;
using PromotionsMicroservice.Core.Contracts.Services;
using PromotionsMicroservice.Core.Entities;
using PromotionsMicroservice.Core.Models.RequestModels;
using PromotionsMicroservice.Core.Models.ResponseModels;

namespace PromotionsMicroservice.Infrastructure.Services;

public class PromotionServiceAsync : IPromotionServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IPromotionRepository _promotionRepository;

    public PromotionServiceAsync(IMapper mapper, IPromotionRepository promotionRepository)
    {
        _mapper = mapper;
        _promotionRepository = promotionRepository;
    }
    public async Task<IEnumerable<PromotionResponseModel>> GetAllAsync()
    {
        var promtions = await _promotionRepository.GetAll().ToListAsync();
        return _mapper.Map<IEnumerable<PromotionResponseModel>>(promtions);
    }

    public async Task<PromotionResponseModel> GetByIdAsync(int id)
    {
        var promotion = await _promotionRepository.GetByIdAsync(id);
        return _mapper.Map<PromotionResponseModel>(promotion);
    }

    public async Task<int> InsertAsync(PromotionRequestModel promotionRequestModel)
    {
        var modelIn = _mapper.Map<Promotion>(promotionRequestModel);
        return await _promotionRepository.InsertAsync(modelIn);
    }

    public async Task<int> UpdateAsync(PromotionRequestModel promotionRequestModel)
    {
        var modelIn = _mapper.Map<Promotion>(promotionRequestModel);
        return await _promotionRepository.InsertAsync(modelIn);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _promotionRepository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<PromotionResponseModel>> GetPromotionByProductNameAsync(string productName)
    {
        var promotionsByName = await _promotionRepository.GetAll()
            .AsNoTracking()
            .Where(p => p.Name == productName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<PromotionResponseModel>>(promotionsByName);
    }

    public async Task<IEnumerable<PromotionResponseModel>> GetActivePromotionsAsync()
    {
        var activePromotions = await _promotionRepository.GetAll()
            .AsNoTracking()
            .Where(p => p.PromotionState == PromotionState.Active)
            .ToListAsync();

        return _mapper.Map<IEnumerable<PromotionResponseModel>>(activePromotions);
    }
}