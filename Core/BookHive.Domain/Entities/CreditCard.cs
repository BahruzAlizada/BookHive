using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class CreditCard : BaseEntity
    {
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }

        public string CardHolderName { get; set; }         
        public string EncryptedCardNumber { get; set; }     
        public string ExpiryDate { get; set; }            
        public string EncryptedCVV { get; set; }  

        public DateTime AddedDate { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
