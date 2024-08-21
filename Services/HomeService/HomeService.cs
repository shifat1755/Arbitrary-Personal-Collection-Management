using APCM.Data;
using APCM.Models;
using APCM.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCM.Services.HomeService
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<List<Collection>>> RecentCollections(int a)
        {
            var response = new Response<List<Collection>>();
            try
            {
                var data = await _dbContext.Collections
                    .OrderByDescending(c => c.CreatedAt)
                    .Take(a)
                    .Include(c=>c.CustomFields)
                    .Include(c=>c.Items)
                    .ToListAsync();
                response.Data = data;
                response.isSuccessful = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.isSuccessful = false;
            }
            return response;
        }
        public async Task<Response<List<Collection>>> LargestCollections(int a)
        {
            var response = new Response<List<Collection>>();
            try
            {
                var data = await _dbContext.Collections
                    .OrderByDescending(c => c.Items.Count)
                    .Take(a)
                    .Include(c=>c.CustomFields)
                    .Include(c=>c.Items)
                    .ToListAsync();
                response.Data = data;
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.isSuccessful = false;
            }
            return response;
        }
        public async Task<Response<List<Tag>>> GetTags()
        {
            var response = new Response<List<Tag>>();
            try
            {
                var data = await _dbContext.hashTags.ToListAsync();
                response.Data = data;
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.isSuccessful = false;
            }
            return response;
        }

    }
}
