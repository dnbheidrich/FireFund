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

        internal IEnumerable<Room> Get()
        {
            string sql = "SELECT * FROM rooms";
            return _db.Query<Room>(sql);
        }

        internal Room Create(Room newRoom)
        {
           string sql =  @"
            INSERT INTO rooms
            (name, description, imgUrl)
            VALUES
            (@Name, @Description, @ImgUrl);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newRoom);
            newRoom.Id = id;
            return newRoom; 
        }
    }
}