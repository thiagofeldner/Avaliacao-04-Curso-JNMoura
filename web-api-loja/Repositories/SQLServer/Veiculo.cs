using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace web_api_loja.Repositories.SQLServer
{
    public class Veiculo
    {
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        public Veiculo(string connectionString) 
        {
            this.conn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand
            {
                Connection = conn
            };
        }

        public List<Models.Veiculo> Select()
        {
            List<Models.Veiculo> veiculos = new List<Models.Veiculo> ();

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    this.cmd.CommandText = "select id, marca ,nome, anomodelo, datafabricacao, valor, opcionais from veiculos";

                    using (SqlDataReader dr = this.cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Models.Veiculo veiculo = new Models.Veiculo();

                            veiculo.Id = (int)dr["id"];
                            veiculo.Marca = dr["marca"].ToString();
                            veiculo.Nome = dr["nome"].ToString();
                            veiculo.AnoModelo = (int)dr["anomodelo"];
                            veiculo.DataFabricacao = Convert.ToDateTime(dr["datafabricacao"]);
                            veiculo.Valor = (decimal)dr["valor"];

                            if(!(dr["opcionais"] is DBNull))
                                veiculo.Opcionais = dr["opcionais"].ToString();

                            veiculos.Add(veiculo);
                        }
                    }
                }

            }
            return veiculos;
        }

        public Models.Veiculo Select(int id)
        {
            Models.Veiculo veiculo = null;

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    this.cmd.CommandText = "select id, marca ,nome, anomodelo, datafabricacao, valor, opcionais from veiculos where id = @id";
                    this.cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                    using (SqlDataReader dr = this.cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            veiculo = new Models.Veiculo();
                            veiculo.Id = (int)dr["id"];
                            veiculo.Marca = dr["marca"].ToString();
                            veiculo.Nome = dr["nome"].ToString();
                            veiculo.AnoModelo = (int)dr["anomodelo"];
                            veiculo.DataFabricacao = Convert.ToDateTime(dr["datafabricacao"]);
                            veiculo.Valor = (decimal)dr["valor"];

                            if (!(dr["opcionais"] is DBNull))
                                veiculo.Opcionais = dr["opcionais"].ToString();
                        }
                    }
                }
            }
            return veiculo;
        }

        public List<Models.Veiculo> Select(string nome)
        {
            List<Models.Veiculo> veiculos = new List<Models.Veiculo>();

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    this.cmd.CommandText = "select id, marca ,nome, anomodelo, datafabricacao, valor, opcionais from veiculos where nome like @nome;";
                    this.cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = $"%{nome}%";

                    using (SqlDataReader dr = this.cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Models.Veiculo veiculo = new Models.Veiculo();

                            veiculo.Id = (int)dr["id"];
                            veiculo.Marca = dr["marca"].ToString();
                            veiculo.Nome = dr["nome"].ToString();
                            veiculo.AnoModelo = (int)dr["anomodelo"];
                            veiculo.DataFabricacao = Convert.ToDateTime(dr["datafabricacao"]);
                            veiculo.Valor = (decimal)dr["valor"];
                            
                            if(!(dr["opcionais"] is DBNull))
                                veiculo.Opcionais = dr["opcionais"].ToString();

                            veiculos.Add(veiculo);
                        }
                    }
                }
            }
            return veiculos;
        }

        public bool Insert(Models.Veiculo veiculo)
        {
            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    this.cmd.CommandText = "insert into veiculos(marca, nome, anomodelo, datafabricacao, valor, opcionais) " +
                        "values(@marca, @nome, @anomodelo, @datafabricacao, @valor, @opcionais); " +
                        "select convert(int,scope_identity());";

                    this.cmd.Parameters.Add(new SqlParameter("@marca", SqlDbType.VarChar)).Value = veiculo.Marca;
                    this.cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = veiculo.Nome;
                    this.cmd.Parameters.Add(new SqlParameter("@anomodelo", SqlDbType.Int)).Value = veiculo.AnoModelo;
                    this.cmd.Parameters.Add(new SqlParameter("@datafabricacao", SqlDbType.Date)).Value = veiculo.DataFabricacao;
                    this.cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.Decimal)).Value = veiculo.Valor;

                    if (veiculo.Opcionais != null)
                        cmd.Parameters.Add(new SqlParameter("@opcionais", SqlDbType.VarChar)).Value = veiculo.Opcionais;
                    else
                        cmd.Parameters.Add(new SqlParameter("@opcionais", SqlDbType.VarChar)).Value = DBNull.Value;

                    veiculo.Id = (int)cmd.ExecuteScalar();
                }
            }
            return veiculo.Id != 0;
        }

        public bool Update(Models.Veiculo veiculo)
        {
            int linhasAfetadas = 0;

            using(this.conn)
            {
                this.conn.Open();

                using(this.cmd)
                {
                    this.cmd.CommandText = "update veiculos set marca = @marca, nome = @nome, anomodelo = @anomodelo," +
                        " datafabricacao = @datafabricacao, valor = @valor, opcionais = @opcionais where id = @id;";

                    this.cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = veiculo.Id;
                    this.cmd.Parameters.Add(new SqlParameter("@marca", SqlDbType.VarChar)).Value = veiculo.Marca;
                    this.cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = veiculo.Nome;
                    this.cmd.Parameters.Add(new SqlParameter("@anomodelo", SqlDbType.Int)).Value = veiculo.AnoModelo;
                    this.cmd.Parameters.Add(new SqlParameter("@datafabricacao", SqlDbType.Date)).Value = veiculo.DataFabricacao;
                    this.cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.Decimal)).Value = veiculo.Valor;
                    this.cmd.Parameters.Add(new SqlParameter("@opcionais", SqlDbType.VarChar)).Value = veiculo.Opcionais;

                    linhasAfetadas = this.cmd.ExecuteNonQuery();
                }
            }
            return linhasAfetadas == 1;
        }

        public bool Delete(int id)
        {
            int linhasAfetadas = 0;

            using (this.conn)
            {
                this.conn.Open();

                using (this.cmd)
                {
                    this.cmd.CommandText = "delete from veiculos where id = @id;";
                    this.cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                    linhasAfetadas = this.cmd.ExecuteNonQuery();
                }
            }

            return linhasAfetadas == 1;
        }
    }
}