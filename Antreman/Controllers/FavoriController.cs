using Antreman.Data;
using Antreman.Models;
using Microsoft.AspNetCore.Mvc;

namespace Antreman.Controllers
{
    public class FavoriController : Controller
    {
        private readonly antremanDBContext _context;

        public FavoriController(antremanDBContext context)
        {
            _context = context;
        }


    }
}
