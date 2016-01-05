using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}