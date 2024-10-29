using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSys.Data.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column("create_date")]
        [Required]
        public DateTime CreateDate { get; set; }
        [Column("order_date")]
        public DateTime? OrderDate { get; set; }
        [Column("Status")]
        public string? Status { get; set; }
        [Column("Total")]
        public decimal? Total { get; set; }
        [InverseProperty("order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
