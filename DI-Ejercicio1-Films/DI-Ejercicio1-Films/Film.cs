using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Ejercicio1_Films
{
    internal class Film
    {
        private string title;
        private int minutesLength;
        private string director;

        public Film()
        {

        }

        public Film(string title, int length, string director)
        {
            this.title = title;
            this.minutesLength = length;
            this.director = director;
        }

        public string Title { get => title; set => title = value; }
        public int MinutesLength { get => minutesLength; set => minutesLength = value; }
        public string Director { get => director; set => director = value; }

        public override string ToString()
        {
            string message = "";
            message += "Title: " + Title;
            message += "\nLength (minutes): " + MinutesLength;
            message += "\nFilm director: " + Director;
            return message;
        }
    }




}
