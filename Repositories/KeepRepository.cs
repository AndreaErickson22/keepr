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
    // GET KEEP BY ID
    public Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id =@Id", new { Id });
    }



    //CREATE KEEP
    public Keep CreateKeep(Keep keep)
    {

      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps ( name, 
        description, userId, img) VALUES(@Name, @Description, @UserId, @Img); SELECT LAST_INSERT_ID(); ", keep);
      if (id == 0)
      {
        return null;
      }
      keep.Id = id;
      return keep;
    }

    //DELETE KEEP
    public bool DeleteKeep(int id)
    {
      int successfulDelete = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      return successfulDelete > 0;

    }

    internal Keep NewKeep(Keep newKeep)
    {
      throw new NotImplementedException();
    }

    internal Keep PostKeep(Keep newKeep)
    {
      throw new NotImplementedException();
    }




    // 
    // 
    // 
    // Vault KEEPS
    // public int CreateVaultKeep(Vaultkeep vk)
    // {
    //   Keep keep = _db.Query<Keep>(@"SELECT * FROM vaultKeeps WHERE keepID = @KeepId AND vaultId = @VaultId;", vk).FirstOrDefault();
    //   if (keep != null) return 0;
    //   return _db.ExecuteScalar<int>(@"INSERT INTO vaultKeeps (vaultId, keepId, userId) VALUES (@VaultId, @KeepId, @UserID);
    //   SELECT LAST_INSERT_ID();", vk);
    // }

    internal Keep EditKeep(int id, Keep editedKeep, string userId)
    {
      throw new NotImplementedException();
    }
  }
}