using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Chamado");
        Console.WriteLine("2 - Visualizar Chamados");
        Console.WriteLine("3 - Editar Chamado");
        Console.WriteLine("4 - Excluir Chamado");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro de Chamados");

        Console.WriteLine();

        Chamado chamado = ObterDados();

        Console.WriteLine($"\nChamado \"{chamado.titulo}\" cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void EditarRegistro()
    {
        throw new NotImplementedException();
    }

    public void ExcluirRegistro()
    {
        throw new NotImplementedException();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        throw new NotImplementedException();
    }

    public Chamado ObterDados()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        DateTime dataAbertura = DateTime.Now;

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());


        return null;
    }

    public void VisualizarEquipamentos()
    {
        Console.WriteLine();

        Console.WriteLine("Visualização de Equipamentos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
            "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
        );

        Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -15}",
                e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
            );
        }

        Console.ReadLine();
    }
}
