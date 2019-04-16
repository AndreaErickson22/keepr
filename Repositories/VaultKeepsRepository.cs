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

    public Vaultkeep NewVaultKeep(Vaultkeep newVaultKeep)
    {
      throw new NotImplementedException();
    }

    internal Vaultkeep NewVaultKeep(object newVaultkeep)
    {
      throw new NotImplementedException();
    }
  }
}