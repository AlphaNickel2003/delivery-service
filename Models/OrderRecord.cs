namespace DeliveryApi.Models;

/// <summary>
/// Модель записи для БД
/// </summary>
public class OrderRecord{
    // Первичный ключ, создается автоматически при добавлении в БД
    public int Id{get; set;}

    // Город отправителя
    public string OriginCity{get; set;} = string.Empty;
    
    // Адрес отправителя
    public string OriginAddress{get; set;} = string.Empty;

    // Город получателя
    public string DestinationCity{get; set;} = string.Empty;

    // Адрес получателя
    public string DestinationAddress{get; set;} = string.Empty;

    // Вес груза
    public double Weight{get; set;}

    // Дата забора груза
    public DateTime PickupDate{get; set;}
}