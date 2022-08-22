using Microsoft.AspNetCore.Mvc;
using Sistema_Gestion.Repository;
using Sistema_Gestion.Model;
using Sistema_Gestion.Controllers.Source;

namespace Sistema_Gestion.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        // -- SELECT
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }
        //-- INSERT
        [HttpPost(Name = "RegistrarVenta")]
        public bool RegistrarVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.RegistrarVenta(new Venta
                {
                    Comentarios = venta.Comentarios
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //-- UPDATE
        [HttpPut(Name = "ActualizarVenta")]
        public bool ModificarVenta([FromBody] PutVenta venta)
        {
            try
            {
                return VentaHandler.ModificarVenta(new Venta { Id = venta.Id, Comentarios = venta.Comentarios });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        // -- DELETE
        [HttpDelete(Name = "EliminarVenta")]
        public bool EliminarVenta([FromBody] int Id)
        {
            try
            {
                return VentaHandler.EliminarVenta(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
