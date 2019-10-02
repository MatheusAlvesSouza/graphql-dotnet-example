using System.Collections.Generic;

namespace api.Models
{
    public class Filme
    {
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int Ano { get; set; }
        public List<Ator> Atores { get; set; }
    }
}