using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MovieGalore.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace MovieGalore
{
    public class MovieStore : IMovieList
    {
        private readonly IDbConnection _conn;

        public MovieStore(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Movies> GetMovies()
        {
            return _conn.Query<Movies>("Select * from new_movies.new_movies;") ;
        }
        public Movies GetMovies(int id)
        {
            return _conn.QuerySingle<Movies>("SELECT * FROM new_movies.new_movies WHERE ID = @id",
                new { id = id });
        }
        public void UpdateMovies(Movies movie)
        {
            _conn.Execute("UPDATE movies SET Name = @name, Price = @price WHERE ID = @id",
                new { name = movie.Name, price = movie.Price, id = movie.ID });
        }
        public void InsertMovie(Movies movieToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, Release Date) VALUES (@name, @price, @ReleaseDate);",
                new { name = movieToInsert.Name, price = movieToInsert.Price, categoryID = movieToInsert.ReleaseDate });
        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM Release Date;");
        }
        public Movies AssignCategory()
        {
            var categoryList = GetCategories();
            var movie = new Movies();
            movie.Categories = categoryList;

            return movie;
        }
        public void DeleteMovie(Movies movie)
        {
            _conn.Execute("DELETE FROM Ratings WHERE ID = @id;",
                                       new { id = movie.ID });
            _conn.Execute("DELETE FROM Name WHERE ID = @id;",
                                       new { id = movie.ID });
            _conn.Execute("DELETE FROM Movies WHERE ID = @id;",
                                       new { id = movie.ID });
        }



    }
}
