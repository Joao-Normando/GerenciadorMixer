using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRefrigerador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Equipamento> equipamentos = new List<Equipamento>();

            while (true)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1. Cadastrar equipamento");
                Console.WriteLine("2. Visualizar todos os insumos");
                Console.WriteLine("3.  Checkin do insumo");
                Console.WriteLine("4.  Checkout do insumo");
                Console.WriteLine("5. Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarEquipamento(equipamentos);
                        break;
                    case 2:
                        VisualizarInsumos(equipamentos);
                        break;
                    case 3:
                        RealizarCheckin(equipamentos);
                        break;
                    case 4:
                        RealizarCheckout(equipamentos);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarEquipamento(List<Equipamento> equipamentos)
        {
            Console.WriteLine("Informe o tipo (Refrigerador/Mixer):");
            string tipo = Console.ReadLine();

            Console.WriteLine("Informe o nome do equipamento:");
            string nome = Console.ReadLine();

            int id = equipamentos.Count + 1;
            Equipamento equipamento = new Equipamento(id, nome);
            equipamentos.Add(equipamento);

            Console.WriteLine("Equipamento cadastrado com sucesso!");
        }

        static void VisualizarInsumos(List<Equipamento> equipamentos)
        {
            Console.WriteLine("Insumos nos equipamentos:");
            foreach (var equipamento in equipamentos)
            {
                Console.WriteLine($"Equipamento: {equipamento.Nome}");
                foreach (var insumo in equipamento.Insumos)
                {
                    Console.WriteLine("ID: {insumo.Id}, Tipo: {insumo.Tipo}, Data de Validade: {insumo.DataValidade}");
                }
                Console.WriteLine();
            }
        }

        static void RealizarCheckin(List<Equipamento> equipamentos)
        {
            Console.WriteLine("Informe o ID do equipamento:");
            int idEquipamento = int.Parse(Console.ReadLine());

            Equipamento equipamento = equipamentos.FirstOrDefault(e => e.Id == idEquipamento);
            if (equipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Console.WriteLine("Informe o tipo do insumo:");
            string tipoInsumo = Console.ReadLine();

            Console.WriteLine("Informe a data de validade (dd/mm/aaaa):");
            DateTime dataValidade = DateTime.Parse(Console.ReadLine());

            int idInsumo = equipamento.Insumos.Count + 1;
            Insumo insumo = new Insumo(idInsumo, tipoInsumo, dataValidade);
            equipamento.AdicionarInsumo(insumo);

            Console.WriteLine("Checkin realizado!");
        }

        static void RealizarCheckout(List<Equipamento> equipamentos)
        {
            Console.WriteLine("Informe o ID do equipamento:");
            int idEquipamento = int.Parse(Console.ReadLine());

            Equipamento equipamento = equipamentos.FirstOrDefault(e => e.Id == idEquipamento);
            if (equipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Console.WriteLine("Informe o ID insumo:");
            int idInsumo = int.Parse(Console.ReadLine());

            equipamento.RemoverInsumo(idInsumo);

            Console.WriteLine("Checkout realizado!");
        }
    }
}
