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
    class UsuarioRepository
    {

        public void Create(Usuario pUsuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Cliente (Nome, Senha, Adm)");
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

            sql.Append("UPDATE Usuario SET Nome=@Nome, Senha=@Senha, Adm=@Adm");
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
                usuario.Nome = (string)dr["Nome"];
                usuario.Senha = (string)dr["Senha"];
                usuario.Adm = (Boolean)dr["Adm"];
            }
            return usuario;
        }

    }
}
