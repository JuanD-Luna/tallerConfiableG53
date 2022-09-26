using System.Data.SqlClient;
using tallerconfiable53.Models;
using System.Data;

namespace tallerconfiable53.Datos
{
    public class vehiculoDatos
    {
        public List<vehiculoModelo> Listar()
        {
            var olista = new List<vehiculoModelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new vehiculoModelo()
                        {
                            idPropietario = Convert.ToInt32(dr["idPropietario"]),
                            identificacion = Convert.ToInt32(dr["identificacion"]),
                            placa = dr["placa"].ToString(),
                            tipo = dr["tipo"].ToString(),
                            marca = dr["marca"].ToString(),
                            modelo = dr["modelo"].ToString(),
                            capacidad = dr["capacidad"].ToString(),
                            cilindraje = dr["cilindraje"].ToString(),
                            ciudadOrigen = dr["ciudadOrigen"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                        });
                    }
                }
            }
            return olista;

        }

        public vehiculoModelo Obtener(int idVehiculo)
        {
            var oVehiculo = new vehiculoModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVehiculo", conexion);
                cmd.Parameters.AddWithValue("idVehiculo", idVehiculo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oVehiculo.idPropietario = Convert.ToInt32(dr["idPropietario"]);
                        oVehiculo.identificacion = Convert.ToInt32(dr["identificacion"]);
                        oVehiculo.placa = dr["placa"].ToString();
                        oVehiculo.tipo = dr["tipo"].ToString();
                        oVehiculo.marca = dr["marca"].ToString();
                        oVehiculo.modelo = dr["modelo"].ToString();
                        oVehiculo.capacidad = dr["capacida"].ToString();
                        oVehiculo.cilindraje = dr["cilindarje"].ToString();
                        oVehiculo.ciudadOrigen = dr["ciudadOrigen"].ToString();
                        oVehiculo.descripcion = dr["descripcion"].ToString();
                    }
                }
            }
            return oVehiculo;

        }

        public bool Guardar(vehiculoModelo oVehiculo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("idPropietario", oVehiculo.idPropietario);
                    cmd.Parameters.AddWithValue("identificacion", oVehiculo.identificacion);
                    cmd.Parameters.AddWithValue("placa", oVehiculo.placa);
                    cmd.Parameters.AddWithValue("tipo", oVehiculo.tipo);
                    cmd.Parameters.AddWithValue("marca", oVehiculo.marca);
                    cmd.Parameters.AddWithValue("modelo", oVehiculo.modelo);
                    cmd.Parameters.AddWithValue("capacidad", oVehiculo.capacidad);
                    cmd.Parameters.AddWithValue("cilindraje", oVehiculo.cilindraje);
                    cmd.Parameters.AddWithValue("ciudadOrigen", oVehiculo.ciudadOrigen);
                    cmd.Parameters.AddWithValue("descripcion", oVehiculo.descripcion);
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
        public bool Editar(vehiculoModelo ovehiculo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("idPropietario", ovehiculo.idPropietario);
                    cmd.Parameters.AddWithValue("identificacion", ovehiculo.identificacion);
                    cmd.Parameters.AddWithValue("placa", ovehiculo.placa);
                    cmd.Parameters.AddWithValue("tipo", ovehiculo.tipo);
                    cmd.Parameters.AddWithValue("marca", ovehiculo.marca);
                    cmd.Parameters.AddWithValue("modelo", ovehiculo.modelo);
                    cmd.Parameters.AddWithValue("capacidad", ovehiculo.capacidad);
                    cmd.Parameters.AddWithValue("cilindraje", ovehiculo.cilindraje);
                    cmd.Parameters.AddWithValue("ciudadOrigen", ovehiculo.ciudadOrigen);
                    cmd.Parameters.AddWithValue("descripcion", ovehiculo.descripcion);
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
        public bool Eliminar(int idVehiculo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("idVehiculo", idVehiculo);
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