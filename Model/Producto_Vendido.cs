namespace Sistema_Gestion.Model
{
    public class Producto_Vendido
    {
        public int Id { get; set; }

        public int IdProucto { get; set; }

        public int stock { get; set; }

        public int IdVenta { get; set; }
    }
}
