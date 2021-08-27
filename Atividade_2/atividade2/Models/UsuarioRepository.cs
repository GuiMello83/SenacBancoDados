using System.Collections.Generic;
using MySqlConnector;
using System;

namespace atividade2.Models
{
    public class UsuarioRepository
    {
        // precisa ter as credenciais de acesso ao banco de dados
        private const string DadosConexao = "Database=SenacTur;Data Source=localhost;User Id=root";
        //fazendo as operações de manipulações de registros da talela usuario
        //crud - Inserir(insert), Listar(select), Alterar(update), excluir E usuários (delete)

        public void TestarConexao()
        {

            //informar a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            //abrir uma conexão 
            Conexao.Open();

            //imprimir uma mensagem de tudo funcionando
            Console.WriteLine("Banco de dados funcionando");

            // fechar uma conexão
            Conexao.Close();
        }

        public Usuario ValidarLogin(Usuario user){

             MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String QuerySql = "select * from Usuario WHERE Login=@Login and Senha=@Senha";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            //iremos iniciarlizar o obje Usuario Encontrado como null porque se encontrar o Reader não for encontrado, responde null.
            Usuario UsuarioEncontrado = null;

            if (Reader.Read()){

            UsuarioEncontrado = new Usuario();

            UsuarioEncontrado.Id = Reader.GetInt32("Id");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            UsuarioEncontrado.Nome = Reader.GetString("Nome");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
            UsuarioEncontrado.Login = Reader.GetString("Login");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
            UsuarioEncontrado.Senha = Reader.GetString("Senha");
            
            UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close();

            return UsuarioEncontrado;

        }

        public void Excluir(Usuario user)
        {
            //abrir a conexão com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //query em sql para excluir(delete para excluir registro / drop para excluir estrutura ou banco de dados)
            String QuerySql = "delete from Usuario WHERE Id=@Id";

            //preparar um comando, passando: sql + conexão com banco de dados
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            //tratamento devido ao sql injection
            Comando.Parameters.AddWithValue("@Id", user.Id);

            //executar o comando no banco de dados
            Comando.ExecuteNonQuery();

            //fechar a conexão com o banco de dados
            Conexao.Close();
        }

        public void Alterar(Usuario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String QuerySql = "update Usuario set Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);
            Comando.Parameters.AddWithValue("@Id", user.Id);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Inserir(Usuario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String QuerySql = "Insert into Usuario (Nome, Login, Senha, DataNascimento) values (@Nome, @Login, @Senha, @DataNascimento)";
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public List<Usuario> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String QuerySql = "select * from Usuario";
            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

            while (Reader.Read())
            {
                //percorre todos os regisror retornados no bando de dados (obj. Reader)
                Usuario userEncontrado = new Usuario();

                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    userEncontrado.Senha = Reader.GetString("Senha");

                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

                Lista.Add(userEncontrado);
            }

            Conexao.Close();

            return Lista;

        }
        public Usuario BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String QuerySql = "select * from Usuario WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();

            if (Reader.Read()){
            UsuarioEncontrado.Id = Reader.GetInt32("Id");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            UsuarioEncontrado.Nome = Reader.GetString("Nome");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Login")))
            UsuarioEncontrado.Login = Reader.GetString("Login");

            if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
            UsuarioEncontrado.Senha = Reader.GetString("Senha");
            
            UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close();

            return UsuarioEncontrado;
        }

    }
}