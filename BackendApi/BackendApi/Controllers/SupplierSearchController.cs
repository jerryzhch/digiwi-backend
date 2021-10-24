using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierSearchController : ControllerBase
    {
        List<Solution> supplier = MockData.GetSuppliers();
        Dictionary<string, string> keywords = MockData.GetKeywords();
        static Dictionary<int, string> polls = new Dictionary<int, string>();

        private int GetInsertIndex(Models.KeywordMatch match, List<Models.KeywordMatch> sortedMatches)
        {
            for (int i = 0; i < sortedMatches.Count; i++)
            {
                if (match.Count > sortedMatches[i].Count) return i;
            }
            return sortedMatches.Count;
        }

        [HttpGet("keyWords")]
        public List<KeywordMatch> GetKeyWords()
        {
            var keywordList = new List<Models.KeywordMatch>();
            foreach(var key in keywords.Keys)
            {
                keywordList.Add(new KeywordMatch() { Keyword = key, Description = keywords[key] });
            }
            return keywordList;
        }

        [HttpGet("keyWordDescription")]
        public string GetKeyWords(string keyWord)
        {
            return keywords[keyWord];
        }

        [HttpGet("pollResult")]
        public List<KeywordMatch> GetPollResult(int pollId)
        {
            var pollresult = "";

            if (pollId > 10)
            {
                Random rnd = new Random(pollId);
                var keywordList = keywords.Keys.ToList();
                int count = rnd.Next(100) + 10;
                while (keywordList.Count > 0)
                {
                    int index = rnd.Next(keywordList.Count);
                    int score = rnd.Next(count);
                    count = count - count / 3 - score / 2;
                    for (int j = 0; j < score; j++)
                    {
                        pollresult += keywordList[index] + " ";
                    }
                    keywordList.RemoveAt(index);
                }
            }

            if(polls.ContainsKey(pollId))
            {
                pollresult += " " + polls[pollId];
            }

            return GetKeyWordFromFreeText(pollresult);
        }

        [HttpGet("updatePoll")]
        public List<KeywordMatch> UpdatePoll(int pollId, string update)
        {
            if(polls.ContainsKey(pollId))
            {
                polls[pollId] = polls[pollId] + " " + update;
            }
            else
            {
                polls.Add(pollId, update);
            }

            return GetPollResult(pollId);
        }

        [HttpGet("byKeyWords")]
        public List<Solution> GetByKeyWord(string keyWords)
        {
            var foundSolutions = new Dictionary<Solution, int>();
            var sortedSolutionMatches = new List<Solution>();

            if (keyWords == null) return sortedSolutionMatches;
            keyWords = keyWords.ToLower();

            char[] splitters = new char[] { ';' };
            var keys = keyWords.Split(splitters);

            foreach (var keyword in keys)
            {
                if (keyword == string.Empty) continue;
                foreach (var solution in supplier)
                {
                    foreach (var keyWordRaiting in solution.Keywords)
                    {
                        if ((keyWordRaiting[0] == keyword) || ((keyWordRaiting[0] + "s") == keyword))
                        {
                            int rating = int.Parse(keyWordRaiting[1]);
                            if (!foundSolutions.ContainsKey(solution)) foundSolutions[solution] = rating;
                            else foundSolutions[solution] = foundSolutions[solution] + rating;
                        }
                    }
                    
                }
            }
            
            var sortedSolutionCounts = new List<int>();
            foreach (var solution in foundSolutions.Keys)
            {
                int index = sortedSolutionMatches.Count;
                for (int i = 0; i < sortedSolutionMatches.Count; i++)
                {
                    if (foundSolutions[solution] > sortedSolutionCounts[i])
                    {
                        index = i;
                        break;
                    }
                }
                sortedSolutionMatches.Insert(index, solution);
                sortedSolutionCounts.Insert(index, foundSolutions[solution]);
            }
            return sortedSolutionMatches;
        }

        [HttpGet("keyWordsFromFreeText")]
        public List<KeywordMatch> GetKeyWordFromFreeText(string freeText)
        {
            System.Diagnostics.Debug.WriteLine(freeText);
            char[] splitters = new char[] { ' ', ',', '.' };

            var sortedKeywordMatches = new List<Models.KeywordMatch>();
            var foundKeywords = new Dictionary<string, int>();

            if (freeText == null) return sortedKeywordMatches;
            freeText = freeText.ToLower();

            var words = freeText.Split(splitters);

            foreach (var word in words)
            {
                System.Diagnostics.Debug.WriteLine($"checking {word}");
                if (word == string.Empty) continue;
                string description;
                if (keywords.TryGetValue(word, out description))
                {
                    if (!foundKeywords.ContainsKey(word)) foundKeywords[word] = 1;
                    else foundKeywords[word] = foundKeywords[word] + 1;
                    System.Diagnostics.Debug.WriteLine($"{word} found ({foundKeywords[word]})");
                }
                else if (word.ElementAt(word.Length - 1) == 's')
                {
                    string singular = word.Substring(0, word.Length - 1);
                    if (keywords.TryGetValue(singular, out description))
                    {
                        if (!foundKeywords.ContainsKey(singular)) foundKeywords[singular] = 1;
                        else foundKeywords[singular] = foundKeywords[singular] + 1;
                        System.Diagnostics.Debug.WriteLine($"{singular} found ({foundKeywords[singular]})");
                    }
                }
            }

            foreach (var keyword in foundKeywords.Keys)
            {
                var match = new Models.KeywordMatch() { Keyword = keyword, Count = foundKeywords[keyword], Description = keywords[keyword] };
                var index = GetInsertIndex(match, sortedKeywordMatches);
                sortedKeywordMatches.Insert(index, match);
            }

            return sortedKeywordMatches;
        }

        [HttpPut("putProvider")]
        public void putSolutionProvider(string name, string url, string address, string imageUrl, string keyWords, bool isTool)
        {
            char[] splitters = new char[] { ';' };
            var splitted = keyWords.Split(splitters);
            List<List<string>> ratedKeyWords = new List<List<string>>();
            for (int i = 0; i < splitted.Length - 1; i+=2)
            {
                var ratedKeyword = new List<string>();
                ratedKeyword.Add(splitted[i]);
                ratedKeyword.Add(splitted[i + 1]);
                ratedKeyWords.Add(ratedKeyword);
            }
            Solution s = new Solution() { Name = name, Url = url, Address = address, ImageUrl = imageUrl, Keywords = ratedKeyWords, IsTool = isTool, Rating = 3};
            supplier.Add(s);
        }
    }
}
