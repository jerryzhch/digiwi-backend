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
                int count = rnd.Next(500) + 10;
                while (keywordList.Count > 0)
                {
                    int index = rnd.Next(keywordList.Count);
                    int score = rnd.Next(count);
                    count = (count - score) / 2;
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
                foreach (var solution in supplier)
                {
                    foreach (var keyWordRaiting in solution.Keywords)
                    {
                        if (keyWordRaiting.Contains(keyword))
                        {
                            if (!foundSolutions.ContainsKey(solution)) foundSolutions[solution] = 1;
                            else foundSolutions[solution] = foundSolutions[solution] + 1;
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
            char[] splitters = new char[] { ' ', ',', '.' };

            var sortedKeywordMatches = new List<Models.KeywordMatch>();
            var foundKeywords = new Dictionary<string, int>();

            if (freeText == null) return sortedKeywordMatches;
            freeText = freeText.ToLower();

            var words = freeText.Split(splitters);

            foreach (var word in words)
            {
                string description;
                if (keywords.TryGetValue(word, out description))
                {
                    if (!foundKeywords.ContainsKey(word)) foundKeywords[word] = 1;
                    else foundKeywords[word] = foundKeywords[word] + 1;
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


    }
}
