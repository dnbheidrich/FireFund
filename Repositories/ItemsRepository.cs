using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class ItemsRepository
    {
        private readonly IDbConnection _db;

        public ItemsRepository(IDbConnection db)
        {
            _db = db;
        }

         internal IEnumerable<Item> Get(string UserId)
        {
            string sql = "SELECT * FROM items WHERE userId = @UserId";
            return _db.Query<Item>(sql, new { UserId });
        }


   public Item GetById(int Id, string userId)
        {
            string sql = "SELECT * FROM items WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Item>(sql, new { Id, userId });
        }

         internal object GetItemsByCategoryId(int id, string userId)
    {
       string sql = "SELECT * FROM items WHERE categoryId = @Id AND userId = @UserId";
            return _db.Query<Item>(sql, new { id, userId });
    }

         internal Item Create(Item newItem)
        {
           string sql =  @"
            INSERT INTO items
            (name, userId, description, imgUrl, categoryId, quantity, acv, rcv)
            VALUES
            (@Name, @UserId, @Description, @ImgUrl, @CategoryId, @Quantity, @Acv, @Rcv);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newItem);
            newItem.Id = id;
            return newItem; 
        }

   

    // public Item Edit(Item updatedItem)
    // {
    //     string sql = @"
    //     UPDATE categories
    //     SET
    //         name = @Name,
    //         description = @Description,
    //         imgUrl  = @ImgUrl
    //     WHERE id = @Id;
    //     ";
    //     _db.Execute(sql, updatedItem);
    //     return updatedItem;
    // }

    internal bool Delete(int Id)
        {
            string sql = "DELETE FROM items WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}