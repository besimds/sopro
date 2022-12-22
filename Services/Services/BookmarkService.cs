using Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _ReadLaterDataContext;
        public BookmarkService(ReadLaterDataContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }
        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Add(bookmark);
            _ReadLaterDataContext.SaveChanges();
            return bookmark;
        }
        public void UpdateBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Update(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }
        public async Task<List<Bookmark>> GetBookmarks()
        {
            return await _ReadLaterDataContext.Bookmark.Include(b => b.Category).ToListAsync();
        }
        public async Task<Bookmark> GetBookmark(int id)
        {
            return await _ReadLaterDataContext.Bookmark
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
        }
        public void DeleteBookmark(Bookmark bookmark)
        {
            _ReadLaterDataContext.Bookmark.Remove(bookmark);
            _ReadLaterDataContext.SaveChanges();
        }

        public async Task<List<Category>> selectListCategories()
        {
            return await _ReadLaterDataContext.Categories.ToListAsync();
        }
    }
}
