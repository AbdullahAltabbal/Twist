using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;

namespace Twist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo und Willkommen in Twisten Spiel! ");
            // while Schleife damit das Program sich wiederholt, falls falschen Wert eingegeben wurde
            bool again = true;
            while (again == true)
            {
                Console.WriteLine("Bitte gebe 1 wenn Sie ein Wort twisten möchten oder die 2 wenn Sie ein Wort entwisten möchten : ");
                var input = Convert.ToInt32(Console.ReadLine());
                // Eingabe für Twisten
                if (input == 1)
                {
                    Console.WriteLine("Bitte geben Sie ein Wort zu Twisten : ");
                    var wort = Console.ReadLine();
                    var getwistet = TwistWord(wort);
                    Console.WriteLine("Das Wort getwistet ist : " + getwistet);
                    again = false;
                    break;
                }
                // Eingabe für enttwisten 
                else if (input == 2)
                {
                    Console.WriteLine("Bitte geben Sie ein Wort zu enttwisten  (Bitte schreiben Sie die erste Buchtabe beim Nomen groß) : ");
                    var wort = Console.ReadLine();
                    var enttwistet = Untwist_wort(wort);
                    Console.WriteLine("Das Wort enttwistet ist : " + enttwistet);
                    again = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Sie sollen 1 oder 2 eingeben, ist das so schwer ? versuchen Sie noch mal ");
                    again = true;
                }
            }
        }
        // Method zum Twisten 
        public static string TwistWord(string Wort)
        {
            List<char> buchtaben = Wort.ToList();
            // wenn die lange des Wortes mehr als 3 Buchtaben ist, dann kann es nicht getwistet werden
            if (Wort.Length > 3)
            {
                char erstBuchtabe = buchtaben[0];
                char letzteBuchtabe = buchtaben[buchtaben.Count - 1];

                List<char> ohneAnfangEnde = new List<char>();
                for (int i = 1; i < Wort.Length - 1; i++)
                {
                    ohneAnfangEnde.Add(buchtaben[i]);
                }
                ohneAnfangEnde.Reverse();
                ohneAnfangEnde.Add(letzteBuchtabe);
                ohneAnfangEnde.Insert(0, erstBuchtabe);

                var neuWort = new string(ohneAnfangEnde.ToArray());
                return neuWort;
            }
            else return null;
        }
        // Method zum Enttwisten
        public static string Untwist_wort(string Wort)
        {
            List<char> buchtaben = Wort.ToList();
            if (Wort.Length > 3)
            {
                char _firstLetter = buchtaben[0];
                char _lastLetter = buchtaben[buchtaben.Count - 1];
                string Wörter = Properties.Resources.woerterliste;
                string[] words = Wörter.Split();
                var List_geramn_words = new List<string>();
                foreach (string word in words)
                {
                    List_geramn_words.Add(word);
                }
                foreach (string word in List_geramn_words)
                {  
                    List<char> wordInTheList = word.ToList();
                    char firstLetter = wordInTheList[0];
                    char lastLetter = wordInTheList[wordInTheList.Count - 1];
                    if (_firstLetter == firstLetter && _lastLetter == lastLetter)
                    {
                        if (wordInTheList.Count() == Wort.Count())
                        {
                            wordInTheList.Sort();
                            buchtaben.Sort();
                            if (Enumerable.SequenceEqual(buchtaben, wordInTheList))
                            {
                                return word;
                            }
                        }
                    }
                }
                return null;
            }
            else { return null; }
        }
    }
}
