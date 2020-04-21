using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class RoomsService
    {
        private readonly RoomsRepository _repo;
        public RoomsService(RoomsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Room> Get(string userId)
        {
            return _repo.Get(userId);
        }

        public Room Create(Room newRoom)
        {
            return _repo.Create(newRoom);
        }
    }
}