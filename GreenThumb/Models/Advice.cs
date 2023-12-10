using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class Advice
    {
        public int AdviceId { get; set; }
        public string Description { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }    
    }
}
