using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Keepr.Controllers;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    //GET ALL KEEPS IN VAULT BY KEEP ID   
    public IEnumerable<Keep> GetKeeps(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public Vaultkeep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vaultkeep>("SELECT * FROM Vaultkeep WHERE id =@id", new { Id });
    }

    // internal Vaultkeep NewVaultKeep(Vaultkeep newVaultKeep)
    // {
    //   throw new NotImplementedException();
    // }


    // // new post vault keep made
    public Vaultkeep createVaultKeep(Vaultkeep vaultKeepToCreate)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaultKeeps (id, vaultId, keepId, userId)
        VALUES (@Id, @VaultId, @KeepId, @UserId); SELECT LAST_INSERT_ID();", vaultKeepToCreate);
        vaultKeepToCreate.Id = id;
        return vaultKeepToCreate;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    public IEnumerable<Keep> GetVaultKeep(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vkr  INNER JOIN keeps k ON k.id = vk.keepId WHERE(vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
    }

  }
}