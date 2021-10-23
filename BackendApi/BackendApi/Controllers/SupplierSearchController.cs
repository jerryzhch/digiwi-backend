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
        public List<Solution> GetByKeyWord([FromBody] string[] keyWords)
        {
            return supplier;
        }

        [HttpGet("keyWordFromFreeText")]
        public List<KeywordMatch> GetKeyWordFromFreeText([FromBody] string freeText)
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
