using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Date Purchased")]
        public DateTime DateOfTransaction
        {
            get
            {
                return DateTime.Now;
            }
        }
        public double Total
        {
            get
            {
                if (Product == null)
                    return 0;
                double totalCost = Quantity * Product.Price;
                return totalCost;
            }
        }
    }
}