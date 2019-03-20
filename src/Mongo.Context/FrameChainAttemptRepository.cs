using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgenuity.MongoDB
{
    public interface IFrameChainAttemptRepository
    {
        Task<IEnumerable<FrameChainAttempt>> GetFrameChainAttempts();
        Task<FrameChainAttempt> GetFrameChainAttempt();
        Task<FrameChainAttempt> GetFrameChainAttemptByUserName(string userName);
        FrameChainAttempt AddFrameChainAttempt(string userName);
    }

    public class FrameChainAttemptRepository : IFrameChainAttemptRepository
    {
        private IMongoDbContext _context = null;
        public FrameChainAttemptRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FrameChainAttempt>> GetFrameChainAttempts()
        {
            return await _context.FrameChainAttempts.Find(_ => true).Limit(100).ToListAsync();
        }

        public async Task<FrameChainAttempt> GetFrameChainAttempt()
        {
            try
            {
                return await _context.FrameChainAttempts.Find(_ => true).Limit(1).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FrameChainAttempt> GetFrameChainAttemptByUserName(string userName)
        {
            try
            {
                return await _context.FrameChainAttempts.Find(f => f.UserName == userName).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public FrameChainAttempt AddFrameChainAttempt(string userName)
        {
            try
            {
                var value = new FrameChainAttempt() { Message = DateTime.UtcNow.ToShortDateString(), UserName = userName };
                _context.FrameChainAttempts.InsertOne(value);
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
