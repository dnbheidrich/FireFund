using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _repo;
        public CategoriesService(CategoriesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Category> Get(string userId)
        {
            return _repo.Get(userId);
        }

           public Category GetById(int id, string userId)
        {
            Category found = _repo.GetById(id, userId);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

          internal object GetCategoriesByRoomId(int id, string userId)
    {
            return _repo.GetCategoriesByRoomId(id, userId);
      
    }

        public Category Create(Category newCategory)
        {
            return _repo.Create(newCategory);
        }

        //  internal Category Edit(Category updatedCategory)
        // {
        //     Category found = GetById(updatedCategory.Id, updatedCategory.UserId);
        //     if (found.UserId != updatedCategory.UserId)
        //     {
        //         throw new Exception("Invalid Request");
        //     }
        //     found.Name = updatedCategory.Name;
        //     found.Description = updatedCategory.Description;
        //     found.ImgUrl = updatedCategory.ImgUrl != null ? updatedCategory.ImgUrl : found.ImgUrl;
        //     return _repo.Edit(found);
        // }

         internal Category Delete(int id, string userId)
        {
            Category found = GetById(id, userId);
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