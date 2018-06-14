using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class UsuariosCollection
    {
        private List<Usuario> listaUsuarios;

        public List<Usuario> Catalogo()
        {
            listaUsuarios = new List<Usuario>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Usuarios", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario a = new Usuario();
                    a.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                    a.IdTipoUsuario = int.Parse(reader["id_tipo_usuario"].ToString());
                    a.Login = reader["login"].ToString();
                    a.ApellidoMaterno = reader["apellido_materno"].ToString();
                    a.ApellidoPaterno = reader["apellido_paterno"].ToString();
                    a.Calle = reader["calle"].ToString();
                    a.CodigoPostal = reader["codigo_postal"].ToString();
                    a.Colonia = reader["colonia"].ToString();
                    a.Curp = reader["curp"].ToString();
                    a.Estatus = reader["estatus"].ToString();
                    a.FechaNacimiento = reader["fecha_nacimiento"].ToString();
                    a.Municipio = int.Parse(reader["municipio"].ToString());
                    a.NoControl = reader["numero_control"].ToString();
                    a.Nombre = reader["nombre"].ToString();
                    a.Password = reader["password"].ToString();
                    a.Poblacion = int.Parse(reader["poblacion"].ToString());
                    a.Rfc = reader["rfc"].ToString();
                    a.Telefono1 = reader["telefono_1"].ToString();
                    a.Telefono2 = reader["telefono_2"].ToString();                    
                    listaUsuarios.Add(a);
                }
            }
            con.Close();
            return listaUsuarios;
        }

        public List<Usuario> CatalogoRegistradores()
        {
            listaUsuarios = new List<Usuario>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("select * from Usuarios inner join TipoUsuarios on Usuarios.id_tipo_usuario=TipoUsuarios.id_tipo_usuario"+
                                            "  where tipo='registrador' or TipoUsuarios.id_tipo_usuario='4'", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario a = new Usuario();
                    a.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                    a.IdTipoUsuario = int.Parse(reader["id_tipo_usuario"].ToString());
                    a.TipoUsuario = reader["tipo"].ToString();
                    a.ApellidoMaterno = reader["apellido_materno"].ToString();
                    a.ApellidoPaterno = reader["apellido_paterno"].ToString();
                    a.Nombre = reader["nombre"].ToString();
                    listaUsuarios.Add(a);
                }
            }
            con.Close();
            return listaUsuarios;
        }
    }
}
