using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models
{
    public class ProductWarehouse
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int IdWarehouse { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Zamówienie musi mieć ilość większą niż 0")]
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
