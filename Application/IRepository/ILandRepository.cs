﻿using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ILandRepository : IGenericRepository<Land>
    {
        Task<Land> GetLandByIdLand(Guid landId);

        Task<List<Land>> GetAllLand();

        Task<List<Land>> GetLandByOwnerId(Guid ownerId);
        Task<List<Land>> GetLandByOwnerIdAndLand(Guid ownerId, string nameLand);

        Task<List<Guid>> GetPitchByOwnerId(Guid ownerId);

        Task<List<Land>> GetTop6();

        Task<List<Land>> SearchLand(string location, string name);
        Task<List<Land>> SearchLandByLocation(string location);
        Task<List<Land>> SearchLandByName(string name);

        Task<List<Land>> FilterLand(string location, int rate, float min, float max, int size);
        Task<List<Land>> GetTop3Land(Guid ownerId);
    }
}
