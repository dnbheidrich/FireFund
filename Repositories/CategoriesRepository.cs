using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class CategoriesRepository
    {
        private readonly IDbConnection _db;

        public CategoriesRepository(IDbConnection db)
        {
            _db = db;
        }

         internal IEnumerable<Category> Get(string UserId)
        {
            string sql = "SELECT * FROM categories WHERE userId = @UserId";
            return _db.Query<Category>(sql, new { UserId });
        }


   public Category GetById(int Id, string userId)
        {
            string sql = "SELECT * FROM categories WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Category>(sql, new { Id, userId });
        }

         internal object GetCategoriesByRoomId(int id, string userId)
    {
       string sql = "SELECT * FROM categories WHERE roomId = @Id AND userId = @UserId";
            return _db.Query<Category>(sql, new { id, userId });
    }

         internal Category Create(Category newCategory)
        {
           string sql =  @"
            INSERT INTO categories
            (name, userId, description, imgUrl, roomId)
            VALUES
            (@Name, @UserId, @Description, @ImgUrl, @RoomId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newCategory);
            newCategory.Id = id;
            return newCategory; 
        }

   

    // public Category Edit(Category updatedCategory)
    // {
    //     string sql = @"
    //     UPDATE categories
    //     SET
    //         name = @Name,
    //         description = @Description,
    //         imgUrl  = @ImgUrl
    //     WHERE id = @Id;
    //     ";
    //     _db.Execute(sql, updatedCategory);
    //     return updatedCategory;
    // }

    internal bool Delete(int Id)
        {
            string sql = "DELETE FROM categories WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}