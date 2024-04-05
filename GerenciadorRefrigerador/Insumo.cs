using System;

namespace GerenciadorRefrigerador
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime DataValidade { get; set; }

        public Insumo(int id, string tipo, DateTime dataValidade)
        {
            Id = id;
            Tipo = tipo;
            DataValidade = dataValidade;
        }
    }
}