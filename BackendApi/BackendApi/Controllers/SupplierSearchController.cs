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

        private int GetInsertIndex(Models.KeywordMatch match, List<Models.KeywordMatch> sortedMatches)
        {
            for (int i = 0; i < sortedMatches.Count; i++)
            {
                if (match.Count > sortedMatches[i].Count) return i;
            }
            return sortedMatches.Count;
        }

        [HttpGet("byKeyWord")]
        public List<Solution> GetByKeyWord(string[] keyWords)
        {
            var foundSolutions = new Dictionary<Solution, int>();
            foreach (var keyword in keyWords)
            {
                foreach (var solution in supplier)
                {
                    if (solution.Keywords.Contains(keyword))
                    {
                        if (!foundSolutions.ContainsKey(solution)) foundSolutions[solution] = 1;
                        else foundSolutions[solution] = foundSolutions[solution] + 1;
                    }
                }
            }
            var sortedSolutionMatches = new List<Solution>();
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

        [HttpGet("keyWordFromFreeText")]
        public List<KeywordMatch> GetKeyWordFromFreeText(string freeText)
        {
            char[] splitters = new char[] { ' ', ',', '.' };

            var sortedKeywordMatches = new List<Models.KeywordMatch>();
            var foundKeywords = new Dictionary<string, int>();

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
