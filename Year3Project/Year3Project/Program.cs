// See https://aka.ms/new-console-template for more information
using Year3Project;
using System;
using System.Linq;
using System.Threading;
using Year3Project.Model;
using Year3Project.Controller;

namespace Year3Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filme = File.ReadAllLines("Films.txt");
            FilmController filmController = new FilmController(Film.FilmObjectsFromDatafile(filme));
            
            // Store what they want for later.
            Console.WriteLine("Please input the type of genre you wish to test: Western, Action, Thriller or Comedy");
            string inputGenre = Console.ReadLine();
            
            filmController.GetOutputShotsFromGenre(inputGenre);
            filmController.GetMostCommonShots();
            filmController.MatchShotLibraryShotToFilmShot();
            filmController.SerializeFilm();


            Console.WriteLine("Hi");
        }

    }
}
