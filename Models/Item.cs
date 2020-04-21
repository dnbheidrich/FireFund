namespace Keepr.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Acv { get; set; }
        public decimal Rcv { get; set; }

    }
  
}