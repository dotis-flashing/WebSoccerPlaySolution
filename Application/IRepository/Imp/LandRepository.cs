﻿using Application.IGenericRepository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class LandRepository : GenericRepository<Land>, ILandRepository
    {
        public LandRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<Land> GetLandByIdLand(Guid landId)
        {
            var land = await _context.Set<Land>()!.Include(a => a.Prices).Include(f => f.Feedbacks).Include(c => c.Images)
                .FirstOrDefaultAsync(land => land.LandId == landId);
            //.FirstOrDefaultAsync(land => land.LandId == landId && land.TotalPitch != 0);
            return land;
        }

        public async Task<List<Land>> GetAllLand()
        {
            return await _context.Set<Land>().Include(a => a.Prices).Include(c => c.Images).Include(f => f.Feedbacks).Where(land => land.TotalPitch != 0)
                .ToListAsync();
        }

        public async Task<List<Land>> GetLandByOwnerId(Guid ownerId)
        {
            return await _context.Set<Land>().Include(a => a.Prices).Include(c => c.Images).Include(f => f.Feedbacks).Include(b => b.Bookings)
                .Where(land => land.OwnerId == ownerId).ToListAsync();
        }

        public async Task<List<Guid>> GetPitchByOwnerId(Guid ownerId)
        {
            var land = await _context.Set<Land>()!.Include(p => p.Pitches)
                .Where(land => land.OwnerId == ownerId).Select(l => l.LandId).ToListAsync();
            return land;
        }
        public async Task<List<Land>> GetTop6()
        {
            var topLands = await (
                    from feedback in _context.Feedbacks
                    group feedback by feedback.LandId
                    into grouped
                    orderby grouped.Average(f => f.Rate) descending
            select grouped.Key
            )
                .Take(6)
                .Join(
                    _context.Set<Land>()
                        .Include(a => a.Prices)
                        .Include(f => f.Feedbacks)
                        .Include(c => c.Images),
                    topLandId => topLandId,
                    land => land.LandId,
                    (topLandId, land) => land
                )
                .ToListAsync();

            return topLands;
        }

        public async Task<List<Land>> SearchLand(string location, string name)
        {
            //how to raise performance
            var lands = _context.Set<Land>()
                .Include(a => a.Prices)
                .Include(f => f.Feedbacks)
                .Include(c => c.Images)
                .Where(land =>
                    (string.IsNullOrEmpty(location) || land.Location.ToLower().Contains(location.ToLower())) &&
                    land.TotalPitch != 0 &&
                    (string.IsNullOrEmpty(name) || land.NameLand.ToLower().Contains(name.ToLower())));
            return await lands.ToListAsync();
        }

        public async Task<List<Land>> SearchLandByLocation(string location)
        {
            var lands = await _context.Set<Land>().Include(a => a.Prices).Include(f => f.Feedbacks).Include(c => c.Images)
                .Where(land => land.Location.ToLower().Contains(location.ToLower()) && land.TotalPitch != 0).ToListAsync();
            return lands;
        }

        public async Task<List<Land>> SearchLandByName(string name)
        {
            var lands = await _context.Set<Land>().Include(a => a.Prices).Include(f => f.Feedbacks).Include(c => c.Images)
                .Where(land => land.NameLand.Contains(name) && land.TotalPitch != 0).ToListAsync();
            //.Where(land => land.NameLand.Contains(name) && land.TotalPitch != 0).ToListAsync();
            return lands;
        }

        public async Task<List<Land>> FilterLand(string location, int rate, float min, float max, int size)
        {
            var query =
                from l in _context.Lands
                where (string.IsNullOrEmpty(location) || l.Location.Contains(location))
                      && (size == 0 || l.Pitches.Any(p => p.Size == size))
                      && (rate == 0 || (!l.Feedbacks.Any() ? false : l.Feedbacks.Average(feedback => feedback.Rate) == rate))
                      && ((min == 0 || l.Prices.Min(price => price.Price1) >= min) && (max == 0 || l.Prices.Max(price => price.Price1) <= max))
                      && l.TotalPitch != 0
                select l;

            var result = await query
                .Include(l => l.Prices)
                .Include(l => l.Images)
                .Include(l => l.Feedbacks)
                .ToListAsync();

            return result;
        }

        public async Task<List<Land>> GetLandByOwnerIdAndLand(Guid ownerId, string nameLand)
        {
            return await _context.Set<Land>().Include(a => a.Prices).Include(c => c.Images).Include(f => f.Feedbacks).Include(b => b.Bookings)
               .Where(land => land.OwnerId == ownerId && land.NameLand == nameLand).ToListAsync();
        }

        public async Task<List<Land>> GetTop3Land(Guid ownerId)
        {
            var topLands = await (
                    from b in _context.Bookings
                    where b.Land.OwnerId == ownerId
                    group b by b.LandId
                    into grouped
                    orderby grouped.Sum(b => b.TotalPrice) descending
                    select grouped.Key
            )
                .Take(3)
                .Join(
                    _context.Lands
                        .Include(a => a.Prices)
                        .Include(f => f.Feedbacks)
                        .Include(c => c.Images)
                        .Include(b => b.Bookings),
                    topLandId => topLandId,
                    land => land.LandId,
                    (topLandId, land) => land
                )
                .ToListAsync();
            return topLands;
        }
    }
}
