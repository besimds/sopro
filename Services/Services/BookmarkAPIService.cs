using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookmarkAPIService : IBookmarkAPIService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        public BookmarkAPIService(ReadLaterDataContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }

        public bool BookmarkExists(int id)
        {
            return _ReadLaterDataContext.Bookmark.Any(e => e.ID == id);
        }

        public async Task<bool> DeleteBookmarkAsync(int id)
        {
            var bookmark = await _ReadLaterDataContext.Bookmark.FindAsync(id);
            if (bookmark == null)
            {
                return false;
            }

            _ReadLaterDataContext.Bookmark.Remove(bookmark);
            await _ReadLaterDataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Bookmark> GetBookmark(int id)
        {
            var bookmark = await _ReadLaterDataContext.Bookmark.FindAsync(id);

            if (bookmark == null)
            {
                return null;
            }

            return bookmark;
        }

        public Task<List<Bookmark>> GetBookmarks()
        {
            return _ReadLaterDataContext.Bookmark.ToListAsync();
        }

        public Bookmark PostBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }

        public Bookmark PutBookmark(int id, Bookmark bookmark)
        {
            if (id != bookmark.ID)
            {
                return null;
            }

            try
            {
                _ReadLaterDataContext.Entry(bookmark).State = EntityState.Modified;
                _ReadLaterDataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookmarkExists(id))
                {
                    return null;
                }
                else
                {
                    return bookmark;
                }
            }

            return bookmark;


        }
    }
}
