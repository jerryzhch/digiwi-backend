using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi
{
    public class KeywordExtractor
    {
        public Dictionary<string, string> Keywords { get; set; } = new Dictionary<string, string>();
        private char[] splitters = new char[] { ' ', ',', '.' };


        public void LoadExamples()
        {
            //Bexio
            Keywords.Add("accounting", "Tools to improve any financial task.");
            Keywords.Add("trustee", "A person to administer your/customer property.");
            Keywords.Add("customer", "Tools to help you manage your customers.");
            Keywords.Add("order", "Tools to help you manage your orders.");

            //Slack
            Keywords.Add("communication", "Tools to imrove internal communication.");
            Keywords.Add("teamwork", "Tools to improve collaboration of employees.");

            //ClickTime
            Keywords.Add("time", "Tools to record working hours and task scheduling.");
            Keywords.Add("organisation", "Tools to help with organisation and time management.");

            //HighRadius
            Keywords.Add("billing", "Tools that manage invoices and exhortations.");
            Keywords.Add("invoice", "Tools that manage invoices and exhortations.");
            Keywords.Add("exhortation", "Tools that manage invoices and exhortations.");

            //Parallel
            Keywords.Add("logistics", "Tools to help manage your stock.");
            Keywords.Add("stock", "Tools to help manage your stock.");
            Keywords.Add("supply", "Tools to help you manage you supply chains.");

            //Soxess
            Keywords.Add("database", "Partners to build custom database solutions.");

            //WebSamurai
            Keywords.Add("website", "Tools and partners to build websites and improve web presence.");
            Keywords.Add("marketing", "Tools and partners to help you with web presence and marketing");

            //Misc
            Keywords.Add("planning", "Try enter LOGISTICS if you are looking to organize your stock or TIME if you are looking to improve organisation");
        }

        public Dictionary<string, int> GetKeywords(string text)
        {
            var keywords = new Dictionary<string, int>();

            var words = text.Split(splitters);

            foreach (var word in words)
            {
                string description;
                if (Keywords.TryGetValue(word, out description))
                {
                    if (!keywords.ContainsKey(word)) keywords[word] = 1;
                    else keywords[word] = keywords[word] + 1;
                }
            }

            return keywords;
        }
    }
}
