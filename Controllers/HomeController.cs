using DeliveryApi.Data;
using DeliveryApi.DTOs;
using DeliveryApi.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApi.Controllers;

public class HomeController : Controller
{
    private readonly IDeliveryService _deliveryService;
    
    public HomeController(IDeliveryService deliveryService)
    {
        _deliveryService = deliveryService;
    }

    public async Task<IActionResult> Index()
    {
        var ct = CancellationToken.None;
        var allOrders = await _deliveryService.GetAllOrdersAsync(ct);

        var allOrdersDto = allOrders.Select(o => new OrderRecordResponseDto(
                    o.Id,
                    o.OriginCity,
                    o.OriginAddress,
                    o.DestinationCity,
                    o.DestinationAddress,
                    o.Weight,
                    o.PickupDate));

        return View(allOrdersDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRecordDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var allOrders = await _deliveryService.GetAllOrdersAsync(ct);
            var allOrdersDto = allOrders.Select(o => new OrderRecordResponseDto(
                    o.Id,
                    o.OriginCity,
                    o.OriginAddress,
                    o.DestinationCity,
                    o.DestinationAddress,
                    o.Weight,
                    o.PickupDate));
                    
            return View("Index", allOrdersDto);
        }

        await _deliveryService.CreateOrderAsync(dto, ct);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> GetOrder(int id, CancellationToken ct)
    {
        var order = await _deliveryService.GetOrderByIdAsync(id, ct);
        var orderDto = new OrderRecordResponseDto(
                order.Id,
                order.OriginCity,
                order.OriginAddress,
                order.DestinationCity,
                order.DestinationAddress,
                order.Weight,
                order.PickupDate);

        return Json(orderDto);
    }
}