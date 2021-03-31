using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphChocolate.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ToppingId { get; set; }

        [Required]
        public string? Name { get; set; }

        public virtual Topping? Topping { get; set; }
    }
}
