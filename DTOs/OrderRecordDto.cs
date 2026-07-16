using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace DeliveryApi.DTOs;

public record CreateOrderRecordDto(
    [Required, MaxLength(50)] string OriginCity,
    [Required, MaxLength(200)] string OriginAddress,
    [Required, MaxLength(50)] string DestinationCity,
    [Required, MaxLength(200)] string DestinationAddress,
    [Required, Range(0.1, 100000)] double Weight,
    [Required] DateTime PickupDate
);

public record OrderRecordResponseDto(
    int Id,
    string OriginCity,
    string OriginAddress,
    string DestinationCity,
    string DestinationAddress,
    double Weight,
    DateTime PickupDate
);