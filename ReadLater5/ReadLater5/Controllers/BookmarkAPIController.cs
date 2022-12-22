using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Entity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ReadLater5.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkAPIController : ControllerBase
    {





        IBookmarkAPIService _bookmarkAPIService;

        public BookmarkAPIController(IBookmarkAPIService bookmarkAPIService)
        {
            
            _bookmarkAPIService = bookmarkAPIService;

            
        }

        // GET: api/BookmarkAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookmark>>> GetBookmark()
        {
            return await _bookmarkAPIService.GetBookmarks();
        }

        // GET: api/BookmarkAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookmark>> GetBookmark(int id)
        {
            return await _bookmarkAPIService.GetBookmark(id);
        }

        // PUT: api/BookmarkAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookmark(int id, Bookmark bookmark)
        {

            return (IActionResult)_bookmarkAPIService.PutBookmark(id, bookmark);
        }

        // POST: api/BookmarkAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookmark>> PostBookmark(Bookmark bookmark)
        {
            //_context.Bookmark.Add(bookmark);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBookmark", new { id = bookmark.ID }, bookmark);

            return _bookmarkAPIService.PostBookmark(bookmark);
        }

        // DELETE: api/BookmarkAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookmark(int id)
        {
            return (IActionResult)_bookmarkAPIService.DeleteBookmarkAsync(id);
        }

    }
}
