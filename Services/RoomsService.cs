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

           public Room GetById(int id, string userId)
        {
            Room found = _repo.GetById(id, userId);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        public Room Create(Room newRoom)
        {
            return _repo.Create(newRoom);
        }

         internal Room Edit(Room updatedRoom)
        {
            Room found = GetById(updatedRoom.Id, updatedRoom.UserId);
            if (found.UserId != updatedRoom.UserId)
            {
                throw new Exception("Invalid Request");
            }
            found.Name = updatedRoom.Name;
            found.Description = updatedRoom.Description;
            found.ImgUrl = updatedRoom.ImgUrl != null ? updatedRoom.ImgUrl : found.ImgUrl;
            return _repo.Edit(found);
        }

         internal Room Delete(int id, string userId)
        {
            Room found = GetById(id, userId);
            if (found.UserId != userId)
            {
                throw new Exception("Invalid Request");
            }
            if (_repo.Delete(id))
            {
                return found;
            }
            throw new Exception("Something went terribly wrong");
        }
    }
}