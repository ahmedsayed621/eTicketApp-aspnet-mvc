using eTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketApp.Data.Services
{
    public class ActorsService : IActorsServices
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public async  Task AddAsync(Actor actor)
        {
          await  _context.Actors.AddAsync(actor);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
             _context.Actors.Remove(Result);
            
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var Result = await _context.Actors.ToListAsync();
            return Result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var Result = await _context.Actors.FirstOrDefaultAsync(n => n.Id==id);
            return Result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
