using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.Infrastructure.Services;

public class PaymentServiceAsync : IPaymentServiceAsync
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public PaymentServiceAsync(IPaymentMethodRepository paymentMethodRepository, IOrderRepository orderRepository,
        IMapper mapper)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

  

    public async Task<IEnumerable<PaymentResponseModel>> GetPaymentByCustomerIdAsync(int customerId)
    {
        var customerPayment =  await _orderRepository.GetPaymentByCustomerId(customerId).ToListAsync();
        return _mapper.Map<IEnumerable<PaymentResponseModel>>(customerPayment);
    }

    public async Task<PaymentResponseModel> InsertAsync(PaymentRequestModel paymentRequestModel)
    {
        var paymentIn = _mapper.Map<PaymentMethod>(paymentRequestModel);
        var paymentOut = await _paymentMethodRepository.InsertAsync(paymentIn);
        return _mapper.Map<PaymentResponseModel>(paymentOut);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _paymentMethodRepository.DeleteByIdAsync(id);
    }

    public async Task<PaymentResponseModel> UpdateAsync(PaymentRequestModel paymentRequestModel)
    {
        var paymentIn = _mapper.Map<PaymentMethod>(paymentRequestModel);
        var paymentOut = await _paymentMethodRepository.UpdateAsync(paymentIn);
        return _mapper.Map<PaymentResponseModel>(paymentOut);
    }
}