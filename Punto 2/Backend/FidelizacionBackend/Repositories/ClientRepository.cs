using System.Data;

namespace FidelizacionBackend.Repositories
{
    public class ClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }

        public List<Client> GetClientsAsync()
        {
            List<Client> lst = new List<Client>();
            DataSet ds = new DataSet();
            SqlConnection conexionSQL = new SqlConnection(_connectionString);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "ObtenerClientesSP";
                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Client obj = new Client();
                            obj.Id = Convert.ToUInt16(item["client_id"]);
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

        public async Task<bool> SaveClientAsync(Client client)
        {
            var connectionString = await _connectionStringProvider.GetConnectionStringAsync(-1);

            using (var connection = new SqlConnection(connectionString))
            {
                const string storedProcedure = "InsertarClienteSP";
                await connection.OpenAsync();

                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombres", client.Nombres;
                    command.Parameters.AddWithValue("@apellidos", client.Apellidos);
                    /// Y así se agregan todos los parametros necesarios

                    var result = await command.ExecuteNonQueryAsync();

                    return result > 0;
                }
            }
        }
    }
}
