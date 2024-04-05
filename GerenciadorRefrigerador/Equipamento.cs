using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorRefrigerador
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Insumo> Insumos { get; set; }

        public Equipamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Insumos = new List<Insumo>();
        }

        public void AdicionarInsumo(Insumo insumo)
        {
            Insumos.Add(insumo);
        }
        public void RemoverInsumo(int idInsumo)
        {
            Insumo insumo = Insumos.FirstOrDefault(i => i.Id == idInsumo);
            if (insumo != null)
                Insumos.Remove(insumo);
            else
                Console.WriteLine("Insumo não encontrado!");
        }
    }
}