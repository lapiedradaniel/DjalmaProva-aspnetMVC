using DjalmaProva.Data;
using DjalmaProva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DjalmaProva.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly BancoContext _context;

        public ProdutosController(BancoContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var applicationDbContext = _context.Produtos.Include(c => c.Vendedor);
            return View(applicationDbContext.ToList());
        }
        public IActionResult Criar()
        {
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("ProdutoId,ProdutoDescricao,ProdutoNome,ProdutoPreco,QtdeEmEstoque,MarcadoProduto,VendedorId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", produto.VendedorId);
            return View(produto);
        }



        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", produto.VendedorId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("ProdutoId,ProdutoDescricao,ProdutoNome,ProdutoPreco,QtdeEmEstoque,MarcadoProduto,VendedorId")] Produto produto)
        {

            if (ModelState.IsValid)
            {


                _context.Update(produto);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "VendedorId", "VendedorId", produto.VendedorId);
            return View(produto);



        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Produto produtos = ListarPorId(id);
            return View(produtos);
        }

        public Produto ListarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
        }

        public IActionResult Apagar(int id)
        {
            Apagarr(id);

            return RedirectToAction("Index");
        }

        public bool Apagarr(int id)
        {
            Produto contatoDB = ListarPorId(id);
            _context.Produtos.Remove(contatoDB);
            _context.SaveChanges();
            return true;

        }
    }
}
