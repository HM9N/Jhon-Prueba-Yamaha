using System.Data;

namespace FidelizacionBackend.Repositories
{
    public class SaleRepository
    {
        private readonly string _connectionString;

        public SaleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }

        public List<Sale> GetSalesAsync()
        {
            List<Sale> lst = new List<Sale>();
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(_connectionString);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "ObtenerVentas";
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Sale obj = new Sale();
                            obj.Id = Convert.ToUInt16(item["venta_id"]);
                            // y de esta forma se obtienen la información de la base de datos
                            lst.Add(obj);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // SE PUEDE INGRESAR EL ERROR A UNA TABLA DE LOGS 
            }
            finally
            {
                // También podemos usar using para evitar estar cerrando la conexión (incluso es mejor usarlo
                // pero caí en cuenta luego de haber escrito ya este código)
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }

            return lst;
        }

        public async Task<bool> SaveSaleAsync(Sale sale)
        {
            var connectionString = await _connectionStringProvider.GetConnectionStringAsync(-1);

            using (var connection = new SqlConnection(connectionString))
            {
                const string storedProcedure = "InsertarVentaSP";
                await connection.OpenAsync();

                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@numero_factura", sale.NumeroFactura;
                    command.Parameters.AddWithValue("@tienda_id", sale.Tienda);
                    /// Y así se agregan todos los parametros necesarios

                    var result = await command.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
        }
    }
}
