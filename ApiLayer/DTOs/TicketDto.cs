namespace ApiLayer.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

}
