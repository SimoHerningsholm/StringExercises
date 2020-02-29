using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_exercises_strings_SimonHC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opgave01
            Console.WriteLine("Opgave01");
            Console.WriteLine(AddSeperator("ABCD", "^"));
            Console.WriteLine(AddSeperator("chocolate", "-"));
            //Opgave02
            Console.WriteLine("Opgave02");
            Console.WriteLine(IsPalindrome("eye"));
            Console.WriteLine(IsPalindrome("home"));
            //Opgave03
            Console.WriteLine("Opgave03");
            Console.WriteLine(LengthOfString("computer"));
            Console.WriteLine(LengthOfString("ice cream"));
            //Opgave04
            Console.WriteLine("Opgave04");
            Console.WriteLine(StringInReverseOrder("qwerty"));
            Console.WriteLine(StringInReverseOrder("oe93 kr"));
            //Opgave05
            Console.WriteLine("Opgave05");
            Console.WriteLine(NumberOfWords("This is sample sentence"));
            Console.WriteLine(NumberOfWords("OK"));
            //Opgave06
            Console.WriteLine("Opgave06");
            Console.WriteLine(RevertWordsOrder("John Doe."));
            Console.WriteLine(RevertWordsOrder("A, B. C"));
            Console.WriteLine(RevertWordsOrder("A, B. C, D."));
            //Opgave07
            Console.WriteLine("Opgave07");
            Console.WriteLine(HowManyOccurrences("do it now", "do"));
            Console.WriteLine(HowManyOccurrences("empty", "d"));
            //Opgave08
            Console.WriteLine("Opgave08");
            Console.WriteLine(SortCharactersDescending("onomatopoeia"));
            Console.WriteLine(SortCharactersDescending("fohjwf42os"));
            //Opgave09
            Console.WriteLine("Opgave09");
            Console.WriteLine(CompressString("kkkktttrrrrrrrrrr"));
            Console.WriteLine(CompressString("p555ppp7www"));
            Console.ReadLine();
        }
        static string CompressString(string a)
        {
            int counter = 0;
            string concatContainer = string.Empty;
            //Strengen modtager et symbol for at markere slutning på strengen
            a += "*";
            //der loopes igennem strengen
            for (int i = 0; i < a.Length-1; i++)
            {
                
                if(a[i] != a[i+1])
                {
                    //hvis det i'te index ikke er lig det næste skal concatcontainer modtage karakter for det i'te index samt antal karakteren er forekommet
                    //Det er vigtigt at lægge 1 til counteren da den pga algoritmens natur altid tæller 1 mindre end det antal der er.
                    concatContainer += a[i] + (counter + 1).ToString();
                    //counteren nulstilles før næste sekvens af ens karaktere der skal tælles
                    counter = 0;
                }
                else
                {
                    //såfremt næste karakter er lig den nuværene tælles counteren op
                    counter++;
                }
            }
            return concatContainer;
        }
        static string SortCharactersDescending(string a)
        {
            //(man kunne også have brugt den indbyggede sort funktion).
            //Hvert tal samt karakter i det dansk-norske alfabet holdes op imod et index i et array af integers.
            char[] alphabet = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å'};
            int[] Indexes = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39};
            //Alle "containers" der skal anvendes instancieres
            string concatContainer = string.Empty;
            List<int> indexObtainer = new List<int>();
            List<char> alphabetObtainer = new List<char>();
            List<int> SortedAlphabetIndexes = new List<int>();
            List<char> SortedAlphabetObtainer = new List<char>();
            //Der loopes igennem a
            for (int i = 0; i < a.Length; i++)
            {
                //For hver karakter i a holdes en karakter i alfabetet op imod.
                for (int j = 0; j < alphabet.Length; j++)
                {
                    //Hvis der opstår et match lagres index for match samt det tilsvarende bogstav i alfabetet i hver deres container.
                    if(a[i] == alphabet[j])
                    {
                        indexObtainer.Add(Indexes[j]);
                        alphabetObtainer.Add(alphabet[j]);
                    }
                }
            }
            //Der skal loopes igennem indexes og de skal sorteres descending. Der instancieres counter samt antal gange der skal loopes
            int counter = 0;
            int startAlphabetIndexLength = indexObtainer.Count;
            //Så længe counteren er under længren på liste der skal dannes skal listen dannes
            while(counter < startAlphabetIndexLength)
            {
                //Der instancieres integers til at finde sidste maxværdi samt index for maxværdi i indexObtainer array
                int potentialMax = indexObtainer[0];
                int potentialMaxIndex = 0;         
                for (int i = 0; i < indexObtainer.Count; i++)
                {
                    if(indexObtainer[i] >= potentialMax)
                    {
                        //Den skal finde sidste max værdi i indexobtainer og sætte den potentielle max værdi til denne værdi
                        //Derudover skal den finde index på denne maxværdi
                        potentialMax = indexObtainer[i];
                        potentialMaxIndex = i;
                    }
                }
                //Maxværdien sættes i liste for desc sorterede max værdier
                SortedAlphabetIndexes.Add(potentialMax);
                //Listen over sorterede alfabet værdier får værdi fra alfabetobtainer der ligger i samme index som max værdi for indexObtainer.
                //Dette giver en sorteret liste pga første loop lagrede værdi for alfabetObtainer samt indexObtainer synkront ud fra de to
                //lister over alfabetkaraktere samt index for alfabetkaraktere
                SortedAlphabetObtainer.Add(alphabetObtainer[potentialMaxIndex]);
                //For hver while iteration fjernes den indsatte karakter fra alfabetobtainer og indexobtainer så den ikke bliver ved med at finde samme værdi til indsætning
                //for hver iteration. Derudover incrementes counteren.
                alphabetObtainer.RemoveAt(potentialMaxIndex);
                indexObtainer.RemoveAt(potentialMaxIndex);
                counter++;
            }
            //En ny streng laves med karakterende i sorteret rækkefølge.
            for (int i = 0; i < SortedAlphabetObtainer.Count; i++)
            {
                concatContainer += SortedAlphabetObtainer[i];
            }
            return concatContainer;
        }
        static int HowManyOccurrences(string a, string b)
        {
            int counter = 0;
            //Der loopes igennem a, for at se om b findes inde i a. For ikke at loope ud af index, subtraheres længden på b fra a, i iterations betingelsen.
            for (int i = 0; i <= a.Length - b.Length; i++)
            {
                if(a.Substring(i, b.Length) == b)
                {
                    //hvis en streng med b's længde i den i'te iteration af a er lig b øges counteren med 1.
                    counter++;
                }
            }
            return counter;
        }
        static string RevertWordsOrder(string a)
        {
            List<string> words = new List<string>();
            List<string> wordsReversed = new List<string>();
            List<int> dotIndexes = new List<int>();
            string concatContainer = string.Empty;
            /*
             Algoritme:
             1. find hvert ord og lægges ind i et array af ord
             2. find ord med punktum og registrer index for punktum og fjern punktum
             3. Reverse rækkefølge på ord
             4. indsæt punktum i samme index på ord der har erstattet det gamle ords plads
             */

            //Der loopes igennem strengen
            for (int i = 0; i < a.Length; i++)
            {
                //concatcontainer fyldes med hvert ord medmindre der er talle om et mellemrum eller man befinder sig i sidste iteration
                concatContainer += a[i];
                if(a[i] == ' ' || i == a.Length-1)
                {
                    //er man nået til et mellemrum sættes ordet der er concatinated sammen i words og concatcontainer resettes
                    words.Add(concatContainer);
                    concatContainer = string.Empty;
                }
            }
            //Der loopes igennem ord
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if(words[i][j] == '.')
                    {
                        //hvis et index af den nuværende iteration af ord er lig punktum lagres ordets position i words listen og punktummet fjernes
                        dotIndexes.Add(i);
                        words[i] = words[i].Remove(j, 1);
                    }
                }
            }
            //Ordende bliver reversed
            for (int i = words.Count-1; i >= 0; i--)
            {
                wordsReversed.Add(words[i]);
            }
            //Der loopes igennem reversed ord
            for (int i = 0; i < wordsReversed.Count; i++)
            {
                for (int k = 0; k < dotIndexes.Count; k++)
                {
                    //Den skal sætte punktum for enden af hvert index hvor der har været punktum før de blev reversed
                    if(i == dotIndexes[k])
                    {
                        //hvis i er lig et dotindex sættes et punktum på det i'te ord.
                        wordsReversed[i] += ".";
                        for (int j = 0; j < wordsReversed[i].Length; j++)
                        {
                            if(wordsReversed[i][j] == ' ')
                            {
                                //Der opstår et mellemrum før punktummet pga koden før der loopes gennem reversed array. Dette mellemrum skal fjernes
                                wordsReversed[i] = wordsReversed[i].Remove(j, 1);
                            }
                        }
                    }
                }
            }
            //Der laves en ny streng hvor ordene er reversed og punktummer på grund af ovenstående kode stadig har deres plads.
            for (int i = 0; i < wordsReversed.Count; i++)
            {
                concatContainer += wordsReversed[i] + " ";
            }
            return concatContainer;
        }
        static int NumberOfWords(string a)
        {
            int counter;
            //Hvis strengen ikke indeholder nogen karaktere returneres der 0. Ellers starter strengen som udgangspunkt med ét ord.
            if(a.Length == 0)
            {
                return 0;
            }
            else
            {
                counter = 1;
            }
            //hver sammensætning af karaktere der har et mellemrum i mellem sig, betragtes som et ord.
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] == ' ')
                {
                    counter++;
                }
            }
            return counter;
        }
        static string StringInReverseOrder(string a)
        {
            string concatContainer = string.Empty;
            //Der itereres igennem strengen fra slut til start, og hver karakter fra slutningen til begyndelsen lægges oveni concatContaineren
            for (int i = a.Length - 1; i >= 0; i--)
            {
                concatContainer += a[i];
            }
            return concatContainer;
        }
        static int LengthOfString(string streng)
        {
            int counter = 0;
            //For hver karakter i strengen lægges der én til counteren.
            foreach(char karakter in streng)
            {
                counter++;
            }
            return counter;
        }
        static bool IsPalindrome(string streng)
        {
            //Der loopes igennem halvdelen af karakterene i strengen.
            for (int i = 0; i < streng.Length / 2; i++)
            {
                if(streng[i] != streng[streng.Length - 1 - i])
                {
                //hvis værdien af den nuværende position i strengen ikke er lig værdien på samme position relativt til slutningen af strengen, 
                //kan der ikke være tale om et palindrom
                    return false;
                }
            }
            return true;
        }
        static string AddSeperator(string streng, string seperator)
        {
            string concatContainer = string.Empty;
            //der loopes igennem hver karakter strengen består af.
            for (int i = 0; i < streng.Length; i++)
            {
                if(i != streng.Length-1)
                {
                    //Hvis vi ikke er igang med sidste iteration, sættes seperatoren foran karakteren den er nået til i strengen.
                    concatContainer += streng[i] + seperator;
                }
                else
                {
                    if(streng.Length % 2 == 0)
                    {
                        //Hvis vi er i sidste iteration og strengen udgøres af et ulige antal karakterer, sættes seperatoren ikke udenfor enden.
                        concatContainer += streng[i] + seperator;
                    }
                    else
                    {
                        //Hvis vi er i sidste iteration og strengen udgøres af et lige antal karakterer, sættes seperatoren også udenfor enden.
                        concatContainer += streng[i];
                    }
                }
            }
            return concatContainer;
        }
    }
}
