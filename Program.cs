using System;

namespace CSharp_005_IDaoBase
{
    class CorpoPrincipal
    {
        static void Main(string[] args)
        {
            Funcoes.Menu();
        }
    }
    public class Funcoes 
    {
        public static void ColetaInfo()
        {
            BancoDados DadosAluno = new BancoDados();
            BncDadosCurso DadosCurso = new BncDadosCurso();
            BncDadosStatus DadosStatus = new BncDadosStatus();

            Console.WriteLine("Digite seu nome: ");
            DadosAluno.Nome = Console.ReadLine();
            Console.WriteLine("Digite sua Matricula: ");
            DadosAluno.Matricula = Console.ReadLine();
            Console.WriteLine("Digite seu CPF: ");
            DadosAluno.CPF = Console.ReadLine();
            Console.WriteLine("Digite um telefone para contato: ");
            DadosAluno.Contato = Console.ReadLine();
            Console.WriteLine("Qual seu Curso: ");
            DadosCurso.Curso = Console.ReadLine();
            Console.WriteLine("Digite suas notas a seguir AP1--AP2--AS\n");
            Console.WriteLine("Sua nota AP1: ");
            DadosCurso.Nota1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Sua nota AP2: ");
            DadosCurso.Nota2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Sua nota AS: ");
            DadosCurso.Nota3 = Int32.Parse(Console.ReadLine());
            DadosCurso.Matricula1 = DadosAluno.Matricula;
            DadosStatus.Matricula2 = DadosAluno.Matricula;
            DadosStatus.Media = (DadosCurso.Nota1 + DadosCurso.Nota2 + DadosCurso.Nota3)/3;
            if (DadosStatus.Media > 7)
                DadosStatus.Status = "APROVADO";
            else
                DadosStatus.Status = "REPROVADO";
            DadosAluno.InsereDados(DadosAluno);
            DadosCurso.InsereDados2(DadosCurso);
            DadosStatus.InsereDados3(DadosStatus);
            Console.ReadKey();
        }
        public static void ImprimirTela()
        {
            int smenu = 0;
            MostraDadosAluno mostraDados = new MostraDadosAluno();
            Console.WriteLine("Escolha como vai fazer sua busca: \n1 -> Matricula\n2 -> Nome\n3 -> CPF");
            smenu = Int32.Parse(Console.ReadLine());
            switch (smenu)
            {
                case 1:
                    Console.WriteLine("Digite sua Matricula:");
                    mostraDados.Matricula = Console.ReadLine();
                    mostraDados.MostrasInfo(mostraDados);
                    break;
                case 2:
                    Console.WriteLine("Digite Seu Nome:");
                    mostraDados.Nome = Console.ReadLine();
                    mostraDados.MostrasInfo(mostraDados);
                    break;
                case 3:
                    Console.WriteLine("Digite seu CPF:");
                    mostraDados.CPF = Console.ReadLine();
                    mostraDados.MostrasInfo(mostraDados);
                    break;
            }
            Console.ReadKey();
        }
        public static void ImprimirTela2()
        {
            MostraDadosCurso mostraDados = new MostraDadosCurso();
            MostraDadosStatus mostraDados1 = new MostraDadosStatus();

            Console.WriteLine("A busca realizada deve ser usando a sua matricula, verificar na opção 2 do MENU a sua matricula.");
            Console.WriteLine("\nDigite sua Matricula: ");
            mostraDados.Matricula1 = Console.ReadLine();
            mostraDados1.Matricula2 = mostraDados.Matricula1;
            mostraDados.MostrasInfo2(mostraDados);
            mostraDados1.MostrasInfo3(mostraDados1);
            Console.ReadKey();
        }
        public static void AlterarDados()
        {
            AlteraDadosAluno alteraAluno = new AlteraDadosAluno();
            AlteraDadosCurso alteraCurso = new AlteraDadosCurso();
            AlteraDadosStatus alteraStatus = new AlteraDadosStatus();

            Console.WriteLine("Os dados serão atualizados sobre os dados da MATRICULA correspondente.");
            Console.WriteLine("\nAtualizar Nome ... Digite:");
            alteraAluno.Nome = Console.ReadLine();
            Console.WriteLine("\nAtualizar CPF ... Digite:");
            alteraAluno.CPF = Console.ReadLine();
            Console.WriteLine("\nAtualizar Contato ... Digite:");
            alteraAluno.Contato = Console.ReadLine();
            Console.WriteLine("\nAtualizar Curso ... Digite:");
            alteraCurso.Curso = Console.ReadLine();
            Console.WriteLine("\nAtualizar Nota 1 ... Digite:");
            alteraCurso.Nota1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nAtualizar Nota 2 ... Digite:");
            alteraCurso.Nota2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nAtualizar Nota 3 ... Digite:");
            alteraCurso.Nota3 = Int32.Parse(Console.ReadLine());
            alteraStatus.Media = (alteraCurso.Nota1 + alteraCurso.Nota2 + alteraCurso.Nota3) / 3;
            if ( alteraStatus.Media > 7)
                alteraStatus.Status = "APROVADO";
            else
                alteraStatus.Status = "REPROVADO";
            Console.WriteLine("\nQual Matricula deseja atualizar?");
            alteraAluno.Matricula = Console.ReadLine();
            alteraCurso.Matricula1 = alteraAluno.Matricula;
            alteraStatus.Matricula2 = alteraAluno.Matricula;
            alteraAluno.AlteraDados(alteraAluno);
            alteraCurso.AlteraDados2(alteraCurso);
            alteraStatus.AlteraDados3(alteraStatus);
            Console.ReadKey();
        }
        public static void DeletarDados()
        {
            DeleteDadosAluno deleteAluno = new DeleteDadosAluno();
            DeleteDadosCurso deleteCurso = new DeleteDadosCurso();
            DeleteDadosStatus deleteStatus = new DeleteDadosStatus();

            Console.WriteLine("Informe a matricula do registro que deseja deletar: ");
            deleteAluno.Matricula = Console.ReadLine();
            deleteCurso.Matricula1 = deleteAluno.Matricula;
            deleteStatus.Matricula2 = deleteAluno.Matricula;
            deleteAluno.DeleteDados(deleteAluno);
            deleteCurso.DeleteDados2(deleteCurso);
            deleteStatus.DeleteDados3(deleteStatus);
            Console.ReadKey();
        }
        public static void Menu()
        {
            int menu = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine("[1]->Cadastro Aluno e Notas\n");
                Console.WriteLine("[2]->Visualizar Dados do Aluno\n");
                Console.WriteLine("[3]->Verificar Média e Status\n");
                Console.WriteLine("[4]->Alterar Dados\n");
                Console.WriteLine("[5]->Deletar Registro\n");
                Console.WriteLine("[6]->Sair\n");
                menu = Int32.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        ColetaInfo();
                        break;
                    case 2:
                        ImprimirTela();
                        break;
                    case 3:
                        ImprimirTela2();
                        break;
                    case 4:
                        AlterarDados();
                        break;
                    case 5:
                        DeletarDados();
                        break;
                    case 6:
                        Console.WriteLine("\nSaindo ...");
                        break;
                    default:
                        Console.WriteLine("\nCódigo Inválido!!");
                        break;
                }
            } while (menu != 6);
        }
    }

}
