using System.Security.Cryptography.X509Certificates;

namespace DeliveryApi.DTOs;

public record CreateOrderRecordDto(
    string OriginCity,
    string OriginAddress,
    string DestinationCity,
    string DestinationAddress,
    decimal Weight,
    DateTime PickupDate
);