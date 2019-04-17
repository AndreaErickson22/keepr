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


    //new post vault keep made
    public Vaultkeep NewVaultKeep(Vaultkeep vk)
    {
      try
      {
        int id = _db.Execute(@"INSERT INTO Vaultkeeps (vaultId, keepId, userId)
        VALUES (@VaultId, @KeepId, @UserId)", vk);


        return vk;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

  }
}