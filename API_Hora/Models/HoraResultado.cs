using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Hora.Models
{
    public class HoraResultado
    {
        public string Ciudad { get; set; }
        public string ZonaHoraria { get; set; }
        public string HoraActual { get; set; }
    }
}