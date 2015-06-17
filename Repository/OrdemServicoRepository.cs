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
    class OrdemServicoRepository
    {

        public void Create(OrdemServico pOS)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO OrdemServico (Equipamento, Marca, Modelo, NumeroSerie, Defeito, Servico, Local, Observacoes, Status)");
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

            sql.Append("UPDATE OrdemServico SET Equipamento=@Equipamento, Marca=@Marca, Modelo=@Modelo, NumeroSerie=@NumeroSerie, Defeito=@Defeito, Servico=@Servico, Local=@Local, Observacoes=@Observacoes, Status=@Status");
            sql.Append("WHERE IdOS=" + pOS.IdOS);

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
                os.Equipamento = (String)dr["Equipamento"];
                os.Marca = (String)dr["Marca"];
                os.Modelo = (String)dr["Modelo"];
                os.NumeroSerie = (String)dr["NumeroSerie"];
                os.Defeito = (String)dr["Defeito"];
                os.Servico = (String)dr["Servico"];
                os.Local = (String)dr["Local"];
                os.Observacoes = (String)dr["Observacoes"];
                os.Status = (String)dr["Status"];
            }
            return os;
        }

    }
}
