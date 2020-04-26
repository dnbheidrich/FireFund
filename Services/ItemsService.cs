using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class ItemsService
    {
        private readonly ItemsRepository _repo;
        public ItemsService(ItemsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Item> Get(string userId)
        {
            return _repo.Get(userId);
        }

           public Item GetById(int id, string userId)
        {
            Item found = _repo.GetById(id, userId);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

          internal object GetItemsByCategoryId(int id, string userId)
    {
            return _repo.GetItemsByCategoryId(id, userId);
      
    }

        public Item Create(Item newItem)
        {
            return _repo.Create(newItem);
        }

        //  internal Item Edit(Item updatedItem)
        // {
        //     Item found = GetById(updatedItem.Id, updatedItem.UserId);
        //     if (found.UserId != updatedItem.UserId)
        //     {
        //         throw new Exception("Invalid Request");
        //     }
        //     found.Name = updatedItem.Name;
        //     found.Description = updatedItem.Description;
        //     found.ImgUrl = updatedItem.ImgUrl != null ? updatedItem.ImgUrl : found.ImgUrl;
        //     return _repo.Edit(found);
        // }

         internal Item Delete(int id, string userId)
        {
            Item found = GetById(id, userId);
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