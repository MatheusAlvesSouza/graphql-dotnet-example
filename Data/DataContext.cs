using api.Models;
using System.Collections.Generic;

namespace api.Data
{
    public class DataContext
    {
        private List<Filme> _filmes;

        public DataContext()
        {
            this._filmes = new List<Filme>();
        }

        public List<Filme> GetFilmes()
        {
            return this._filmes;
        }

        public void AddFilme(Filme filme)
        {
            this._filmes.Add(filme);
        }
    }
}