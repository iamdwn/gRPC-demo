using KoiCareSys.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KoiCareSys.Data.DTO
{
    public class UnitDTO
    {
        public Guid UnitId { get; set; }

        public string Name { get; set; }

        public string UnitOfMeasure { get; set; }

        public string FullName { get; set; }

        public string Information { get; set; }

        public decimal? MinValue { get; set; }

        public decimal? MaxValue { get; set; }
    }
}
