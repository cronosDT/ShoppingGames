using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingGames.Data;
using ShoppingGames.Data.Entities;

namespace ShoppingGames.Controllers
{
    public class CategoriesController: Controller  
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.categories.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            { 
                NotFound();
            }

            var category = await _context.categories
                .FirstOrDefaultAsync(category => category.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category )
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una categoria con el mismo nombre");
                    }
                    else 
                    { 
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message)
;                }
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var category = await _context.categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(String.Empty, "Ya existe una categoria con el mismo nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }

            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var vategory = await _context.categories
                .FirstOrDefaultAsync(category => category.Id == id);
            if (vategory == null)
            {
                return NotFound();
            }

            return View(vategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.categories.FindAsync(id);
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
