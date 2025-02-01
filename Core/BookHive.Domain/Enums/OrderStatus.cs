

namespace BookHive.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,        // Gözləmə
        Processing,     // Hazırlanır
        Shipped,        // Göndərildi
        Delivered,      // Çatdırıldı
        Cancelled
    }
}
