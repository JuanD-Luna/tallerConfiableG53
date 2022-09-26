using System.Data.SqlClient;
using tallerconfiable53.Models;
using System.Data;

namespace tallerconfiable53.Datos
{
    public class mecanicoDatos
    {
        public List<mecanicoModelo> Listar()
        {
            var olista = new List<mecanicoModelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarMecanico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read())
                    {
                        olista.Add(new mecanicoModelo()
                        {
                            idPersona = Convert.ToInt32(dr["idPersona"]),
                            identificacion = dr["identificacion"].ToString(),
                            nombre = dr["nombre"].ToString(),
                            apellido = dr["apellido"].ToString(),
                            anoNacimiento = dr["anoNacimiento"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            nivelEducativo = dr["nivelEducativo"].ToString(),
                        });
                    }
                }
            }
            return olista;

        }

        public mecanicoModelo Obtener(int idPersona)
        {
            var oPersona = new mecanicoModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerMecanico", conexion);
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
                        oPersona.direccion = dr["direccion"].ToString();
                        oPersona.telefono = dr["telefono"].ToString();
                        oPersona.nivelEducativo = dr["nivelEducativo"].ToString();
                    }
                }
            }
            return oPersona;

        }

        public bool Guardar(mecanicoModelo oPersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarMecanico", conexion);
                    cmd.Parameters.AddWithValue("identificacion", oPersona.identificacion);
                    cmd.Parameters.AddWithValue("nombre", oPersona.nombre);
                    cmd.Parameters.AddWithValue("apellido", oPersona.apellido);
                    cmd.Parameters.AddWithValue("anoNacimiento", oPersona.anoNacimiento);
                    cmd.Parameters.AddWithValue("telefono", oPersona.telefono);
                    cmd.Parameters.AddWithValue("direccion", oPersona.direccion);
                    cmd.Parameters.AddWithValue("nivelEducativo", oPersona.nivelEducativo);
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
        public bool Editar(mecanicoModelo omecanico)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarMecanico", conexion);
                    cmd.Parameters.AddWithValue("idPersona", omecanico.idPersona);
                    cmd.Parameters.AddWithValue("identificacion", omecanico.identificacion);
                    cmd.Parameters.AddWithValue("nombre", omecanico.nombre);
                    cmd.Parameters.AddWithValue("apellido", omecanico.apellido);
                    cmd.Parameters.AddWithValue("anoNacimiento", omecanico.anoNacimiento);
                    cmd.Parameters.AddWithValue("telefono", omecanico.telefono);
                    cmd.Parameters.AddWithValue("direccion", omecanico.direccion);
                    cmd.Parameters.AddWithValue("nivelEducativo", omecanico.nivelEducativo);
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
                    SqlCommand cmd = new SqlCommand("sp_EliminarMecanico", conexion);
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

