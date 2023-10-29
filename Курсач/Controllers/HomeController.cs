using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Курсач.Models;

namespace Курсач.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbCon _context;


        public HomeController(ILogger<HomeController> logger, DbCon context )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new IndexModel { telefons = _context.Telefons.ToList() };
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Telefon telefon)
        {
            if (string.IsNullOrEmpty(telefon.PhoneNumb))
            {
                ModelState.AddModelError(nameof(telefon.PhoneNumb), "Введите номер телефона");
            }
            if (!string.IsNullOrEmpty(telefon.PhoneNumb) && Regex.IsMatch(telefon.PhoneNumb, @"^[0-9]+$"))
            {
                double x = Convert.ToDouble(telefon.PhoneNumb);
                if (x < 89000000000 || x > 89999999999)
                {
                    ModelState.AddModelError(nameof(telefon.PhoneNumb), "Формат номера должен быть 8(9__)-___-__-__");
                }
            }
            if (!string.IsNullOrEmpty(telefon.PhoneNumb) && !Regex.IsMatch(telefon.PhoneNumb, @"^[0-9]+$"))
            {
                ModelState.AddModelError(nameof(telefon.PhoneNumb), "Номер телефона должен содержать только цифры");
            }
            if (string.IsNullOrEmpty(telefon.s_Name))
            {
                ModelState.AddModelError(nameof(telefon.s_Name), "Введите фамилию");
            }
            if (!string.IsNullOrEmpty(telefon.s_Name) && !Regex.IsMatch(telefon.s_Name, @"^[a-zA-ZА-Яа-я]+$"))
            {
                ModelState.AddModelError(nameof(telefon.s_Name), "Фамилия должна содержать только буквы");
            }
            if (!string.IsNullOrEmpty(telefon.s_Name) && telefon.s_Name.Length > 30)
            {
                ModelState.AddModelError(nameof(telefon.s_Name), "Значение фамилии не может превышать 30 символов");
            }
            if (string.IsNullOrEmpty(telefon.f_Name))
            {
                ModelState.AddModelError(nameof(telefon.f_Name), "Введите имя");
            }
            if (!string.IsNullOrEmpty(telefon.f_Name) && !Regex.IsMatch(telefon.f_Name, @"^[a-zA-ZА-Яа-я]+$"))
            {
                ModelState.AddModelError(nameof(telefon.f_Name), "Имя должно содержать только буквы");
            }
            if (!string.IsNullOrEmpty(telefon.f_Name) && telefon.f_Name.Length > 30)
            {
                ModelState.AddModelError(nameof(telefon.f_Name), "Значение имени не может превышать 30 символов");
            }
            if (string.IsNullOrEmpty(telefon.t_Name))
            {
                ModelState.AddModelError(nameof(telefon.t_Name), "Введите отчество");
            }
            if (!string.IsNullOrEmpty(telefon.t_Name) && !Regex.IsMatch(telefon.t_Name, @"^[a-zA-ZА-Яа-я]+$"))
            {
                ModelState.AddModelError(nameof(telefon.t_Name), "Отчество должно содержать только буквы");
            }
            if (!string.IsNullOrEmpty(telefon.t_Name) && telefon.t_Name.Length > 30)
            {
                ModelState.AddModelError(nameof(telefon.t_Name), "Значение отчества не может превышать 30 символов");
            }
            if (ModelState.IsValid)
            {
                _context.Telefons.Add(telefon);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefon);
        }
        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _context.Telefons.Remove(new Telefon { Id = id });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Telefon model = _context.Telefons.SingleOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Telefon a) 
        {
            if (string.IsNullOrEmpty(a.PhoneNumb))
            {
                ModelState.AddModelError(nameof(a.PhoneNumb), "Введите номер телефона");
            }
            if (!string.IsNullOrEmpty(a.PhoneNumb) && Regex.IsMatch(a.PhoneNumb, @"^[0-9]+$"))
            {
                double x = Convert.ToDouble(a.PhoneNumb);
                if (x < 89000000000 || x > 89999999999)
                {
                    ModelState.AddModelError(nameof(a.PhoneNumb), "Формат номера должен быть 8(9__)-___-__-__");
                }
            }
            if (!string.IsNullOrEmpty(a.PhoneNumb) && !Regex.IsMatch(a.PhoneNumb, @"^[0-9]+$"))
            {
                ModelState.AddModelError(nameof(a.PhoneNumb), "Номер телефона должен содержать только цифры");
            }
            if (string.IsNullOrEmpty(a.s_Name))
            {
                ModelState.AddModelError(nameof(a.s_Name), "Введите фамилию");
            }
            if (!string.IsNullOrEmpty(a.s_Name) && !Regex.IsMatch(a.s_Name, @"^[a-zA-ZА-Яа-я]+$"))
            {
                ModelState.AddModelError(nameof(a.s_Name), "Фамилия должна содержать только буквы");
            }
            if (!string.IsNullOrEmpty(a.s_Name) && a.s_Name.Length > 30)
            {
                ModelState.AddModelError(nameof(a.s_Name), "Значение фамилии не может превышать 30 символов");
            }
            if (string.IsNullOrEmpty(a.f_Name))
            {
                ModelState.AddModelError(nameof(a.f_Name), "Введите имя");
            }
            if (!string.IsNullOrEmpty(a.f_Name) && !Regex.IsMatch(a.f_Name, @"^[a-zA-ZА-Яа-я]+$"))
            {
                ModelState.AddModelError(nameof(a.f_Name), "Имя должно содержать только буквы");
            }
            if (!string.IsNullOrEmpty(a.f_Name) && a.f_Name.Length > 30)
            {
                ModelState.AddModelError(nameof(a.f_Name), "Значение имени не может превышать 30 символов");
            }
            if (string.IsNullOrEmpty(a.t_Name))
            {
                ModelState.AddModelError(nameof(a.t_Name), "Введите отчество");
            }
            if (!string.IsNullOrEmpty(a.t_Name) && !Regex.IsMatch(a.t_Name, @"^[a-zA-ZА-Яа-я]+$"))
            {
                ModelState.AddModelError(nameof(a.t_Name), "Отчество должно содержать только буквы");
            }
            if (!string.IsNullOrEmpty(a.t_Name) && a.t_Name.Length > 30)
            {
                ModelState.AddModelError(nameof(a.t_Name), "Значение отчества не может превышать 30 символов");
            }
            if (ModelState.IsValid)
            {
                if (a.Id == default)
                    _context.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                else
                {
                    _context.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");   
                }
            }
            return View(a);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}