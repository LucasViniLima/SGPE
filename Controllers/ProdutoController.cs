using Microsoft.AspNetCore.Mvc;
using SGPE.Context;
using SGPE.Models;

namespace SGPE.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo, Descricao")] Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
    }
}
