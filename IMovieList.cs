using MovieGalore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieGalore
{
   public interface IMovieList
    {
        public IEnumerable<Movies> GetMovies();
        public Movies GetMovies(int ID);
        public void UpdateMovies(Movies movie);
        public void InsertMovie(Movies movieToInsert);
        public IEnumerable<Category> GetCategories();
        public Movies AssignCategory();
        public void DeleteMovie(Movies movie);


    }
}
