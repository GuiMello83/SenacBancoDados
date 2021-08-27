using System.Collections.Generic;
using MySqlConnector;
using System;

namespace atividade2.Models
{
    public class PacotesTuristicosRepository
    {
        private const string DadosConexao = "Database=SenacTur;Data Source=localhost;User Id=root";
        /* public void TestarConexao()
        {
            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            Console.WriteLine("Banco de dados Pacotes funcionando");

            Conexao.Close();
        } */

         public void Excluir(PacotesTuristicos pacote)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "delete from PacotesTuristicos WHERE Id=@Id";


            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);


            Comando.Parameters.AddWithValue("@Id", pacote.Id);


            Comando.ExecuteNonQuery();


            Conexao.Close();
        }

        public void Alterar(PacotesTuristicos pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String QuerySql = "update PacoteTuristico set Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);
            Comando.Parameters.AddWithValue("@Id", pacote.Id);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

         public void Inserir(PacotesTuristicos pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String QuerySql = "Insert into PacotesTuristicos (Nome, Origem, Destino, Atrativos, Saida, Retorno,  Usuario) values (@Nome, @Origem, @Destino,  @Atrativos, @Saida, @Retorno, @Usuario)";
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }
        public List<PacotesTuristicos> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String QuerySql = "select * from PacotesTuristicos";
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>();

            while (Reader.Read())
            {
                //percorre todos os regisror retornados no bando de dados (obj. Reader)
                PacotesTuristicos pacoteEncontrado = new PacotesTuristicos();

                pacoteEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    pacoteEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pacoteEncontrado.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pacoteEncontrado.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pacoteEncontrado.Atrativos = Reader.GetString("Atrativos");

                pacoteEncontrado.Saida = Reader.GetDateTime("Saida");

                pacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");

                pacoteEncontrado.Usuario = Reader.GetInt32("Usuario");

                Lista.Add(pacoteEncontrado);
            }

            Conexao.Close();

            return Lista;

        }

         public PacotesTuristicos BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String QuerySql = "select * from PacotesTuristicos WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);
            MySqlDataReader Reader = Comando.ExecuteReader();

            PacotesTuristicos PacoteEncontrado = new PacotesTuristicos();

            if (Reader.Read()){
            PacoteEncontrado.Id = Reader.GetInt32("Id");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            PacoteEncontrado.Nome = Reader.GetString("Nome");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
            PacoteEncontrado.Origem = Reader.GetString("Origem");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
            PacoteEncontrado.Destino = Reader.GetString("Destino");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
            PacoteEncontrado.Atrativos = Reader.GetString("Atrativos");
            
            PacoteEncontrado.Saida = Reader.GetDateTime("Saida");

            PacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");

            PacoteEncontrado.Usuario = Reader.GetInt32("Usuario");
            }

            Conexao.Close();

            return PacoteEncontrado;
        }


        
    }
}