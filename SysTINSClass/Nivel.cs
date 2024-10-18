using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTINSClass
{
    public class Nível
    {
        private string? sigla;

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Sigla { get; set; }

        public Nível() { } // método construtor

        public Nível(string? nome, string? sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
        public Nível(int id, string? nome, string? sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }

    }
}