using DjalmaProva.Data;
using DjalmaProva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DjalmaProva.Controllers
{
    public class ClientesController : Controller
    {
        private readonly BancoContext _context;

        public ClientesController(BancoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var applicationDbContext = _context.Clientes.Include(c => c.Vendedor);
            return View(applicationDbContext.ToList());
        }

       

        public IActionResult Editar(int id)
        {
            var cliente =  _context.Clientes.Find(id);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", cliente.VendedorId);
            return View(cliente);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("ClienteId,NomeCompleto,Telefone,Email,CPF,CNPJ,VendedorId")] Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                
                
                    _context.Update(cliente);
                     _context.SaveChanges();
                
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", cliente.VendedorId);
            return View(cliente);



        }
        public IActionResult ApagarConfirmacao(int id)
        {
            Cliente clientes = ListarPorId(id);
            return View(clientes);
        }

        public IActionResult Apagar(int id)
        {
            Apagarr(id);

            return RedirectToAction("Index");
        }

        public bool Apagarr(int id)
        {
            Cliente contatoDB = ListarPorId(id);
            _context.Clientes.Remove(contatoDB);
            _context.SaveChanges();
            return true;

        }

        public Cliente ListarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(x => x.ClienteId == id);
        }


        public IActionResult Criar()
        {
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("ClienteId,NomeCompleto,Telefone,Email,CPF,CNPJ,VendedorId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", cliente.VendedorId);
            return View(cliente);
        }

    }
}
