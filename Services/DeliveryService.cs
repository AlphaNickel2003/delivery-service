using DeliveryApi.Data;
using DeliveryApi.DTOs;
using DeliveryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApi.Services;

public class DeliveryService : IDeliveryService
{

    private readonly AppDbContext _context;

    public DeliveryService(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<OrderRecord> CreateOrderAsync(CreateOrderRecordDto dto, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var newOrder = new OrderRecord
        {
            OriginCity = dto.OriginCity,
            OriginAddress = dto.OriginAddress,
            DestinationCity = dto.DestinationAddress,
            DestinationAddress = dto.DestinationAddress,
            Weight = dto.Weight,
            PickupDate = dto.PickupDate
        };

        await _context.Orders.AddAsync(newOrder, ct);
        await _context.SaveChangesAsync();

        return newOrder;
    }

    //TODO: Дописать методы к фронту
  /*  public async Task<IEnumerable<OrderRecord>> GetAllRecordsAsync()
    {
        
    }

    public async Task<OrderRecord> GetOrderByClickAsync()
    {
        
    }*/
}