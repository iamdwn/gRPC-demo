using KoiCareSys.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace KoiCareSys.Data.DTO
{
    public class MeasureDataDTO
    {
        public Guid MeasureDataId { get; set; }

        public decimal? Volume { get; set; }

        public Guid UnitId { get; set; }
    }
}
