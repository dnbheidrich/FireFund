namespace Keepr.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        public string ImgUrl { get; set; }

    }
  
}