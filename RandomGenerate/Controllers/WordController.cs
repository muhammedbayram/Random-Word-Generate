using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandomGenerate.Models;

namespace RandomGenerate.Controllers
{
    public class WordController : Controller
    {
        private readonly WordDbContext _context;

        public WordController(WordDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Words.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVoc()
        {         
            if (ModelState.IsValid)
            {             
                var rnd = new Random();
                int vocNum = 1;

                for (int i = 0; i < 10; i++) 
                {
                    Word word = new Word();
                    string kelime = "";

                    for (int k = 0; k < 5; k++)
                    {
                        kelime += ((char)rnd.Next('A', 'Z')).ToString();
                        kelime += ((char)rnd.Next('a', 'z')).ToString();

                    }
                  
                    word.VocableIndex = vocNum;
                    vocNum++;

                    word.Vocable = kelime;

                    string test = kelime.ToUpper();
                    word.Counter = VocCounter(test);

                    _context.Add(word);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }



        //Letter calculation
        public string VocCounter(string test)
        {

            char[] letters = test.ToCharArray();

            byte[] counter = new byte[test.Length];

            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < test.Length; j++)
                {
                    if (letters[i] == test[j])
                    {
                        counter[i]++;
                    }
                }
            }

            string result ="";

            for (int i = 0; i < test.Length; i++)
            {
                if (!result.Contains(letters[i]))
                {
                    result += $"{counter[i]}{letters[i]} ";
                }
            }

            return result;
          
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {

            if (ModelState.IsValid)
            {
                foreach (var item in _context.Words)
                {
                    _context.Words.Remove(item);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Word/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Words == null)
            {
                return NotFound();
            }

            var word = await _context.Words
                .FirstOrDefaultAsync(m => m.VocableId == id);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // POST: Word/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Words == null)
            {
                return Problem("Entity set 'WordDbContext.Words'  is null.");
            }
            var word = await _context.Words.FindAsync(id);
            if (word != null)
            {
                _context.Words.Remove(word);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.VocableId == id);
        }
  
    }
}
