using System;
using System.Collections.Generic;
using API_Hora.Models;

namespace API_Hora.Services
{
    public class HoraService : IHoraService
    {
        private readonly Dictionary<string, string> _zonas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // --- CHILE ---
            { "santiago", "Pacific SA Standard Time" },
            { "valparaiso", "Pacific SA Standard Time" },
            { "concepcion", "Pacific SA Standard Time" },

            // --- ARGENTINA ---
            { "buenosaires", "Argentina Standard Time" },
            { "cordoba", "Argentina Standard Time" },
            { "rosario", "Argentina Standard Time" },
            { "mendoza", "Argentina Standard Time" },

            // --- PERÚ ---
            { "lima", "SA Pacific Standard Time" },
            { "arequipa", "SA Pacific Standard Time" },
            { "cusco", "SA Pacific Standard Time" },

            // --- COLOMBIA ---
            { "bogota", "SA Pacific Standard Time" },
            { "medellin", "SA Pacific Standard Time" },
            { "cali", "SA Pacific Standard Time" },

            // --- ECUADOR ---
            { "quito", "SA Pacific Standard Time" },
            { "guayaquil", "SA Pacific Standard Time" },

            // --- BOLIVIA ---
            { "lapaz", "SA Western Standard Time" },
            { "santacruz", "SA Western Standard Time" },
            { "cochabamba", "SA Western Standard Time" },

            // --- PARAGUAY ---
            { "asuncion", "Paraguay Standard Time" },

            // --- URUGUAY ---
            { "montevideo", "Montevideo Standard Time" },

            // --- VENEZUELA ---
            { "caracas", "Venezuela Standard Time" },

            // --- BRASIL ---
            { "sao paulo", "E. South America Standard Time" },
            { "rio", "E. South America Standard Time" },
            { "rio de janeiro", "E. South America Standard Time" },
            { "salvador", "Bahia Standard Time" },
            { "manaos", "Central Brazilian Standard Time" },
            { "manaus", "Central Brazilian Standard Time" },
            { "fortaleza", "SA Eastern Standard Time" },
            { "recife", "SA Eastern Standard Time" },

            // --- MEXICO ---
            { "mexico", "Central Standard Time (Mexico)" },
            { "mexicocity", "Central Standard Time (Mexico)" },
            { "guadalajara", "Central Standard Time (Mexico)" },
            { "monterrey", "Central Standard Time (Mexico)" },
            { "tijuana", "Pacific Standard Time" },

            // --- PANAMÁ ---
            { "panama", "SA Pacific Standard Time" },

            // --- COSTA RICA ---
            { "sanjose", "Central America Standard Time" },

            // --- NICARAGUA ---
            { "managua", "Central America Standard Time" },

            // --- HONDURAS ---
            { "tegucigalpa", "Central America Standard Time" },

            // --- EL SALVADOR ---
            { "sansalvador", "Central America Standard Time" },

            // --- GUATEMALA ---
            { "guatemala", "Central America Standard Time" },

            // --- CUBA ---
            { "habana", "Cuba Standard Time" },
            { "lahabana", "Cuba Standard Time" },

            // --- REPÚBLICA DOMINICANA ---
            { "santodomingo", "SA Western Standard Time" },

            // --- PUERTO RICO ---
            { "sanjuan", "SA Western Standard Time" }

        };

        public HoraResultado ObtenerHora(string ciudad)
        {
            if (!_zonas.ContainsKey(ciudad))
                return null;

            var zona = TimeZoneInfo.FindSystemTimeZoneById(_zonas[ciudad]);
            var hora = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, zona);

            return new HoraResultado
            {
                Ciudad = ciudad,
                ZonaHoraria = zona.DisplayName,
                HoraActual = hora.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
    }
}
