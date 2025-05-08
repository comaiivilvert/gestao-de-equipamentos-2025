using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class RepositorioFabricante
    {
        public Fabricante[] fabricantes = new Fabricante[100];
        public int contadorFabricante = 0;
        
        public void CadastrarFabricante(Fabricante fabricante)
        {
            fabricantes[contadorFabricante] = fabricante;
            contadorFabricante++;
        }

        public bool EditarFabricante(int idSelecionado, Fabricante fabricanteAtualizado)
        {
            Fabricante fabricanteSelecionado = SelecionarFabricantePorId(idSelecionado);

            if (fabricanteSelecionado == null)
                return false;

            fabricanteSelecionado.nome = fabricanteAtualizado.nome;
            fabricanteSelecionado.email = fabricanteAtualizado.email;
            fabricanteSelecionado.telefone = fabricanteAtualizado.telefone;

            return true;
        }

        public bool ExcluirFabricante(int idSelecionado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null)
                    continue;

                if (fabricantes[i].id == idSelecionado)
                {
                    fabricantes[i] = null;

                    return true;
                }
            }

            return false;
        }

        public Fabricante SelecionarFabricantePorId(int idSelecionado)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante e = fabricantes[i];

                if (e == null)
                    continue;

                if (e.id == idSelecionado)
                    return e;
            }

            return null;
        }
        internal Fabricante[] SelecionarFabricante()
        {
            return fabricantes;
        }
    }
}
