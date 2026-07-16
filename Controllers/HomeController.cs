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
        var allOrders = await _deliveryService.GetAllOrders(ct);
        return View(allOrders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRecordDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var allOrders = await _deliveryService.GetAllOrders(ct);
            return View("Index", allOrders);
        }

        await _deliveryService.CreateOrderAsync(dto, ct);
        return RedirectToAction("Index");
    }
}