using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneStopBuy.Data;
using OneStopBuy.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using OneStopBuy.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;
using System.Data;
using ClosedXML.Excel;

namespace OneStopBuy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: product

        [AllowAnonymous]
        public async Task<IActionResult> Index(string autoName, string? sortByPrice)
        {
            var allAutos = await _context.Products.ToListAsync();
            var autos = new List<Product>();
            if (!String.IsNullOrEmpty(sortByPrice))
            {
                if (sortByPrice.Equals("lowest"))
                {
                    allAutos = allAutos.OrderBy(x => x.Price).ToList();

                }
                else if (sortByPrice.Equals("highest"))
                {
                    allAutos = allAutos.OrderByDescending(x => x.Price).ToList();
                }

            }
            if (autoName != null)
            {
                foreach (var a in allAutos)
                {
                    if (a.Brand.ToLower().Contains(autoName.ToLower()))
                    {
                        autos.Add(a);
                    }
                }
                return View(autos);

            }
            else
            {
                return View(allAutos);
            }


        }


        // GET: product/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Price"),
                                        new DataColumn("Brand"),
                                        new DataColumn("Auto_Production_Year"),
                                        new DataColumn("Engine") ,
                                        new DataColumn("Body_Type") ,
                                        new DataColumn("Start_Production") ,
                                        new DataColumn("End_Production") ,
                                        new DataColumn("Sets") ,
                                        new DataColumn("Doors") ,
                                        new DataColumn("Acceleration") });

            var customers = from customer in this._context.Products.Take(10)
                            select customer;

            foreach (var a in _context.Products)
            {
                dt.Rows.Add(a.Price, a.Brand, a.Auto_Production_Year, a.Engine, a.Body_Type, a.Start_Production,
                            a.End_Production, a.Sets, a.Doors, a.Acceleration);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Product autos = new Product
                {
                    Brand = model.Brand,
                    Engine = model.Engine,
                    EngineSize = model.EngineSize,
                    Auto_Production_Year = model.Auto_Production_Year,
                    Start_Production = model.Start_Production,
                    End_Production = model.End_Production,
                    Doors = model.Doors,
                    Fuel_Consumption = model.Fuel_Consumption,
                    Sets = model.Sets,
                    Photo = uniqueFileName,
                    Price = model.Price,
                    Fuel_Type = model.Fuel_Type,
                    Body_Type = model.Body_Type,
                    Acceleration = model.Acceleration,
                    Max_Speed = model.Max_Speed,
                    Power = model.Power,
                    Torque = model.Torque,
                    IsDogan = model.IsDogan


                };
                _context.Add(autos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        private string UploadedFile(CreateAutoViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }




        // GET: product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Engine,Body_Type,Start_Production,End_Production,Photo,Sets,Doors,Fuel_Consumption,Fuel_Type,Acceleration,Max_Speed,Power,Torque,Price,IsDogan")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
