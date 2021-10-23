using BackendApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi
{
    public static class MockData
    {
        public static List<Solution> GetSuppliers()
        {
            List<Solution> suppliers = new List<Solution>();
            suppliers.AddRange(new List<Solution> {
                new Solution
            {
                Name = "Bexio",
                Address = "Alte Jonastrasse 24, 8640 Rapperswil-Jona",
                Rating = 4,
                Url = "https://www.bexio.com",
                Keywords = new List<List<string>> { new List<string> { "accounting", "5" },
                    new List<string>{"trustee", "4" }, new List<string>{"customer", "2" }, new List<string>{"order", "2" }},
                ImageUrl = "https://media-exp1.licdn.com/dms/image/C4D0BAQEEDvFk6_Ojrg/company-logo_200_200/0/1519904414454?e=1643241600&v=beta&t=SHERxu3cFzGTIfNbofkwXIUkLzSekd6tdEZ6Ly5sfps",
                IsTool = false

            }, new Solution
            {
                Name = "Slack",
                Rating = 4,
                Url = "https://slack.com",
                Keywords = new List<List<string>> { new List<string> { "communication", "4" }, new List<string> { "teamwork", "4" }},
                ImageUrl = "https://upload.wikimedia.org/wikipedia/fr/thumb/7/7e/Slack_logo.svg/langfr-1024px-Slack_logo.svg.png",
                IsTool = true
            },new Solution
            {
                Name = "ClickTime",
                Rating = 3,
                Url = "https://www.clicktime.com/",
                Keywords = new List<List<string>> { new List<string> { "time", "4" }, new List<string> { "organisation", "4" },
                    new List<string>{ "control", "3" } },
                ImageUrl = "https://marketplace.bamboohr.com/wp-content/uploads/2020/08/clicktime-logo-vertical-500px.png",
                IsTool = true
            },new Solution
            {
                Name = "HighRadius",
                Rating = 4,
                Url = "https://www.highradius.com/",
                Keywords = new List<List<string>> { new List<string> { "billing", "4" }, new List<string> { "exhortation", "4" },
                    new List<string>{"invoice", "3"} },
                ImageUrl = "https://mms.businesswire.com/media/20210503005090/en/875206/23/Highradius-logo_1_%282%29.jpg",
                IsTool = true
            },new Solution
            {
                Name = "Parallel",
                Address = "Inseliquai 8, 6005 Luzern",
                Rating = 4,
                Url = "https://www.parallel.ch/",
                Keywords = new List<List<string>> { new List<string> { "logistics", "5" }, new List<string> { "planning", "4" },
                    new List<string>{"stock", "4" }},
                ImageUrl = "https://www.parallel.ch/_local/images/logo.png",
                IsTool = false

            },new Solution
            {
                Name = "Soxes",
                Address = "Sennweidstrasse 1b, 8608 Bubikon",
                Rating = 5,
                Url = "https://soxes.ch/",
                Keywords = new List<List<string>> {new List<string> { "database", "5"} },
                ImageUrl = "https://soxes.ch/wp-content/uploads/2021/08/soxes_dunkelgrau_190px_rgb.svg",
                IsTool = false

            },new Solution
            {
                Name = "WebSamurai",
                Address = "Binzstrasse 9, 8045 Zürich",
                Rating = 5,
                Url = "https://www.websamurai.ch",
                Keywords = new List<List<string>> { new List<string> { "website", "5"}, new List<string>{"marketing", "4" } },
                ImageUrl = "https://www.websamurai.ch/wp-content/uploads/2018/10/WEBSAMURAI-mit-Claim-neg-500x134.png",
                IsTool = false

            }

            });
            return suppliers;
        }

        public static Dictionary<string, string> GetKeywords()
        {
            Dictionary<string, string> Keywords = new Dictionary<string, string>();

            //Bexio
            Keywords.Add("accounting", "I can help you with financial tasks.");
            Keywords.Add("trustee", "Let me connect you with someone to administer your or your customers property.");
            Keywords.Add("customer", "I can find tools to improve you customer interaction and management");
            Keywords.Add("order", "If you want help with orders and accounting I can find just the right fit for you.");

            //Slack
            Keywords.Add("communication", "I can suggest a tool to improve internal and external communication.");
            Keywords.Add("teamwork", "There exist tools thet can help your team to collaborate better and be more productive.");

            //ClickTime
            Keywords.Add("time", "Time tracking can be autmated, making it less of a hassle for your emploees.");
            Keywords.Add("organisation", "Organisation is alsways difficult but there exist tools that can help you with that.");

            //HighRadius
            Keywords.Add("billing", "Billing is a must and with the right tool it is also very easy.");
            Keywords.Add("invoice", "I can help you with your invoces.");
            Keywords.Add("exhortation", "Exhortations are a hassle for all parties, but with the right tool you can save a lot of money.");

            //Parallel
            Keywords.Add("logistics", "Need help with your stock and logistics? I might know just the right partner.");
            Keywords.Add("stock", "Never run out of stuck with the right tools and partners.");
            Keywords.Add("supply", "There are tools that make supplychain management a breeze.");

            //Soxess
            Keywords.Add("database", "You need a databas? Let me help you with that.");

            //WebSamurai
            Keywords.Add("website", "Need a partner to improve your appearance in the world wide web?");
            Keywords.Add("marketing", "I can find a partner for your marketing needs.");

            //Misc
            //Keywords.Add("planning", "Try enter LOGISTICS if you are looking to organize your stock or TIME if you are looking to improve organisation");

            return Keywords;
        }
    }
}
