using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogFinal.Data;
using TheBlogFinal.Enums;
using TheBlogFinal.Models;

namespace TheBlogFinal.Services
{
    public class BlogSearchService
    {

        private readonly ApplicationDbContext _context;

        public BlogSearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Search(string searchTerm)
        {
            var posts = _context.Posts.Where(p => p.ReadyStatus == ReadyStatus.ProductionReady).AsQueryable();

            if (searchTerm != null)
            {
                searchTerm = searchTerm.ToLower();

                posts = posts.Where(
                    p => p.Title.Contains(searchTerm) ||
                    p.Abstract.Contains(searchTerm) ||
                    p.Content.Contains(searchTerm) ||
                    p.Comments.Any(c => c.Body.Contains(searchTerm) ||
                                              c.ModeratedBody.Contains(searchTerm) ||
                                              c.BlogUser.FirstName.Contains(searchTerm) ||
                                              c.BlogUser.LastName.Contains(searchTerm) ||
                                              c.BlogUser.Email.Contains(searchTerm)));

            }


            return posts.OrderByDescending(p => p.Created);

            
        }
    }
}

        
