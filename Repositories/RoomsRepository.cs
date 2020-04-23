using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class RoomsRepository
    {
        private readonly IDbConnection _db;

        public RoomsRepository(IDbConnection db)
        {
            _db = db;
        }

         internal IEnumerable<Room> Get(string UserId)
        {
            string sql = "SELECT * FROM rooms WHERE userId = @UserId";
            return _db.Query<Room>(sql, new { UserId });
        }


   public Room GetById(int Id, string userId)
        {
            string sql = "SELECT * FROM rooms WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Room>(sql, new { Id, userId });
        }

        internal Room Create(Room newRoom)
        {
           string sql =  @"
            INSERT INTO rooms
            (name, userId, description, imgUrl)
            VALUES
            (@Name, @UserId, @Description, @ImgUrl);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newRoom);
            newRoom.Id = id;
            return newRoom; 
        }

        public Room Edit(Room updatedRoom)
        {
            string sql = @"
            UPDATE rooms
            SET
                name = @Name,
                description = @Description,
                imgUrl  = @ImgUrl
            WHERE id = @Id;
            ";
            _db.Execute(sql, updatedRoom);
            return updatedRoom;
        }

         internal bool Delete(int Id)
        {
            string sql = "DELETE FROM rooms WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}