using System.Web.Http;
using API_Hora.Services;

namespace API_Hora.Controllers
{
    [RoutePrefix("api/hora")]
    public class HoraController : ApiController
    {
        private readonly IHoraService _horaService;

        public HoraController(IHoraService horaService)
        {
            _horaService = horaService;
        }

        [HttpGet]
        [Route("{ciudad}")]
        public IHttpActionResult GetHora(string ciudad)
        {
            var resultado = _horaService.ObtenerHora(ciudad);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }
    }
}
