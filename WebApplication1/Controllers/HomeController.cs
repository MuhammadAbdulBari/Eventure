using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly regDbContext context;

        public HomeController(regDbContext context)
        {
            this.context = context;
        }
        //Frontend 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();
        }

       

        public IActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserRegister(UserReg obj)
        {
            context.UserRegs.Add(obj);
            context.SaveChanges();
            return View();
        }


        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(UserReg obj)
        {

            var data = context.UserRegs.Where(x => x.Email == obj.Email && x.Password == obj.Password).FirstOrDefault();
            if (data != null)
            {
                HttpContext.Session.SetString("session", data.Name);
                return RedirectToAction("afterlogin");
            }


            return View("Index");
        }


        public IActionResult afterlogin()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }

            return RedirectToAction("Stories");
        }

        public IActionResult UserLogout(UserReg reg)
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                HttpContext.Session.Remove("session");
                return RedirectToAction("UserRegister");
            }
            return RedirectToAction("afterlogin");
        }
        public IActionResult Contact()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Contact(UserContact obj)
        {

            context.UserContacts.Add(obj);
            context.SaveChanges();
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();
        }
        public IActionResult Gallery()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Gallery(Review obj)
        {
            context.Reviews.Add(obj);
            context.SaveChanges();
            return RedirectToAction("Thanks");
        }


        public IActionResult About()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();
        }

        public IActionResult Stories()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();
        }

      

        public IActionResult Services()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();

        }

        public IActionResult CreateEvent()
        {
            if (HttpContext.Session.GetString("session") != null)
            {
                ViewData["sessionname"] = HttpContext.Session.GetString("session");
                return View();
            }
            return View();

        }


        //Backend


        public IActionResult UserView(int id)
        {
            var data = context.UserContacts.ToList();
            return View(data);
        }


        public IActionResult UserDetails(int id)
        {
            var data = context.UserContacts.Find(id);
            return View(data);
        }



        public IActionResult UserDelete(int id)
        {
            var data = context.UserContacts.Find(id);
            context.UserContacts.Remove(data);
            context.SaveChanges();
            return RedirectToAction("UserView");
        }

        public IActionResult UserEdit(int id)
        {
            var data = context.UserContacts.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UserEdit(UserContact c, int id)
        {
            var data = context.UserContacts.Find(id);
            data.Name = c.Name;
            data.Email = c.Email;
            data.Address = c.Address;
            data.Number = c.Number;
            data.Budget = c.Budget;
            data.Message = c.Message;
            context.SaveChanges();
            return RedirectToAction("UserView");
        }


        public IActionResult ReviewView(int id)
        {
            var data = context.Reviews.ToList();
            return View(data);
        }


        public IActionResult ReviewDelete(int id)
        {
            var data = context.Reviews.Find(id);
            context.Reviews.Remove(data);
            context.SaveChanges();
            return RedirectToAction("ReviewView");
        }

        public IActionResult AdminSignup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminSignup(register obj)
        {
            context.registers.Add(obj);
            context.SaveChanges();
            return RedirectToAction("AdminLogin");
        }


        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(register obj)
        {
            var data = context.registers.Where(x => x.Email == obj.Email && x.Password == obj.Password).FirstOrDefault();
            if (data != null)
            {
                HttpContext.Session.SetString("mysession", data.Email);
                return RedirectToAction("Dashboard");
            }

            return View();
        }

        public IActionResult AdminLogout(register reg)
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                HttpContext.Session.Remove("mysession");
                return RedirectToAction("AdminLogin");
            }
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("mysession") != null)
            {
                ViewData["session"] = HttpContext.Session.GetString("mysession");
                return View();
            }

            return RedirectToAction("AdminLogin");
        }



        public IActionResult CreateEventForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEventForm(CreateEvent e)
        {
            context.CreateEvents.Add(e);
            context.SaveChanges();
            return RedirectToAction("EventView");
        }

        public IActionResult EventView()
        {
            var data = context.CreateEvents.ToList();
            return View(data);
        }

        public IActionResult EventDetails(int id)
        {
            var data = context.CreateEvents.Find(id);
            return View(data);
        }

        public IActionResult Eventdelete(int id)
        {
            var data=context.CreateEvents.Find(id);
            return View(data);
        }

        public IActionResult EDelete(CreateEvent e, int id)
        {

            context.CreateEvents.Remove(e);
            context.SaveChanges();
            return RedirectToAction("EventView");
        }

        public IActionResult EventEdit(int id)
        {
            var data=context.CreateEvents.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EventEdit(CreateEvent c,int id)
        {
            var data = context.CreateEvents.Find(id);
            data.EventName = c.EventName;
            data.EventType = c.EventType;
            data.EventDateTime = c.EventDateTime;
            data.Venue = c.Venue;
            data.ClientId = c.ClientId;
            data.ClientName = c.ClientName;
            data.ClientContact = c.ClientContact;
            data.Budget = c.Budget;
            data.PaymentMethod = c.PaymentMethod;
            data.VendorId = c.VendorId;
            data.Status = c.Status;
            data.PaymentStatus = c.PaymentStatus;
            context.SaveChanges();

            return RedirectToAction("EventView");
        }


        public IActionResult UpdateStatus()
        {
        
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStatus(CreateEvent ustatus,int id)
        {
            var data=context.CreateEvents.Find(id);
            if(data !=  null)
            {
                data.Status = ustatus.Status;
                context.SaveChanges();

                return RedirectToAction("EventView");
            }
            return RedirectToAction("Dashboard");
            
        }

        public IActionResult vendor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult vendor(vendor obj)
        {
            context.vendors.Add(obj);
            context.SaveChanges();
            return RedirectToAction("VendorView");
        }

        public IActionResult VendorView()
        {
            var data=context.vendors.ToList();
            return View(data); 
        }

        public IActionResult VendorDetails(int id)
        {
            var data = context.vendors.Find(id);
            return View(data);
        }

        public IActionResult  VendorDelete(int id)
        {
            var data = context.vendors.Find(id);
            return View(data);
        }
        public IActionResult VDelete(vendor v,int id)
        {
            
            context.vendors.Remove(v);
            context.SaveChanges();
            return RedirectToAction("VendorView");
        }

        public IActionResult VendorEdit(int id)
        {
            var data = context.vendors.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult VendorEdit(int id,vendor v)
        {
            var data = context.vendors.Find(id);
            data.Contact_Person = v.Contact_Person;
            data.Number = v.Number;
            data.Email = v.Email;
            data.Service_Type = v.Service_Type;
            data.Company_Name = v.Company_Name;
            data.Address = v.Address;
            data.City = v.City;
            context.SaveChanges();
         
            return RedirectToAction("VendorView");
        }

      


        //public IActionResult Event()
        //{
        //    return View();
        //}


        //public IActionResult Participant()
        //{
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
