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


    // //new post vault keep made
    // public Vaultkeep NewVaultKeep(Vaultkeep vaultKeepToCreate)
    // {
    //   try
    //   {
    //     int id = _db.ExecuteScalar<int>(@"INSERT INTO Vaultkeeps (vaultId, keepId, userId)
    //     VALUES (@VaultId, @KeepId, @UserId)); SELECT LAST_INSERT_ID();,vaultKeepToCreate);",
    //     vaultKeepToCreate.Id = id; 
    //   return vaultKeepToCreate;
    //   }
    //   catch (Exception e)
    //   {
    //     Console.WriteLine(e);
    //     return null;
    //   }
    // }

  }
}