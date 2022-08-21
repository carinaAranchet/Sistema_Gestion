using Microsoft.AspNetCore.Mvc;
using Sistema_Gestion.Repository;
using Sistema_Gestion.Model;

namespace Sistema_Gestion.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    }
}
