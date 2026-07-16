using System.Security.Cryptography.X509Certificates;

namespace DeliveryApi.DTOs;

public record CreateOrderRecordDto(
    string OriginCity,
    string OriginAddress,
    string DestinationCity,
    string DestinationAddress,
    double Weight,
    DateTime PickupDate
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