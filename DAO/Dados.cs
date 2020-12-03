using System;
using MySql.Data.MySqlClient;
using CSharp_005_IDaoBase.Entidades;


public class BancoDados : EntidadeAluno
{
	public int InsereDados(EntidadeAluno aluno)
	{
		var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();
		
		try 
	    {	        
		    conexao.Open();
            command.CommandText = "INSERT INTO aluno (Nome, Matricula, CPF, Contato)" +
                                   "VALUES (?nome, ?matricula, ?cpf, ?contato)";

            command.Parameters.Add("?nome", MySqlDbType.VarChar).Value = aluno.Nome;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = aluno.Matricula;
            command.Parameters.Add("?cpf", MySqlDbType.VarChar).Value = aluno.CPF;
            command.Parameters.Add("?contato", MySqlDbType.VarChar).Value = aluno.Contato;
                
            Console.WriteLine("Dados Salvos em Banco aluno com sucesso!");
            command.ExecuteNonQuery();
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
            return (int)command.LastInsertedId;               
	    }
	    catch (Exception)
        {        
            return 0;
	    }

	}
}
public class BncDadosCurso : EntidadeCurso
{
    public int InsereDados2(EntidadeCurso curso)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "INSERT INTO curso (Curso, Nota1, Nota2, Nota3, Matricula)" +
                                   "VALUES (?curso, ?nota1, ?nota2, ?nota3, ?matricula)";

            command.Parameters.Add("?curso", MySqlDbType.VarChar).Value = curso.Curso;
            command.Parameters.Add("?nota1", MySqlDbType.Int32).Value = curso.Nota1;
            command.Parameters.Add("?nota2", MySqlDbType.Int32).Value = curso.Nota2;
            command.Parameters.Add("?nota3", MySqlDbType.Int32).Value = curso.Nota3;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = curso.Matricula1;

            Console.WriteLine("Dados Salvos em Banco curso com sucesso!");
            command.ExecuteNonQuery();
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
            return (int)command.LastInsertedId;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
public class BncDadosStatus : EntidadeStatus
{
    public int InsereDados3(EntidadeStatus status)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "INSERT INTO situacao (Media, Status, Matricula)" +
                                   "VALUES (?media, ?status, ?matricula)";

            command.Parameters.Add("?media", MySqlDbType.Int32).Value = status.Media;
            command.Parameters.Add("?status", MySqlDbType.VarChar).Value = status.Status;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = status.Matricula2;

            Console.WriteLine("Dados Salvos em Banco Status com sucesso!");
            command.ExecuteNonQuery();
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
            return (int)command.LastInsertedId;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}

public class MostraDadosAluno : EntidadeAluno
{
    public void MostrasInfo(EntidadeAluno aluno)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "SELECT Nome, Matricula, CPF, Contato FROM aluno WHERE Matricula = ?matricula || Nome = ?nome || CPF = ?cpf";
            command.Parameters.Add("?nome", MySqlDbType.VarChar).Value = aluno.Nome;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = aluno.Matricula;
            command.Parameters.Add("?cpf", MySqlDbType.VarChar).Value = aluno.CPF;

            MySqlDataReader ler = command.ExecuteReader();

            while (ler.Read())
            {
                Console.WriteLine($"Nome: {ler["Nome"]} \nMatricula: {ler["Matricula"]} \nCPF: {ler["CPF"]} \nContato: {ler["Contato"]}");
            }

            //Console.WriteLine("\n\n\t\tObrigado Volte sempre !!!");
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
            ler.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possível realizar a consulta");
            throw;
        }
    }
}
public class MostraDadosCurso : EntidadeCurso
{
    public void MostrasInfo2(EntidadeCurso curso)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "SELECT Curso, Nota1, Nota2, Nota3, Matricula FROM curso WHERE Matricula = ?matricula";            
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = curso.Matricula1;

            MySqlDataReader ler = command.ExecuteReader();

            while (ler.Read())
            {
                Console.WriteLine($"Curso {ler["Curso"]} \nNota 1: {ler["Nota1"]} \nNota 2: {ler["Nota2"]} \nNota 3: {ler["Nota3"]}");
            }

            //Console.WriteLine("\n\n\t\tObrigado Volte sempre !!!");
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
            ler.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possível realizar a consulta");
            throw;
        }
    }
}
public class MostraDadosStatus : EntidadeStatus
{
    public void MostrasInfo3(EntidadeStatus status)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "SELECT Media, Status, Matricula FROM situacao WHERE Matricula = ?matricula";
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = status.Matricula2;

            MySqlDataReader ler = command.ExecuteReader();

            while (ler.Read())
            {
                Console.WriteLine($"Media: {ler["Media"]} \nStatus: {ler["Status"]}");
            }

            Console.WriteLine("\n\n\t\tObrigado Volte sempre !!!");
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
            ler.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possível realizar a consulta");
            throw;
        }
    }
}
public class AlteraDadosAluno : EntidadeAluno
{
    public void AlteraDados(EntidadeAluno aluno)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "UPDATE aluno SET Nome = ?nome, CPF = ?cpf, Contato = ?contato WHERE Matricula = ?matricula";

            command.Parameters.Add("?nome", MySqlDbType.VarChar).Value = aluno.Nome;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = aluno.Matricula;
            command.Parameters.Add("?cpf", MySqlDbType.VarChar).Value = aluno.CPF;
            command.Parameters.Add("?contato", MySqlDbType.VarChar).Value = aluno.Contato;

            command.ExecuteNonQuery();
            Console.WriteLine("Dados Alterados com Sucesso.");
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();

        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possivel realizar as atualizações");
            throw;
        }
    }
}
public class AlteraDadosCurso : EntidadeCurso
{
    public void AlteraDados2(EntidadeCurso cursos)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "UPDATE curso SET Curso = ?curso, Nota1 = ?nota1, Nota2 = ?nota2, Nota3 = ?nota3 WHERE Matricula = ?matricula";

            command.Parameters.Add("?curso", MySqlDbType.VarChar).Value = cursos.Curso;
            command.Parameters.Add("?nota1", MySqlDbType.Int32).Value = cursos.Nota1;
            command.Parameters.Add("?nota2", MySqlDbType.Int32).Value = cursos.Nota2;
            command.Parameters.Add("?nota3", MySqlDbType.Int32).Value = cursos.Nota3;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = cursos.Matricula1;

            command.ExecuteNonQuery();
            Console.WriteLine("Dados Alterados com Sucesso.");
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();

        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possivel realizar as atualizações");
            throw;
        }
    }
}
public class AlteraDadosStatus : EntidadeStatus
{
    public void AlteraDados3(EntidadeStatus statuss)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "UPDATE situacao SET Media = ?media, Status = ?status WHERE Matricula = ?matricula";

            command.Parameters.Add("?media", MySqlDbType.Int32).Value = statuss.Media;
            command.Parameters.Add("?status", MySqlDbType.VarChar).Value = statuss.Status;
            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = statuss.Matricula2;

            command.ExecuteNonQuery();
            Console.WriteLine("Dados Alterados com Sucesso.");
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();

        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possivel realizar as atualizações");
            throw;
        }
    }
}
public class DeleteDadosAluno : EntidadeAluno
{
    public void DeleteDados(EntidadeAluno aluno)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "DELETE FROM aluno WHERE Matricula = ?matricula";

            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = aluno.Matricula;

            command.ExecuteNonQuery();

            Console.WriteLine("Cadastro deletado com sucesso!");

            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();


        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possivel DELETAR");
            throw;
        }
    }
}
public class DeleteDadosCurso : EntidadeCurso
{
    public void DeleteDados2(EntidadeCurso cursos)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "DELETE FROM curso WHERE Matricula = ?matricula";

            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = cursos.Matricula1;

            command.ExecuteNonQuery();

            Console.WriteLine("Cadastro deletado com sucesso!");

            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();


        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possivel DELETAR");
            throw;
        }
    }
}
public class DeleteDadosStatus : EntidadeStatus
{
    public void DeleteDados3(EntidadeStatus status)
    {
        var cnxstring = "Server=localhost;Database=escola;Uid=root;Pwd=";
        var conexao = new MySqlConnection(cnxstring);
        var command = conexao.CreateCommand();

        try
        {
            conexao.Open();
            command.CommandText = "DELETE FROM situacao WHERE Matricula = ?matricula";

            command.Parameters.Add("?matricula", MySqlDbType.VarChar).Value = status.Matricula2;

            command.ExecuteNonQuery();

            Console.WriteLine("Cadastro deletado com sucesso!");

            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();


        }
        catch (Exception)
        {
            Console.WriteLine("Não foi possivel DELETAR");
            throw;
        }
    }
}