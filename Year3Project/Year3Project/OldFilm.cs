//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Threading;

//namespace Year3Project
//{
//    internal class OldFilm
//    {
//        public int MyProperty { get; set; }


//        private string genre;
//        private List<string> shots;
//        public OldFilm(string g)
//        {
//            genre = g;
//            shots = new List<string>();
//        }
//        public void Add(string shot)
//        {
//            shots.Add(shot);
//        }
//        public void Add(List<string> shotList)
//        {
//            shots.AddRange(shotList);
//        }
//        public void Add(string shot, int index)
//        {
//            shots.Insert(index, shot);
//        }
//        public void Add(List<string> shotList, int index)
//        {
//            shots.InsertRange(index, shotList);
//        }
//        public string getGenre() { return genre; }
//        public string getItem(int index)
//        {
//            return shots[index];
//        }
//        public int getListSize()
//        {
//            return shots.Count;
//        }
//        public static List<string> outputShots(string input, List<OldFilm> films)
//        {
//            List<OldFilm> matchingFilms = new List<OldFilm>();
//            List<string> output = new List<string>();
//            List<string> genres = new List<string>();
//            for (int i = 0; i < films.Count; i++)
//            {
//                genres.Add(films[i].getGenre()); //get all the genres of the films in the film list passed in
//            }
//            if (genres.Contains(input) != true) throw new InvalidGenre(input);
//            for (int i = 0; i < films.Count; i++)
//            {
//                if (input == films[i].getGenre()) matchingFilms.Add(films[i]); //find all films that match the genre inputted
//            }
//            int smallestList = 100000;
//            for (int i = 0; i < matchingFilms.Count; i++)
//            {
//                if (matchingFilms[i].getListSize() < smallestList)
//                {
//                    smallestList = matchingFilms[i].getListSize();
//                }
//            }
//            for (int i = 0; i < smallestList; i++)
//            {
//                List<string> currentShots = new List<string>(); //for each position, store a list of all the shots at this position
//                for (int j = 0; j < matchingFilms.Count; j++)
//                {
//                    currentShots.Add(matchingFilms[j].getItem(i));
//                }
//                ShotStatistics stats = new ShotStatistics(i, currentShots);
//                var common = currentShots.GroupBy(item => item).OrderByDescending(group => group.Count()).Select(group => group.Key).First(); //https://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint
//                output.Add(common); //find the most common shot from this shot sequence and add it to the output
//                //var common = (from item in currentShots
//                //              group item by item into group
//                //              orderby group.Count() descending
//                //              select group.Key).First();
//                stats.shotsBreakdown();

//            }
//            return output;
//        } //https://stackoverflow.com/questions/7470689/how-to-check-if-filename-contains-substring-in-c-sharp
//        public static void imageOutput(string genre, string shot)
//        {
//            string fileName = shot + ".png";
//            string imagePath = Path.Combine(genre, fileName);
//            var process = new Process();
//            process.StartInfo = new ProcessStartInfo(imagePath)
//            { UseShellExecute = true };
//            process.Start();
//            Thread.Sleep(1000);
//            process.Close();
//        }
//    }
//}
