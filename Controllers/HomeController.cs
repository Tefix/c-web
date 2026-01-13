using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;
using WebApplication2.Data;   
namespace WebApplication2.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
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

    public ActionResult Ankeet()
    {
        var pyhad = _context.Pyha?.ToList() ?? new List<Pyha>();
        ViewBag.Pyhad = new SelectList(pyhad, "Id", "Nimetus");
        return View();
    }

    [HttpPost]
    public ActionResult Ankeet(Kylaline kylaline)
    {
        if (ModelState.IsValid)
        {
            _context.Kylalained.Add(kylaline);
            _context.SaveChanges();
            SendEmail(kylaline);
            return RedirectToAction("Tanav", new { id = kylaline.Id });
        }
        var pyhad = _context.Pyha?.ToList() ?? new List<Pyha>();
        ViewBag.Pyhad = new SelectList(pyhad, "Id", "Nimetus");
        return View(kylaline);
    }

    private void SendEmail(Kylaline kylaline)
    {
        var pyha = _context.Pyha?.FirstOrDefault(p => p.Id == kylaline.PyhaId)?.Nimetus;
        var mail = new System.Net.Mail.MailMessage("ihavearm0@gmail.com", kylaline.Email, "Kutse: " + pyha, $"Tere, {kylaline.Nimi}!\n\nSinu vastus on registreeritud.\nÜritus: {pyha}\nOsalemine: {(kylaline.OnKutse ? "Jah" : "Ei")}");
        mail.Attachments.Add(new System.Net.Mail.Attachment("images/Funnypic.png"));
        System.Net.Mail.SmtpClient smtp = new("smtp.gmail.com", 587) { Credentials = new System.Net.NetworkCredential("ihavearm0@gmail.com", "pohb txpq djxx ovjk"), EnableSsl = true };
        smtp.Send(mail);
    }

    public ActionResult Tanav(int id)
    {
        var kylaline = _context.Kylalained.FirstOrDefault(k => k.Id == id);
        if (kylaline == null)
        {
            return NotFound();
        }

        ViewBag.pyhanimetus = _context.Pyha?.FirstOrDefault(p => p.Id == kylaline.PyhaId)?.Nimetus;
        ViewBag.Pilt = "pilt.png";
        return View("Tanav", kylaline);
    }
}