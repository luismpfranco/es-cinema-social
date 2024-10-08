using CinemaSocial.Data;
using CinemaSocial.Models.Entities.Watchlists;
using Microsoft.EntityFrameworkCore;

namespace CinemaSocial.Patterns.Strategy;

public class AddToWatchStrategy : IWatchlistStrategy
{
    private readonly AppDbContext _context;
    
    public AddToWatchStrategy(AppDbContext context)
    {
        _context = context;
    }
    public async Task ExecuteAsync(int userId, Guid movieId)
    {
        var toWatch = new WatchlistToWatch { UserId = userId, MovieId = movieId };
        _context.WatchlistToWatch.Add(toWatch);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> IsInWatchlistAsync(int userId, Guid movieId)
    {
        return await _context.WatchlistToWatch.AnyAsync(f => f.UserId == userId && f.MovieId == movieId);
    }
}