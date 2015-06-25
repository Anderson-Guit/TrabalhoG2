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

            sql.Append("INSERT INTO OrdemServico (Equipamento, Marca, Modelo, NumeroSerie, Defeito, Servico, Local_, Observacoes, Status_)");
            sql.Append("VALUES(@Equipamento, @Marca, @Modelo, @NumeroSerie, @Defeito, @Servico, @Local, @Observacoes, @Status)");

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

            sql.Append("UPDATE OrdemServico SET Equipamento=@Equipamento, Marca=@Marca, Modelo=@Modelo, NumeroSerie=@NumeroSerie, Defeito=@Defeito, Servico=@Servico, Local=@Local_, Observacoes=@Observacoes, Status=@Status_");
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

            sql.Append("SELECT * ");
            sql.Append("FROM OrdemServico ");
            sql.Append("WHERE IdOS=" + pId);

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = (int)dr["IdOS"];
                os.Equipamento = (String)dr["Equipamento"];
                os.Marca = (String)dr["Marca"];
                os.Modelo = (String)dr["Modelo"];
                os.NumeroSerie = (String)dr["NumeroSerie"];
                os.Defeito = (String)dr["Defeito"];
                os.Servico = (String)dr["Servico"];
                os.Local = (String)dr["Local_"];
                os.Observacoes = (String)dr["Observacoes"];
                os.Status = (String)dr["Status_"];
            }
            return os;
        }

        public static List<OrdemServico> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

            sql.Append("SELECT * ");
            sql.Append("FROM OrdemServico");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.Add(
                    new OrdemServico
                    {
                        IdOS = (int)dr["IdOS"],
                        Equipamento = (String)dr["Equipamento"],
                        Marca = (String)dr["Marca"],
                        Modelo = (String)dr["Modelo"],
                        NumeroSerie = (String)dr["NumeroSerie"],
                        Defeito = (String)dr["Defeito"],
                        Servico = (String)dr["Servico"],
                        Local = (String)dr["Local_"],
                        Observacoes = (String)dr["Observacoes"],
                        Status = (String)dr["Status_"]
                    });
            }
            return os;
        }

    }
}
