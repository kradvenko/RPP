using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Usuario
    {
        private String calle;
        private String colonia;
        private String curp;
        private int idUsuario;
        private String login;
        private String apellidoMaterno;
        private String apellidoPaterno;
        private String fechaNacimiento;
        private int idTipoUsuario;
        private int municipio;
        private String noControl;
        private String nombre;
        private String password;
        private int poblacion;
        private String codigoPostal;
        private String rfc;
        private String telefono1;
        private String telefono2;
        private String estatus;
        //Esta es una variable para almacenar el tipo de usuario como cadena
        String tipoUsuario;
    
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        public int IdTipoUsuario
        {
            get
            {
                return idTipoUsuario;
            }
            set
            {
                idTipoUsuario = value;
            }
        }

        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public String ApellidoPaterno
        {
            get
            {
                return apellidoPaterno;
            }
            set
            {
                apellidoPaterno = value;
            }
        }

        public String ApellidoMaterno
        {
            get
            {
                return apellidoMaterno;
            }
            set
            {
                apellidoMaterno = value;
            }
        }

        public String Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public String Estatus
        {
            get
            {
                return estatus;
            }
            set
            {
                estatus = value;
            }
        }

        public String Calle
        {
            get
            {
                return calle;
            }
            set
            {
                calle = value;
            }
        }

        public String Colonia
        {
            get
            {
                return colonia;
            }
            set
            {
                colonia = value;
            }
        }

        public int Poblacion
        {
            get
            {
                return poblacion;
            }
            set
            {
                poblacion = value;
            }
        }

        public int Municipio
        {
            get
            {
                return municipio;
            }
            set
            {
                municipio = value;
            }
        }

        public String CodigoPostal
        {
            get
            {
                return codigoPostal;
            }
            set
            {
                codigoPostal = value;
            }
        }

        public String Rfc
        {
            get
            {
                return rfc;
            }
            set
            {
                rfc = value;
            }
        }

        public String Curp
        {
            get
            {
                return curp;
            }
            set
            {
                curp = value;
            }
        }

        public String Telefono1
        {
            get
            {
                return telefono1;
            }
            set
            {
                telefono1 = value;
            }
        }

        public String Telefono2
        {
            get
            {
                return telefono2;
            }
            set
            {
                telefono2 = value;
            }
        }

        public String FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
            set
            {
                fechaNacimiento = value;
            }
        }

        public String NoControl
        {
            get
            {
                return noControl;
            }
            set
            {
                noControl = value;
            }
        }

        public String TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }
            set
            {
                tipoUsuario = value;
            }
        }
        public static Usuario ObtenerUsuarioPorId(int UsuarioId)
        {
            Usuario usu = new Usuario();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select * from Usuarios inner join TipoUsuarios on Usuarios.id_tipo_usuario=TipoUsuarios.id_tipo_usuario where id_usuario='" + UsuarioId + "'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    usu.Nombre = reader["nombre"].ToString();
                    usu.ApellidoPaterno = reader["apellido_paterno"].ToString();
                    usu.ApellidoMaterno = reader["apellido_materno"].ToString();
                    usu.Login = reader["login"].ToString();
                    usu.Password = reader["password"].ToString();
                    usu.Calle = reader["calle"].ToString();
                    usu.Colonia = reader["colonia"].ToString();
                    usu.Poblacion = int.Parse(reader["poblacion"].ToString());
                    usu.Municipio = int.Parse(reader["municipio"].ToString());
                    usu.CodigoPostal = reader["codigo_postal"].ToString();
                    usu.Rfc = reader["rfc"].ToString();
                    usu.Curp = reader["curp"].ToString();
                    usu.Telefono1 = reader["telefono_1"].ToString();
                    usu.Telefono2 = reader["telefono_2"].ToString();
                    usu.FechaNacimiento = reader["fecha_nacimiento"].ToString();
                    usu.NoControl = reader["numero_control"].ToString();
                    usu.IdTipoUsuario = int.Parse(reader["id_tipo_usuario"].ToString());
                    usu.TipoUsuario = reader["tipo"].ToString();
                }
            }
            con.Close();
            return usu;
        }
        public static String CambiarPasswordUsuario(int UsuarioId,String newPass)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("UPDATE Usuarios SET password='"+newPass + "' where id_usuario="+UsuarioId, con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error.";
            }
        }
        public String GuardarNuevo(int id_tipo_usuario, String nombre, String apellido_paterno, String apellido_materno, String login, String password, String estatus, String calle, String colonia, int poblacion, int municipio, String codigo_postal, String rfc, String curp, String telefono_1, String telefono_2, String fecha_nacimiento, String numero_control)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Usuarios WHERE login LIKE '" + login + "'", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                con.Close();
                return "Nombre de usuario ya existe.";
            }
            else
            {
                reader.Close();
                comm = new SqlCommand("INSERT INTO Usuarios VALUES (" + id_tipo_usuario + ", '" + nombre + "', '" + apellido_paterno + "', '" + apellido_materno + "', '" + login + "', '" + password + "', '" + estatus + "', '" + calle + "', '" + colonia + "', " + poblacion + ", " + municipio + ", '" + codigo_postal + "', '" + rfc + "', '" + curp + "', '" + telefono_1 + "', '" + telefono_2 + "', '" + fecha_nacimiento + "', '" + numero_control + "')", con);
                int result = comm.ExecuteNonQuery();
                if (result > 0)
                {
                    con.Close();
                    return "OK";
                }
                else
                {
                    con.Close();
                    return "Error.";
                }
            }
        }
        public static String CambiarDatosUsuario(Usuario user)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Usuarios WHERE login LIKE '" + user.Login + "' AND id_usuario != " + user.IdUsuario, con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                con.Close();
                return "Nombre de usuario ya existe.";
            }
            else
            {
                reader.Close();
                comm = new SqlCommand("UPDATE Usuarios SET  nombre = '" + user.Nombre + "', apellido_paterno = '" + user.ApellidoPaterno + "', apellido_materno = '" + user.ApellidoMaterno + "', calle = '" + user.Calle + "', colonia = '" + user.Colonia + "', poblacion = " + user.Poblacion + ", municipio = '" + user.Municipio + "', codigo_postal = '" + user.CodigoPostal + "', rfc = '" + user.Rfc + "', curp = '" + user.Curp + "', telefono_1 = '" + user.Telefono1 + "', telefono_2 = '" + user.Telefono2 + "', fecha_nacimiento = '" + user.FechaNacimiento + "', numero_control = '" + user.NoControl + "' WHERE id_usuario = " + user.IdUsuario +" and id_tipo_usuario="+user.IdTipoUsuario +" and login='"+user.Login+"'", con);
                int result = comm.ExecuteNonQuery();
                if (result > 0)
                {
                    con.Close();
                    return "OK";
                }
                else
                {
                    con.Close();
                    return "Error.";
                }
            }
        }

        public String Actualizar(int id_usuario, int id_tipo_usuario, String nombre, String apellido_paterno, String apellido_materno, String login, String password, String estatus, String calle, String colonia, int poblacion, int municipio, String codigo_postal, String rfc, String curp, String telefono_1, String telefono_2, String fecha_nacimiento, String numero_control)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Usuarios WHERE login LIKE '" + login + "' AND id_usuario != " + id_usuario, con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                con.Close();
                return "Nombre de usuario ya existe.";
            }
            else
            {
                reader.Close();
                comm = new SqlCommand("UPDATE Usuarios SET id_tipo_usuario = " + id_tipo_usuario + ", nombre = '" + nombre + "', apellido_paterno = '" + apellido_paterno + "', apellido_materno = '" + apellido_materno + "', login = '" + login + "', password = '" + password + "', estatus = '" + estatus + "', calle = '" + calle + "', colonia = '" + colonia + "', poblacion = " + poblacion + ", municipio = '" + municipio + "', codigo_postal = '" + codigo_postal + "', rfc = '" + rfc + "', curp = '" + curp + "', telefono_1 = '" + telefono_1 + "', telefono_2 = '" + telefono_2 + "', fecha_nacimiento = '" + fecha_nacimiento + "', numero_control = '" + numero_control + "' WHERE id_usuario = " + id_usuario, con);
                int result = comm.ExecuteNonQuery();
                if (result > 0)
                {
                    con.Close();
                    return "OK";
                }
                else
                {
                    con.Close();
                    return "Error.";
                }
            }
        }
        //La función de inicio de sesión recibe el nombre de usuario y la contraseña como parametros
        //para después buscar coincidencias en la tabla Usuarios.
        //Retorna un tipo de dato Usuario con la información encontrada. Si no encuentra información retorna un valor nulo.
        public static Usuario IniciarSesion(String nombre, String password)
        {
            //Esta variable SOLO es usada en el ámbito de esta función.
            //Almacena la información del usuario que va a retornarse.
            Usuario u = new Usuario();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Usuarios INNER JOIN TipoUsuarios ON TipoUsuarios.id_tipo_usuario = Usuarios.id_tipo_usuario WHERE login LIKE '" + nombre + "' AND password LIKE '" + password + "' and estatus='ACTIVO'", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    u.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                    u.IdTipoUsuario = int.Parse(reader["id_tipo_usuario"].ToString());
                    u.Nombre = reader["nombre"].ToString();
                    u.ApellidoPaterno = reader["apellido_paterno"].ToString();
                    u.ApellidoMaterno = reader["apellido_materno"].ToString();
                    u.Login = reader["login"].ToString();
                    u.Password = reader["password"].ToString();
                    u.Estatus = reader["Estatus"].ToString();
                    u.Calle = reader["calle"].ToString();
                    u.Colonia = reader["colonia"].ToString();
                    u.Poblacion = int.Parse(reader["poblacion"].ToString());
                    u.Municipio = int.Parse(reader["municipio"].ToString());
                    u.CodigoPostal = reader["codigo_postal"].ToString();
                    u.Rfc = reader["rfc"].ToString();
                    u.Curp = reader["curp"].ToString();
                    u.Telefono1 = reader["telefono_1"].ToString();
                    u.Telefono2 = reader["telefono_2"].ToString();
                    u.FechaNacimiento = reader["fecha_nacimiento"].ToString();
                    u.NoControl = reader["numero_control"].ToString();
                    u.TipoUsuario = reader["tipo"].ToString();
                }
            }
            else
            {
                u = null;
            }

            return u;
        }
    }
}
