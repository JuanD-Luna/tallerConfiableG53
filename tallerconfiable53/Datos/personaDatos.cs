using System.Data.SqlClient;
using tallerconfiable53.Models;
using System.Data;

namespace tallerconfiable53.Datos
{
    public class personaDatos
    {
        public List<personaModelo> Listar()
        {
            var olista = new List<personaModelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPersona", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new personaModelo()
                        {
                            idPersona = Convert.ToInt32(dr["idPersona"]),
                            identificacion = dr["identificacion"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            apellido = dr["apellido"].ToString(),
                            anoNacimiento = dr["anoNacimiento"].ToString(),
                            ciudad = dr["ciudad"].ToString(),
                            email = dr["email"].ToString(),
                        });
                    }
                }
            }
            return olista;

        }

        public personaModelo Obtener(int idPersona)
        {
            var oPersona = new personaModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerPersona", conexion);
                cmd.Parameters.AddWithValue("idPersona", idPersona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oPersona.idPersona = Convert.ToInt32(dr["idPersona"]);
                        oPersona.identificacion = dr["identificacion"].ToString();
                        oPersona.nombre = dr["nombre"].ToString();
                        oPersona.apellido = dr["apellido"].ToString();
                        oPersona.anoNacimiento = dr["anoNacimiento"].ToString();
                        oPersona.ciudad = dr["ciudad"].ToString();
                        oPersona.email = dr["email"].ToString();

                    }
                }
            }
            return oPersona;

        }

        public bool Guardar(personaModelo oPersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPropietario", conexion);
                    cmd.Parameters.AddWithValue("identificacion", oPersona.identificacion);
                    cmd.Parameters.AddWithValue("nombre", oPersona.nombre);
                    cmd.Parameters.AddWithValue("apellido", oPersona.apellido);
                    cmd.Parameters.AddWithValue("anoNacimiento", oPersona.anoNacimiento);
                    cmd.Parameters.AddWithValue("ciudad", oPersona.ciudad);
                    cmd.Parameters.AddWithValue("email", oPersona.email);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
        public bool Editar(personaModelo opersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPersona", conexion);
                    cmd.Parameters.AddWithValue("idPersona", opersona.idPersona);
                    cmd.Parameters.AddWithValue("identificacion", opersona.identificacion);
                    cmd.Parameters.AddWithValue("nombre", opersona.nombre);
                    cmd.Parameters.AddWithValue("apellido", opersona.apellido);
                    cmd.Parameters.AddWithValue("anoNacimiento", opersona.anoNacimiento);
                    cmd.Parameters.AddWithValue("ciudad", opersona.ciudad);
                    cmd.Parameters.AddWithValue("email", opersona.email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
        public bool Eliminar(int idPersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarPersona", conexion);
                    cmd.Parameters.AddWithValue("idPersona", idPersona);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
    }

}