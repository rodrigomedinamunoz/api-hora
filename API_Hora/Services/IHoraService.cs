using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API_Hora.Models;

namespace API_Hora.Services
{
    public interface IHoraService
    {
        HoraResultado ObtenerHora(string ciudad);
    }
}