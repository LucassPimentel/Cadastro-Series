using AppCadastroSeries.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroSeries.Entities
{
    public class TvShow : BaseTvShow
    {
        public TvShow(int id, string? title, Genres genre, string? description)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Description = description;
        }

        public string? Title { get; set; }
        public Genres Genre { get; set; }
        public string? Description { get; set; }


        public string GetTitle()
        {
            return Title;
        }

        public override string ToString()
        {
            return $"Título: {Title}{Environment.NewLine}" +
                $"Descrição: {Description}{Environment.NewLine}" +
                $"Gênero: {Genre}{Environment.NewLine}";
        }



    }
}
