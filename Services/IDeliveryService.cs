using DeliveryApi.DTOs;
using DeliveryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApi.Services;

public interface IDeliveryService
{
    Task <OrderRecord> CreateOrderAsync(CreateOrderRecordDto dto, CancellationToken ct);
}