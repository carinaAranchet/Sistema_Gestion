using System.Data;
using System.Data.SqlClient;
using Sistema_Gestion.Model;

namespace Sistema_Gestion.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString = "Server=127.0.0.1,1433;Initial Catalog=SistemaGestion;Persist Security Info=False;User ID=admin;Password=123456@;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        
        public static List<Venta> GetVentas()
        {
            List<Venta> allVentas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                allVentas.Add(venta);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return allVentas;
        }
        public static bool RegistrarVenta(Venta venta)
        {
            bool req = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] " +
                    "(Comentarios) VALUES " +
                    "(@comentariosParameter);";


                SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(comentariosParameter);


                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        req = true;
                    }
                }

                sqlConnection.Close();
            }

            return req;
        }

        public static bool ModificarVenta(Venta venta)
        {
            bool req = false;
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string updateQuery = "UPDATE Venta SET Comentarios = @comentariosParameter WHERE Id = @idParameter";

                SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios};
                SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.BigInt) { Value = venta.Id };
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.Add(comentariosParameter);
                    sqlCommand.Parameters.Add(idParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        req = true;
                    }
                }
                sqlConnection.Close();
            }

            return req;
        }

        //Eliminar registro de venta

        public static bool EliminarVenta(int Id)
        {
            bool req = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string deleteQuery = "DELETE Venta WHERE Id = @idParameter";
                SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.BigInt) { Value = Id };

                sqlConnection.Open();

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    deleteCommand.Parameters.Add(idParameter);
                    int numberOfRows = deleteCommand.ExecuteNonQuery();

                    if(numberOfRows > 0)
                    {
                        return req = true;
                    }
                }
                sqlConnection.Close();
            }

            return req;
        }
    }
}
