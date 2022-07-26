using AppCadastroSeries.Entities;
using AppCadastroSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroSeries.Repositories
{
    public class TvShowRepository : IRepository<TvShow>
    {
        private List<TvShow> listTvShows = new();
        public void Delete(int id)
        {
            listTvShows.Remove(listTvShows[id]);
        }

        public void Insert(TvShow entity)
        {
            listTvShows.Add(entity);
        }

        public List<TvShow> GetList()
        {
            return listTvShows;
        }

        public int NextId()
        {
            return listTvShows.Count;
        }

        public TvShow ReturnById(int id)
        {
            return listTvShows[id];
        }

        public void Update(int id, TvShow entity)
        {
            listTvShows[id] = entity;
        }
    }
}
