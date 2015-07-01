using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Conn;

namespace Repository
{
    public class AgendaRepository
    {

        public void Create(Agenda pAgenda)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Agenda (Usuario_IdUsuario, Cliente_IdCliente, Data_, Hora, Local_, Servico, Observacoes)");
            sql.Append("VALUES(@IdUsuario, @IdCliente, @Data, @Hora, @Local, @Servico, @Observacoes)");
           
            cmd.Parameters.AddWithValue("@IdUsuario", pAgenda.IdUsuario);
            cmd.Parameters.AddWithValue("@IdCliente", pAgenda.IdCliente);
            cmd.Parameters.AddWithValue("@Data", pAgenda.Data);
            cmd.Parameters.AddWithValue("@Hora", pAgenda.Hora);
            cmd.Parameters.AddWithValue("@Local", pAgenda.Local);
            cmd.Parameters.AddWithValue("@Servico", pAgenda.Servico);
            cmd.Parameters.AddWithValue("@Observacoes", pAgenda.Observacoes);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Update(Agenda pAgenda)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE Agenda SET Data_=@Data, Hora=@Hora, Local_=@Local, Servico=@Servico, Obervacoes=@Obervacoes");
            sql.Append(" WHERE IdAgenda = " + pAgenda.IdAgenda);

            cmd.Parameters.AddWithValue("@Data", pAgenda.Data);
            cmd.Parameters.AddWithValue("@Hora", pAgenda.Hora);
            cmd.Parameters.AddWithValue("@Local", pAgenda.Local);
            cmd.Parameters.AddWithValue("@Servico", pAgenda.Servico);
            cmd.Parameters.AddWithValue("@Obervacoes", pAgenda.Observacoes);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM Agenda ");
            sql.Append("WHERE IdAgenda = " + pId);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public static Agenda GetName(String pNome)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("SELECT * ");
            sql.Append("FROM Agenda ");
            sql.Append("WHERE Nome = '" + pNome + "'");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.IdAgenda = Convert.ToInt32(dr["IdAgenda"]);
                agenda.IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]);
                agenda.ClienteNome = (String)dr["Nome"];
                agenda.IdUsuario = Convert.ToInt32(dr["Usuario_IdUsuario"]);
                agenda.UsuarioNome = (String)dr["Nome"];
                agenda.Data = (String)dr["Data_"];
                agenda.Hora = (String)dr["Hora"];
                agenda.Local = (String)dr["Local_"];
                agenda.Servico = (String)dr["Servico"];
                agenda.Observacoes = (String)dr["Obervacoes"];
            }
            dr.Close();
            return agenda;
        }

        public static Agenda GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("select ag.IdAgenda, ag.Usuario_IdUsuario, us.Nome, ag.Cliente_IdCliente, cl.Nome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes");
            sql.Append(" from agenda as ag");
            sql.Append(" inner join cliente as cl");
            sql.Append(" inner join usuario as us");
            sql.Append(" on ag.Cliente_IdCliente = cl.IdCliente AND ag.Usuario_IdUsuario = us.IdUsuario AND ag.IdAgenda = " + pId);

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.IdAgenda = Convert.ToInt32(dr["IdAgenda"]);
                agenda.IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]);
                agenda.ClienteNome = (String)dr["Nome"];
                agenda.IdUsuario = Convert.ToInt32(dr["Usuario_IdUsuario"]);
                agenda.UsuarioNome = (String)dr["Nome"];
                agenda.Data = (String)dr["Data_"];
                agenda.Hora = (String)dr["Hora"];
                agenda.Local = (String)dr["Local_"];
                agenda.Servico = (String)dr["Servico"];
                agenda.Observacoes = (String)dr["Observacoes"];
            }
            dr.Close();
            return agenda;
        }

        public static List<Agenda> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append("select ag.IdAgenda, ag.Usuario_IdUsuario, us.Nome, ag.Cliente_IdCliente, cl.Nome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes");
            sql.Append(" from agenda as ag");
            sql.Append(" inner join cliente as cl");
            sql.Append(" on ag.Cliente_IdCliente = cl.IdCliente");
            sql.Append(" inner join usuario as us");
            sql.Append(" on ag.Usuario_IdUsuario = us.IdUsuario");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = Convert.ToInt32(dr["IdAgenda"]),
                        IdUsuario = Convert.ToInt32(dr["Usuario_IdUsuario"]),
                        UsuarioNome = (String)dr["Nome"],
                        IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]),
                        ClienteNome = (String)dr["Nome"],
                        Data = (String)dr["Data_"],
                        Hora = (String)dr["Hora"],
                        Local = (String)dr["Local_"],
                        Servico = (String)dr["Servico"],
                        Observacoes = (String)dr["Observacoes"]
                    });
            }
            dr.Close();
            return agendas;
        }

        public static List<Agenda> GetBySearch(String Nome)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agenda = new List<Agenda>();

            sql.Append("SELECT * ");
            sql.Append("FROM Agenda ");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.Add(
                    new Agenda
                    {
                        IdAgenda = Convert.ToInt32(dr["IdAgenda"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        ClienteNome = (String)dr["Nome"],
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        UsuarioNome = (String)dr["Nome"],
                        Data = (String)dr["Data_"],
                        Hora = (String)dr["Hora"],
                        Local = (String)dr["Local_"],
                        Servico = (String)dr["Servico"],
                        Observacoes = (String)dr["Observacoes"]
                    });
            }

            dr.Close();

            return agenda;
        }

    }

}
