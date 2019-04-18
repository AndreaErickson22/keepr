using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;
using Keepr.Controllers;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    //GET ALL KEEPS
    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    //Get all Keeps by user id
    public IEnumerable<Keep> GetByUserId(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId =@UserId", param: new { userId });
    }

    // // GET KEEP BY ID
    // public Keep GetById(int Id)
    // {
    //   return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id =@Id", new { Id });
    // }

    //CREATE KEEP
    public Keep CreateKeep(Keep keep)
    {

      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps ( name, 
        description, userId, img, isPrivate) VALUES(@Name, @Description, @UserId, @Img, @IsPrivate); SELECT LAST_INSERT_ID(); ", keep);
      if (id == 0)
      {
        return null;
      }
      keep.Id = id;
      return keep;
    }

    //EDIT KEEP

    public int EditKeep(Keep editedKeep)
    {
      try
      {
        return _db.Execute($@"UPDATE keeps SET views = @Views, shares=@Shares, keeps=@Keeps WHERE id = @Id;", editedKeep);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return 0;
      }
    }


    //DELETE KEEP
    internal bool DeleteKeep(int id)
    {
      int successfulDelete = _db.Execute(@"DELETE FROM keeps WHERE id = @id", new { id });
      return successfulDelete > 0;
    }
  }

}