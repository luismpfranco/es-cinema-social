using CinemaSocial.Data;
using CinemaSocial.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaSocial.Repository;

public class MovieRepository(AppDbContext context) : IMovieRepository
{
    public async Task<List<Movie?>> GetMoviesAsync()
    {    
        return (await context.Movies
            .Include(m => m.Director)
            .Include(m => m.Writers)
            .Include(m => m.Stars)
            .Include(m => m.Genre)
            .Include(m => m.Images)
            .ToListAsync())!;
    }
    
    public async Task<Movie?> GetMovieByIdAsync(Guid id)
    {
        return await context.Movies
            .Include(m => m.Director)
            .Include(m => m.Writers)
            .Include(m => m.Stars)
            .Include(m => m.Genre)
            .Include(m => m.Images)
            .FirstOrDefaultAsync(m => m.IdMovie == id);
    }
}