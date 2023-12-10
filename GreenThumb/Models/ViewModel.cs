using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string PlantName { get; set; }

        public string Advice { get; set; }


    }

    public class PlantDetailsViewModel
    {
        public string PlantName { get; set; }
        public string Advice { get; set; }
    }
}
