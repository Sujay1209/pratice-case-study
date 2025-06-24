using Microsoft.AspNetCore.Mvc;
using ClientManagementApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientManagementApp.Controllers
{
    [Route("Client")]
    public class ClientController : Controller
    {
        private static List<ClientInfo> clients = new List<ClientInfo>
    {
        new ClientInfo
        {
            ClientId = 1,
            CompanyName = "hexaware",
            WebUrl = "www.hexaware.com",
            Email = "contact@gmail.com",
            Category = "Software Services",
            Standard = "CMMI5"
        },
        new ClientInfo
        {
            ClientId = 2,
            CompanyName = "hexa123",
            WebUrl = "www.hexaware123.com",
            Email = "contact@gmail.com",
            Category = "Software Services",
            Standard = "CMMI6"
        }

    };
        [Route("All")]
        [Route("/",Name = "ShowAllClientDetails")]
        public IActionResult ShowAllClientDetails()
        {
            return View("ShowAllClientDetails",clients);
        }
        [Route("GetById/{id}",Name = "GetDetailsByClientId")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var client=clients.Where(c=>c.ClientId.Equals(id)).FirstOrDefault();
            return View("GetDetailsByClientId",client);
        }
        [Route("GetByName/{name}", Name = "GetDetailsByCompanyName")]
        public ActionResult GetDetailsByCompanyName(string name)
        {
            var client=clients.Where(c=>c.CompanyName.Equals(name)).FirstOrDefault();
            return View("GetDetailsByCompanyName",client);
        }
        [Route("GetByEmail/{email}", Name = "GetByEmail")]
        public IActionResult GetDetailsByEmail(string email)
        {
            var client=clients.Where(c=>c.Email.Equals(email)).FirstOrDefault();
            return View("GetDetailsByEmail",client);
        }
        [Route("GetDetailsByCategory/{category}", Name = "GetDetailsByCategory")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var client = clients.FirstOrDefault(c => c.Category == category);
            return View("GetDetailsByCategory", client);
        }

        [Route("GetDetailsByStandard/{standard}", Name = "GetDetailsByStandard")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var client = clients.FirstOrDefault(c => c.Standard == standard);
            return View("GetDetailsByStandard", client);
        }
        [Route("AddClient", Name = "AddClient")]
        public IActionResult AddClient()
        {
            LoadCategories();
            LoadStandards();
            return View("AddClient");
        }
        
        [HttpPost]
        [Route("SaveClient",Name ="SaveClient")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToRoute("ShowAllClientDetails");
        }
        public void LoadCategories()
        {
            var categories = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low_Level_Managed_IT_Services", Value = "Low_Level_Managed_IT_Services" },
                new SelectListItem { Text = "Mid_Level_Managed_IT_Services", Value = "Mid_Level_Managed_IT_Services" },
                new SelectListItem { Text = "High_Level_Managed_IT_Services", Value = "High_Level_Managed_IT_Services" },
                new SelectListItem { Text = "On-Demand_IT_Services", Value = "On-Demand_IT_Services" },
                new SelectListItem { Text = "Hardware_Support", Value = "Hardware_Support" },
                new SelectListItem { Text = "Software Services", Value = "Software Services"},
                new SelectListItem { Text = "Network_Management ", Value = "Network_Management"}
            };

            ViewBag.Categories = categories;
        }
        public void LoadStandards()
        {
            var standards = new List<SelectListItem>
            {
                new SelectListItem { Text = "CMMI1", Value = "CMMI1" },
                new SelectListItem { Text = "CMMI2", Value = "CMMI2" },
                new SelectListItem { Text = "CMMI3", Value = "CMMI3" },
                new SelectListItem { Text = "CMMI4", Value = "CMMI4" },
                new SelectListItem { Text = "CMMI5", Value = "CMMI5" },
                new SelectListItem { Text = "ISO", Value = "ISO" },
                new SelectListItem { Text = "None", Value = "None" }
            };

            ViewBag.Standards = standards;
        }
    }

}

