using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        public RepositorioFabricante repositorioFabricante;
        
        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine();
        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastro de Fabricante");
            Console.WriteLine("2 - Visualizar Fabricante");
            Console.WriteLine("3 - Editar Fabricante");
            Console.WriteLine("4 - Excluir Fabricante");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("Cadastro de Equipamentos");

            Console.WriteLine();

            Fabricante fabricante = ObterDados();

            repositorioFabricante.CadastrarFabricante(fabricante);

            Console.WriteLine($"\nFabricante \"{fabricante.nome}\" cadastrado com sucesso!");
            Console.ReadLine();
        }

        internal void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Fabricantes");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -20}",
                "Id", "Nome", "Telefone", "E-Mail"
            );

            Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricante();

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante e = fabricantes[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -15} | {3, -20}",
                    e.id, e.nome, e.telefone, e.email
                );
            }

            Console.ReadLine();
        }

        internal void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("Edição de Fabricante");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Fabricante fabricanteAtualizado = ObterDados();

            bool conseguiuEditar = repositorioFabricante.EditarFabricante(idSelecionado, fabricanteAtualizado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nEquipamento \"{fabricanteAtualizado.nome}\" editado com sucesso!");
            Console.ReadLine();
        }

        internal void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("Exclusão de Fabricantes");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi possível encontrar o registro selecionado.");
                Console.ReadLine();

                return;
            }

            Console.WriteLine($"\nFabricante excluído com sucesso!");
            Console.ReadLine();
        }

        public Fabricante ObterDados()
        {
            Console.WriteLine("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o e-mail do fabricante: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o telefone do fabricante: ");
            string email = Console.ReadLine();

            Fabricante fabricante = new Fabricante();
            fabricante.nome = nome;
            fabricante.telefone = telefone;
            fabricante.email = email;

            return fabricante;
        }

    }

}
