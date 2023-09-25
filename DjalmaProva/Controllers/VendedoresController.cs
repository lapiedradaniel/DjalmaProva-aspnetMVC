using DjalmaProva.Data;
using DjalmaProva.Models;
using Microsoft.AspNetCore.Mvc;

namespace DjalmaProva.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly BancoContext _context;

        public VendedoresController(BancoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            return View(_context.Vendedores.ToList());
        }

        public IActionResult Criar()
        {
            
            return View();
        }

        public IActionResult Editar(int id)
        {
           Vendedor vendedor = ListarPorId(id);
           

            return View(vendedor);
        }

        public IActionResult Apagarconfirmacao(int id)
        {
            Vendedor vendedor = ListarPorId(id);
            return View(vendedor);
        }

        [HttpPost]
        public IActionResult Criar([Bind("VendedorId,NomeCompleto,Telefone,Email")] Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public Vendedor ListarPorId(int id)
        {
              return _context.Vendedores.FirstOrDefault(x => x.VendedorId== id);
        }
        [HttpPost]
        public IActionResult Alterar( Vendedor vendedor)
        {
            Atualizar(vendedor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public Vendedor Atualizar(Vendedor vendedor)
        {
            Vendedor contatoDB = ListarPorId(vendedor.VendedorId);  

            contatoDB.NomeCompleto = vendedor.NomeCompleto; 
            contatoDB.Telefone= vendedor.Telefone;
            contatoDB.Email = vendedor.Email;   

            _context.Vendedores.Update(contatoDB);
            _context.SaveChanges();
            return contatoDB;
        }
        public IActionResult Apagar(int id)
        {
            Apagarr(id);
            
            return RedirectToAction("Index");
        }

        public bool Apagarr(int id)
        {
            Vendedor contatoDB = ListarPorId(id);   
            _context.Vendedores.Remove(contatoDB);
            _context.SaveChanges();
            return true;

        }

    }
}
