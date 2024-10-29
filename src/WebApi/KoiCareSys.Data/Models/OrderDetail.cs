using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSys.Data.Models
{
    [Table("order_detail")]
    public class OrderDetail
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("product_id")]
        [ForeignKey("product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null;
        [Column("order_id")]
        [ForeignKey("order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null; 
       
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("create_date")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        [Required]
        public DateTime UpdateDate { get; set; }
    }
}
