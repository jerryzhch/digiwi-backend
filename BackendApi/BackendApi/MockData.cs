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
                Rating = 5,
                Url = "https://www.bexio.com",
                Keywords = new List<string> { "Accounting", "Trustee", "Customer", "Order" },
                ImageUrl = "https://media-exp1.licdn.com/dms/image/C4D0BAQEEDvFk6_Ojrg/company-logo_200_200/0/1519904414454?e=1643241600&v=beta&t=SHERxu3cFzGTIfNbofkwXIUkLzSekd6tdEZ6Ly5sfps",
                IsTool = false

            }, new Solution
            {
                Name = "Slack",
                Rating = 5,
                Url = "https://slack.com",
                Keywords = new List<string> { "Communication", "Teamwork"},
                ImageUrl = "https://upload.wikimedia.org/wikipedia/fr/thumb/7/7e/Slack_logo.svg/langfr-1024px-Slack_logo.svg.png",
                IsTool = true
            },new Solution
            {
                Name = "ClickTime",
                Rating = 5,
                Url = "https://www.clicktime.com/",
                Keywords = new List<string> { "Time", "Organisation", "Control"},
                ImageUrl = "https://marketplace.bamboohr.com/wp-content/uploads/2020/08/clicktime-logo-vertical-500px.png",
                IsTool = true
            },new Solution
            {
                Name = "HighRadius",
                Rating = 5,
                Url = "https://www.highradius.com/",
                Keywords = new List<string> { "Billing", "Exhortation", "Invoice"},
                ImageUrl = "https://mms.businesswire.com/media/20210503005090/en/875206/23/Highradius-logo_1_%282%29.jpg",
                IsTool = true
            },new Solution
            {
                Name = "Parallel",
                Address = "Inseliquai 8, 6005 Luzern",
                Rating = 5,
                Url = "https://www.parallel.ch/",
                Keywords = new List<string> { "Logistics", "Planning", "Stock" },
                ImageUrl = "https://www.parallel.ch/_local/images/logo.png",
                IsTool = false

            },new Solution
            {
                Name = "Parallel",
                Address = "Sennweidstrasse 1b, 8608 Bubikon",
                Rating = 5,
                Url = "https://soxes.ch/",
                Keywords = new List<string> { "Database"},
                ImageUrl = "https://soxes.ch/wp-content/uploads/2021/08/soxes_dunkelgrau_190px_rgb.svg",
                IsTool = false

            },new Solution
            {
                Name = "Parallel",
                Address = "Binzstrasse 9, 8045 Zürich",
                Rating = 5,
                Url = "https://www.websamurai.ch",
                Keywords = new List<string> { "Website", "Marketing"},
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

            return Keywords;
        }
    }
}
