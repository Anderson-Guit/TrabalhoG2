using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Conn;
using MySql.Data.MySqlClient;

namespace Repository
{
    public class UsuarioRepository
    {

        public void Create(Usuario pUsuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Usuario (Nome, Senha, Adm)");
            sql.Append("VALUES(@Nome, @Senha, @Adm)");

            cmd.Parameters.AddWithValue("@Nome", pUsuario.Nome);
            cmd.Parameters.AddWithValue("@Senha", pUsuario.Senha);
            cmd.Parameters.AddWithValue("@Adm", pUsuario.Adm);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Update(Usuario pUsuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE Usuario SET Nome=@Nome, Senha=@Senha, Adm=@Adm ");
            sql.Append("WHERE IdUsuario=" + pUsuario.IdUsuario);

            cmd.Parameters.AddWithValue("@Nome", pUsuario.Nome);
            cmd.Parameters.AddWithValue("@Senha", pUsuario.Senha);
            cmd.Parameters.AddWithValue("@Adm", pUsuario.Adm);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM Usuario ");
            sql.Append("WHERE IdUsuario=" + pId);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public static Usuario GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Usuario usuario = new Usuario();

            sql.Append("SELECT * ");
            sql.Append("FROM Usuario ");
            sql.Append("WHERE IdUsuario=" + pId);

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                usuario.Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"];
                usuario.Senha = dr.IsDBNull(dr.GetOrdinal("Senha")) ? "" : (String)dr["Senha"];
                usuario.Adm = (Boolean)dr["Adm"];
            }
            return usuario;
        }

        public static List<Usuario> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Usuario> usuario = new List<Usuario>();

            sql.Append("SELECT * ");
            sql.Append("FROM Usuario ");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                usuario.Add(
                    new Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"],
                        Senha = dr.IsDBNull(dr.GetOrdinal("Senha")) ? "" : (String)dr["Senha"],
                        Adm = (Boolean)dr["Adm"],
                    });
            }
            return usuario;
        }

        public static Usuario CheckUser(String Nome, String Senha)
        {
            StringBuilder sql = new StringBuilder();
            Usuario usuario = new Usuario();

            sql.Append("SELECT * ");
            sql.Append("FROM Usuario ");
            sql.Append("WHERE Nome='" + Nome + "' and Senha='" + Senha + "'");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                usuario.Nome = (string)dr["Nome"];
                usuario.Senha = (string)dr["Senha"];
                usuario.Adm = (Boolean)dr["Adm"];
            }
            return usuario;
        }

    }
}
