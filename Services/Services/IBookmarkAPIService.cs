using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookmarkAPIService
    {
        Task<List<Bookmark>> GetBookmarks();
        Task<Bookmark> GetBookmark(int id);
        Bookmark PutBookmark(int id, Bookmark bookmark);
        Bookmark PostBookmark(Bookmark bookmark);
        Task<bool> DeleteBookmarkAsync(int id);
    }
}
