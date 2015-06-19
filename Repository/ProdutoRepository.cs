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
    public class ProdutoRepository
    {

        public void Create(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Produto (Nome, Descricao, Valor, QntdEstoque)");
            sql.Append("VALUES(@Nome, @Descricao, @Valor, @QntdEstoque)");

            cmd.Parameters.AddWithValue("@Nome", (pProduto.Nome));
            cmd.Parameters.AddWithValue("@Descricao", pProduto.Descricao);
            cmd.Parameters.AddWithValue("@Valor", pProduto.Valor);
            cmd.Parameters.AddWithValue("@QntdEstoque", pProduto.QntdEstoque);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Update(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("UPDATE Produto SET Nome=@Nome, Descricao=@Descricao, Valor=@Valor, QntdEstoque=@QntdEstoque");
            sql.Append("WHERE IdProduto=" + pProduto.IdProduto);

            cmd.Parameters.AddWithValue("@Nome", (pProduto.Nome));
            cmd.Parameters.AddWithValue("@Descricao", pProduto.Descricao);
            cmd.Parameters.AddWithValue("@Valor", pProduto.Valor);
            cmd.Parameters.AddWithValue("@QntdEstoque", pProduto.QntdEstoque);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM Produto ");
            sql.Append("WHERE IdProduto=" + pId);

            cmd.CommandText = sql.ToString();
            MySqlConn.CommandPersist(cmd);
        }

        public static Produto GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Produto produto = new Produto();

            sql.Append("SELECT * ");
            sql.Append("FROM Produto ");
            sql.Append("WHERE IdProduto=" + pId);

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                produto.IdProduto = (int)dr["IdProduto"];
                produto.Nome = (String)dr["Nome"];
                produto.Descricao = (String)dr["Descricao"];
                produto.Valor = (Double)dr["Valor"];
                produto.QntdEstoque = (int)dr["QntdEstoque"];

            }
            return produto;
        }

        public static List<Produto> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Produto> produto = new List<Produto>();

            sql.Append("SELECT * ");
            sql.Append("FROM Produto ");

            MySqlDataReader dr = MySqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                produto.Add(
                    new Produto
                    {
                        IdProduto = (int)dr["IdProduto"],
                        Nome = (String)dr["Nome"],
                        Descricao = (String)dr["Descricao"],
                        Valor = (Double)dr["Valor"],
                        QntdEstoque = (int)dr["QntdEstoque"],
                    });
            }
            return produto;
        }

    }
}
