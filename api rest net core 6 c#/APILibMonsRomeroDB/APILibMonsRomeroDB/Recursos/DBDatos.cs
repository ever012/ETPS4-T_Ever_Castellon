using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace APILibMonsRomeroDB.Recursos
{
    public class DBDatos
    {
        public static string cadenaConexion = "Data Source=DESKTOP-SDSN0NM\\SQLEXPRESS;Initial Catalog=Lib_MonseñorRomero; Integrated Security = True";
        //public static string cadenaConexion = "Data Source=DESKTOP-SDSN0NM\\SQLEXPRESS;Initial Catalog=Lib_MonseñorRomero;User ID=ever;Password=qY698P&cadPg";
        public static DataSet ListarTablas(string nombreProcedimiento, List<Parametro> parametros = null) //esta es para cuando el procedimiento almacenado debe listar mas de una tabla
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion); 

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable Listar(string nombreProcedimiento, List<Parametro> parametros = null) //esta es para el procedimiento solo retorna 1 tabla
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static dynamic Ejecutar(string nombreProcedimiento, List<Parametro> parametros = null) //esta es para cuando afectas filas, es decir cuando haces un CRUD
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                bool exito = (i > 0) ? true : false;
                return new {
                    exito = exito,
                    mensaje = "exito"
                };
            }
            catch (Exception ex)
            {
                return new {
                    exito = false,
                    mensaje = ex.Message
 
                };
               // return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static dynamic EjecutarConsulta(string sql, List<Parametro> parametros = null) // esta es para ejecutar codigo sql directamente desde aqui con o sin parametros
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                bool exito = (i > 0) ? true : false;
                return new
                {
                    exito = exito,
                    mensaje = "exito"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    exito = false,
                    mensaje = ex.Message
                };
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable ListarConsulta(string consultaSql, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(consultaSql, conexion);
                cmd.CommandType = System.Data.CommandType.Text;  //System.Data.CommandType.Text es para  indicar que la consulta es de tipo texto

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }



    }
}
