using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark bookmark);
        Task<List<Bookmark>> GetBookmarks();
        Task<Bookmark> GetBookmark(int id);
        void UpdateBookmark(Bookmark bookmark);
        void DeleteBookmark(Bookmark bookmark);
        Task<List<Category>> selectListCategories();
    }
}
