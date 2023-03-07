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
    public class AvatarsController : ControllerBase
    {
        private readonly LTcontext _context;

        public AvatarsController(LTcontext context)
        {
            _context = context;
        }

        // GET: api/Avatars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avatar>>> Getavatars()
        {
            if (_context.avatars == null)
            {
                return NotFound();
            }
            var avatars = await _context.avatars.ToListAsync();
            foreach (var avatar in avatars)
            {
                var items = await _context.items.Where(d => d.AvatarID == avatar.AvatarId).ToListAsync();
            }
            return avatars;
        }

        // GET: api/Avatars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvatarDetailsDTO>> GetAvatar(int id)
        {
            if (_context.avatars == null)
            {
                return NotFound();
            }

            var avatar = await _context.avatars.FindAsync(id);

            if (avatar == null)
            {
                return NotFound();
            }
            var items = await _context.items.Where(d => d.AvatarID == avatar.AvatarId).ToListAsync();
            var ADTO = new AvatarDetailsDTO
            {
                AvatarId = avatar.AvatarId,
                AvatarName = avatar.AvatarName,
                XP = avatar.XP,
                XPLevel = avatar.XPLevel,
                Items = items
            };

            return Ok(ADTO);
        }

        // PUT: api/Avatars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvatar(int id, AvatarDTO dto)
        {
            var avatar = new Avatar(dto, id);
            if (avatar.Items == null)
            {
                var Items = await _context.items.Where(d => d.AvatarID == avatar.AvatarId).ToListAsync();
                avatar.Items = Items;
            }
            if (id != avatar.AvatarId)
            {
                return BadRequest();
            }

            _context.Entry(avatar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvatarExists(id))
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

        // POST: api/Avatars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avatar>> PostAvatar(AvatarDTO dto)
        {
            if( _context.avatars == null)
            {
                return Problem("Entity set 'LTcontext.avatars is null");
            }
            var avatar = new Avatar(dto);
            _context.avatars.Add(avatar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvatar", new { id = avatar.AvatarId }, avatar);
        }

        // DELETE: api/Avatars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvatar(int id)
        {
            var avatar = await _context.avatars.FindAsync(id);
            if (avatar == null)
            {
                return NotFound();
            }

            _context.avatars.Remove(avatar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvatarExists(int id)
        {
            return _context.avatars.Any(e => e.AvatarId == id);
        }
    }
}
