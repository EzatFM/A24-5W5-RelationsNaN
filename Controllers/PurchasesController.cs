﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelationsNaN.Data;
using RelationsNaN.Models;

namespace RelationsNaN.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly RelationsNaNContext _context;

        public PurchasesController(RelationsNaNContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var relationsNaNContext = _context.Purchase.Include(p => p.GamePurchases).ThenInclude(gp => gp.Game);
            return View(await relationsNaNContext.ToListAsync());
        }
    }
}
