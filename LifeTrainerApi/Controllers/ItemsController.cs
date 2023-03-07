using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LifeTrainerApi.Data;
using LifeTrainerApi.Models;
using LifeTrainerApi.DTO;

namespace LifeTrainerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly LTcontext _context;

        public ItemsController(LTcontext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Getitems()
        {
            if (_context.items == null)
            {
                return NotFound();
            }
            return await _context.items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDetailsDTO>> GetItem(int id)
        {
            if (_context.items == null)
            {
                return NotFound();
            }
            var item = await _context.items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            var IDTO = new ItemDetailsDTO
            {
                ItemId = item.ItemId,
                AvatarID = item.AvatarID,
                ItemName = item.ItemName,
                Description = item.description,
                RewardAmount = item.RewardAmount,
                CompletionCount = item.CompletionCount
            };
            return Ok(IDTO);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemsDTO dto)
        {
            var item = new Item(dto, id);

            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemsDTO dto)
        {
            if (_context.items == null)
            {
                return Problem("entity set 'LTcontect.items is null");
            }
            var item = new Item(dto);
            _context.items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.items.Any(e => e.ItemId == id);
        }
    }
}
