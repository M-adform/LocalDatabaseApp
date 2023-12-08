using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DTOs;
using Shop.Data;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemRequestsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ShopItemRequestsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/ShopItemRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopItemRequest>>> GetShopItemRequest()
        {
            return await _context.ShopItemRequest.ToListAsync();
        }

        // GET: api/ShopItemRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItemRequest>> GetShopItemRequest(string id)
        {
            var shopItemRequest = await _context.ShopItemRequest.FindAsync(id);

            if (shopItemRequest == null)
            {
                return NotFound();
            }

            return shopItemRequest;
        }

        // PUT: api/ShopItemRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopItemRequest(string id, ShopItemRequest shopItemRequest)
        {
            if (id != shopItemRequest.Item_Name)
            {
                return BadRequest();
            }

            _context.Entry(shopItemRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopItemRequestExists(id))
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

        // POST: api/ShopItemRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopItemRequest>> PostShopItemRequest(ShopItemRequest shopItemRequest)
        {
            _context.ShopItemRequest.Add(shopItemRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShopItemRequestExists(shopItemRequest.Item_Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShopItemRequest", new { id = shopItemRequest.Item_Name }, shopItemRequest);
        }

        // DELETE: api/ShopItemRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopItemRequest(string id)
        {
            var shopItemRequest = await _context.ShopItemRequest.FindAsync(id);
            if (shopItemRequest == null)
            {
                return NotFound();
            }

            _context.ShopItemRequest.Remove(shopItemRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopItemRequestExists(string id)
        {
            return _context.ShopItemRequest.Any(e => e.Item_Name == id);
        }
    }
}
