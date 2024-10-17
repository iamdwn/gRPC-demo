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
    public class MeasurementDTO
    {
        public Guid MeasurementId { get; set; }

        public Guid PondId { get; set; }
        
        public DateTime DateRecord { get; set; }

        public List<MeasureDataDTO>? MeasureData { get; set; }

        public string? Note { get; set; }

    }
}
    
