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
    private readonly AppDbContext _context;
    
    public HomeController(IDeliveryService deliveryService, AppDbContext context)
    {
        _deliveryService = deliveryService;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _context.Orders
            .Select(o => new OrderRecordResponseDto(
                        o.Id,
                        o.OriginCity,
                        o.OriginAddress,
                        o.DestinationCity,
                        o.DestinationAddress,
                        o.Weight,
                        o.PickupDate))
            .ToListAsync();
        return View(orders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRecordDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var orders = await _context.Orders
                .Select(o => new OrderRecordResponseDto(
                            o.Id,
                            o.OriginCity,
                            o.OriginAddress,
                            o.DestinationCity,
                            o.DestinationAddress,
                            o.Weight,
                            o.PickupDate))
                .ToListAsync();
            return View("Index", orders);
        }

        await _deliveryService.CreateOrderAsync(dto, ct);
        return RedirectToAction("Index");
    }
}