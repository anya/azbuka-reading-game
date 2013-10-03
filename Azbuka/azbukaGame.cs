using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Azbuka
{
    public class azbukaGame
    {
        public enum FirstLetterCondition {Any, AllSame, AllDifferent};

        public const int MAX_ATTEMPTS = 2;
        string baseDir = @"D:\Anuta\Programming\Azbuka\";
        char[] letters = {'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П',
                          'Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ы','Э','Ю','Я'};
        List<wordInfo> words;
        List<string> categories;
        Dictionary<char, List<wordInfo>> wordsByLetter;
        Dictionary<int, List<wordInfo>> wordsByLength;
        Dictionary<string, List<wordInfo>> wordsByCategory;
        string[] questions;
        string[] answersYes;
        string[] answersNo;

        Random rnd;

        public azbukaGame()
        {
            rnd = new Random();
            words = new List<wordInfo>();
            categories = new List<string>();
            wordsByLetter = new Dictionary<char, List<wordInfo>>();
            wordsByLength = new Dictionary<int, List<wordInfo>>();
            wordsByCategory = new Dictionary<string, List<wordInfo>>();

            populate(baseDir + "words.csv");

            questions = Directory.GetFiles(baseDir + "Media", "question*.wav");
            answersYes = Directory.GetFiles(baseDir + "Media", "yes*.wav");
            answersNo = Directory.GetFiles(baseDir + "Media", "no*.wav");
        }

        public void populate(string inFileName)
        {
            StreamReader reader = new StreamReader(inFileName, Encoding.UTF8);
            string line;
            string [] parts;
            wordInfo wi;

            while((line = reader.ReadLine()) != null)
            {
                wi = new wordInfo();
                parts = line.Split(new char[] {',', '\t'});
                wi.wordLowerCase = parts[0];
                wi.wordLowerCaseHyphen = parts[1];
                wi.wordUpperCase = wi.wordLowerCase.ToUpper();
                wi.wordUpperCaseHyphen = wi.wordLowerCaseHyphen.ToUpper();
                //wi.soundFileName = baseDir + @"Media\" + parts[4];
                wi.imgFileName = baseDir + @"Media\" + parts[3];
                wi.category = parts[2];

                words.Add(wi);
                if (!categories.Contains(wi.category)) categories.Add(wi.category);
                if (!wordsByCategory.ContainsKey(wi.category)) wordsByCategory.Add(wi.category, new List<wordInfo>());
                wordsByCategory[wi.category].Add(wi);
                if (!wordsByLetter.ContainsKey(wi.wordUpperCase[0])) wordsByLetter.Add(wi.wordUpperCase[0], new List<wordInfo>());
                wordsByLetter[wi.wordUpperCase[0]].Add(wi);
                if (!wordsByLength.ContainsKey(wi.wordUpperCase.Length)) wordsByLength.Add(wi.wordUpperCase.Length, new List<wordInfo>());
                wordsByLength[wi.wordUpperCase.Length].Add(wi);
            }
            reader.Close();
        }

        /// <summary>
        /// Randomly select several distinct letters into a list, with one letter being 
        /// specified as obligatory.
        /// </summary>
        public List<char> getRandomLetters(int n, char mustInclude)
        {
            List<char> selectedLetters = new List<char>(n);
            int totalLetters = letters.Count();
            int mustIncludePos = rnd.Next(n);
            char let;
            for (int i = 0; i < n; i++)
            {
                if (i == mustIncludePos) 
                    let = mustInclude;
                else
                {
                    let = letters[rnd.Next(totalLetters)];
                    while (let == mustInclude || selectedLetters.Contains(let)) 
                        let = letters[rnd.Next(totalLetters)];
                }
                selectedLetters.Add(let);
            }
            return selectedLetters;
        }

        public qaFirstLetter getGame1Question(int nCandidateLetters)
        {
            qaFirstLetter qa = new qaFirstLetter();
            qa.wordData = words[rnd.Next(this.words.Count)];
            qa.candidateLetters = this.getRandomLetters(nCandidateLetters, qa.wordData.wordUpperCase[0]);
            return qa;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<wordInfo> getRandomWords(int n, FirstLetterCondition firstLetter)
        {
            wordInfo wd;
            List<wordInfo> wordList = new List<wordInfo>();
            List<char> letterList = new List<char>();
            if (n <= 0) return wordList;

            wd = words[rnd.Next(words.Count)];
            wordList.Add(wd);
            letterList.Add(wd.wordUpperCase[0]);

            if (firstLetter == FirstLetterCondition.AllSame)
            {
                List<wordInfo> haystack = wordsByLetter[wd.wordUpperCase[0]];
                n = Math.Min(n, haystack.Count);
                while (wordList.Count < n)
                {
                    wd = haystack[rnd.Next(haystack.Count)];
                    if (!wordList.Contains(wd))
                    {
                        wordList.Add(wd);
                    }
                }
            }
            else
            {
                n = Math.Min(n, words.Count);
                while (wordList.Count < n)
                {
                    wd = words[rnd.Next(words.Count)];
                    if (wordList.Contains(wd) || 
                        (firstLetter == FirstLetterCondition.AllDifferent && letterList.Contains(wd.wordUpperCase[0])))
                    {
                        continue;
                    } else 
                    {
                        wordList.Add(wd);
                        letterList.Add(wd.wordUpperCase[0]);
                    }
                }
            }
            return wordList;
        }

        public List<wordInfo> getRandomWords(int n, int numLettersMin, int numLettersMax)
        {
            wordInfo wd;
            List<wordInfo> ls = new List<wordInfo>();
            if (n <= 0) return ls;

            List<wordInfo> haystack = null;
            int i = numLettersMin;
            while (i <= numLettersMax)
            {
                if (wordsByLength.ContainsKey(i))
                {
                    if (haystack == null) haystack = wordsByLength[i];
                    else haystack = (haystack.Union((IEnumerable<wordInfo>)wordsByLength[i])).ToList<wordInfo>();
                }
                i++;
            }

            n = Math.Min(n, haystack.Count);
            while (ls.Count < n)
            {
                wd = haystack[rnd.Next(haystack.Count)];
                if (!ls.Contains(wd)) ls.Add(wd);
            }
            return ls;
        }

        public string getAnswer(bool correct)
        {
            if (correct) return answersYes[rnd.Next(answersYes.Count())];
            else return answersNo[rnd.Next(answersNo.Count())];
        }
    }

    public struct qaFirstLetter
    {
        public wordInfo wordData;
        public List<char> candidateLetters;
    }

    public struct wordInfo
    {
        public string wordLowerCase;
        public string wordUpperCase;
        public string wordLowerCaseHyphen;
        public string wordUpperCaseHyphen;
        public string category;
        public string imgFileName;
        public string soundFileName;
    }

    public class SingleWordQuestion
    {
        private wordInfo word;
        private List<char> candidateLetters;
        private char answerLetter;
        private int answerIndex;
        private int keyLetterPosition;

        public SingleWordQuestion(azbukaGame azbuka, int diff, int numLetters, Random r)
        {
            int minLen = 0;
            int maxLen = 20;
            switch (diff)
            {
                case 3:
                    minLen = 8;
                    maxLen = 20;
                    break;
                case 2:
                    minLen = 5;
                    maxLen = 7;
                    break;
                default:
                    minLen = 1;
                    maxLen = 4;
                    break;
            }

            word = azbuka.getRandomWords(1, minLen, maxLen)[0];
            if (r == null) keyLetterPosition = 0;
            else keyLetterPosition = r.Next(1, word.wordUpperCase.Length);
            answerLetter = word.wordUpperCase[keyLetterPosition];
            candidateLetters = azbuka.getRandomLetters(numLetters, answerLetter);
            answerIndex = candidateLetters.IndexOf(answerLetter);
        }

        public wordInfo Word
        {
            get
            {
                return word;
            }
        }
        public string MissingLetterText
        {
            get
            {
                char[] chars = word.wordUpperCase.ToCharArray();
                chars[keyLetterPosition] = '_';
                string txt = new string(chars);
                return txt;
            }
        }
        public int AnswerIndex
        {
            get
            {
                return answerIndex;
            }
        }
        public List<char> CandidateLetters
        {
            get
            {
                return candidateLetters;
            }
        }
        public char AnswerLetter
        {
            get
            {
                return answerLetter;
            }
        }
        public string PictureFile
        {
            get
            {
                return word.imgFileName;
            }
        }
    }

    public class MultiWordQuestion
    {
        private List<wordInfo> words;
        private int answerIndex;

        public MultiWordQuestion()
        {
            words = new List<wordInfo>();
            answerIndex = 0;
        }

        public MultiWordQuestion(List<wordInfo> wordList, int answer)
        {
            words = wordList;
            answerIndex = answer;
        }

        public List<wordInfo> Words
        {
            get
            {
                return words;
            }
            set
            {
                words = value;
            }
        }
        public int AnswerIndex
        {
            get
            {
                return answerIndex;
            }
            set
            {
                if (value < 0) answerIndex = 0;
                else if (value >= words.Count) answerIndex = words.Count - 1;
                else answerIndex = value;
            }
        }
    }
}
