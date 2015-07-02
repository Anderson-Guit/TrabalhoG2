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
    public class OrdemServicoRepository
    {

        public void Create(OrdemServico pOS)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO OrdemServico (Cliente_IdCliente, Equipamento, Marca, Modelo, NumeroSerie, Defeito, Servico, Local_, Observacoes, Status_)");
            sql.Append("VALUES(@Cliente, @Equipamento, @Marca, @Modelo, @NumeroSerie, @Defeito, @Servico, @Local, @Observacoes, @Status)");

            cmd.Parameters.AddWithValue("@Cliente", (pOS.Cliente));
            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));
            cmd.Parameters.AddWithValue("@Marca", pOS.Marca);
            cmd.Parameters.AddWithValue("@Modelo", pOS.Modelo);
            cmd.Parameters.AddWithValue("@NumeroSerie", pOS.NumeroSerie);
            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);
            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);
            cmd.Parameters.AddWithValue("@Local", pOS.Local);
            cmd.Parameters.AddWithValue("@Observacoes", pOS.Observacoes);
            cmd.Parameters.AddWithValue("@Status", pOS.Status);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Update(OrdemServico pOS)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE OrdemServico SET Equipamento=@Equipamento, Marca=@Marca, Modelo=@Modelo, NumeroSerie=@NumeroSerie, Defeito=@Defeito, Servico=@Servico, Local_=@Local, Observacoes=@Observacoes, Status_=@Status");
            sql.Append(" WHERE IdOS=" + pOS.IdOS);

            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));
            cmd.Parameters.AddWithValue("@Marca", pOS.Marca);
            cmd.Parameters.AddWithValue("@Modelo", pOS.Modelo);
            cmd.Parameters.AddWithValue("@NumeroSerie", pOS.NumeroSerie);
            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);
            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);
            cmd.Parameters.AddWithValue("@Local", pOS.Local);
            cmd.Parameters.AddWithValue("@Observacoes", pOS.Observacoes);
            cmd.Parameters.AddWithValue("@Status", pOS.Status);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM OrdemServico ");
            sql.Append("WHERE IdOS=" + pId);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public static OrdemServico GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            OrdemServico os = new OrdemServico();

            sql.Append("select os.IdOS, os.Cliente_IdCliente, cl.nome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.Local_, os.Observacoes, os.Status_");
            sql.Append(" from ordemservico as os");
            sql.Append(" inner join cliente as cl");
            sql.Append(" where os.Cliente_IdCliente = cl.IdCliente");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = Convert.ToInt32(dr["IdOS"]);
                os.Cliente = Convert.ToInt32(dr["Cliente_IdCliente"]);
                os.ClienteNome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"];
                os.Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (String)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (String)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (String)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (String)dr["NumeroSerie"];
                os.Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (String)dr["Defeito"];
                os.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"];
                os.Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (String)dr["Status_"];
            }
            return os;
        }

        public static List<OrdemServico> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

            sql.Append("select os.IdOS, os.Cliente_IdCliente, cl.nome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.Local_, os.Observacoes, os.Status_");
            sql.Append(" from ordemservico as os");
            sql.Append(" inner join cliente as cl");
            sql.Append(" where os.Cliente_IdCliente = cl.IdCliente");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.Add(
                    new OrdemServico
                    {
                        IdOS = Convert.ToInt32(dr["IdOS"]),
                        Cliente = Convert.ToInt32(dr["Cliente_IdCliente"]),
                        ClienteNome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"],
                        Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (String)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (String)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (String)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (String)dr["NumeroSerie"],
                        Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (String)dr["Defeito"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"],
                        Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (String)dr["Status_"]
                    });
            }
            return os;
        }

    }
}
