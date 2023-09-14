using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Ejercicio1_Films
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our new-ultimate-modern-super-innovative car cinema!");
            Console.WriteLine("How much time would you like to spend here, as a maximum?");
            int maxMinutes = int.Parse(Console.ReadLine());

            Film[] films = AskForFilms();
            if (CheckForValidOptions(films, maxMinutes))
            {
                Film bestFilm = GetTheBestOption(maxMinutes, films);
                //Checking if there are more than a single film with the same optimal length
                int optimalOptions = CheckForMoreOptions(films, bestFilm);
                if (optimalOptions > 1)
                {
                    Console.WriteLine("Oh! It looks like we have multiple options for you. There you go:");
                    Film[] optimalFilms = GetAllTheValidFilms(films, bestFilm, optimalOptions);
                    foreach(Film film in optimalFilms)
                    {
                        Console.WriteLine("\n" + film);
                    }
                }
                else
                {
                    //There's only one optimal film
                    Console.WriteLine("The best option is to watch the next one: ");
                    Console.WriteLine(bestFilm);
                }
                Console.WriteLine("Be sure to grab your popcorns!");
            }
            else
            {
                Console.WriteLine("Whoopsie, it looks like you don't have enough time for any movie.\nWhat about some series...?");
            }
            Console.ReadKey();

        }

        
        //Asking for film data and creating an array of the given films
        private static Film[] AskForFilms()
        {
            Film[] films = new Film[3];
            Console.WriteLine("Let's see which are your 3 favourite films!");
            for (int i = 0; i < films.Length; i++)
            {
                Console.WriteLine((i+1) + "º film:");
                Console.WriteLine("Title: ");
                string title = Console.ReadLine();

                Console.WriteLine("Length (in minutes): ");
                int length = int.Parse(Console.ReadLine());

                Console.WriteLine("Film director: ");
                string directorName = Console.ReadLine();

                Film film = new Film(title, length, directorName);
                films[i] = film;

            }
            return films;
        }


        //Checks if there's at least one film with a lower (or equal) length than the maximum given minutes
        private static bool CheckForValidOptions(Film[] films, int maxMinutes)
        {
            bool isThereAValidFilm = false;
            foreach (Film film in films)
            {
                if (film.MinutesLength <= maxMinutes)
                {
                    isThereAValidFilm = true;
                }
            }
            return isThereAValidFilm;
        }


        //The best film would be the one with least minutes remaining
        private static Film GetTheBestOption(int maxMinutes, Film[] films)
        {
            Film bestFilm = films[0];
            int remainingMinutes = maxMinutes - films[0].MinutesLength;
            for(int i = 0; i < films.Length; i++)
            {
                //Conditional to exclude the calculation of the remaining minutes of that ones with a higher length
                if (films[i].MinutesLength <= maxMinutes)
                {
                    if((maxMinutes - films[i].MinutesLength) < remainingMinutes)
                    {
                        bestFilm = films[i];
                    }
                }
            }
            return bestFilm;
        }


        //Counts how many movies have the same length as the best one
        private static int CheckForMoreOptions(Film[] films, Film bestFilm)
        {
            int validFilmsCount = 0;
            foreach (Film film in films)
            {
                if (film.MinutesLength == bestFilm.MinutesLength)
                {
                    validFilmsCount++;
                }
            }
            return validFilmsCount;
        }


        //Returns all the movies with the same optimal length
        private static Film[] GetAllTheValidFilms(Film[] films, Film bestFilm, int optimalFilmCount)
        {
            Film[] validFilms = new Film[optimalFilmCount];
            int i = 0;
            foreach (Film film in films)
            {
                if(film.MinutesLength == bestFilm.MinutesLength)
                {
                    validFilms[i] = film;
                    i++;
                }
            }
            return validFilms;
        }
    }
}
