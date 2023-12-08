using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class Plant
    {
        [Key]
        public int Plantid { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Advice> Advices { get; set; }
    }
}
