using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAcces.DAOs
{
    public class PostEfcDao : IPostDao
    {
        private readonly PostContext context;

        public PostEfcDao(PostContext context)
        {
            this.context = context;
        }
        public async Task<Post> CreateAsync(Post post)
        {
            EntityEntry<Post> added = await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
        {
            IQueryable<Post> usersQuery = context.Posts.AsQueryable();
            if (searchParameters.TitleContains != null)
            {
                usersQuery = usersQuery.Where(u => u.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
            }

            IEnumerable<Post> result = await usersQuery.ToListAsync();
            return result;
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            Post? post = await context.Posts.FindAsync(id);
            return post;
        }

        public async Task DeleteAsync(int postId)
        {
            // Implement the logic to delete a post from the database
            // based on the provided post ID.
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Post post)
        {
            // Implement the logic to update a post in the database
            // based on the provided post object.
            throw new NotImplementedException();
        }   
    }
}