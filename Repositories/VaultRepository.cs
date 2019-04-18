using System;
using System.Data;
using System.Collections.Generic;
using keepr.Controllers;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    // private object idVault;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    //GET VAULT BY USER ID
    public IEnumerable<Vault> GetVaultsByUserId(string UserId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId", new { UserId });

    }

    //GET VAULT BY VAULT ID
    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults Where id = @Id, new {Id}");

    }

    //NEW VAULT REPO
    public Vault NewVault(Vault newVault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults(name, description, userId) VALUES (@Name, @Description, @UserId);
SELECT LAST_INSERT_ID();", newVault);
        newVault.Id = id;
        return newVault;

      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    //EDITED VAULT REPO
    public Vault modifiedVault(Vault editedVault)
    {
      try
      {
        string query = @"UPDATE vaults SET name = @editedVault.Name, description = @editedVault.Description, SELECT * FROM vaults WHERE id = @id;";

        return _db.QueryFirstOrDefault<Vault>(query, new { editedVault });

      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }


    //DELETE VAULT REPO
    internal bool DeleteVault(int id, string userId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id AND userId = @UserId", new { id, userId });
      return success > 0;
    }

    internal Vaultkeep NewVaultKeep(Vaultkeep newVaultKeep)
    {
      throw new NotImplementedException();
    }
  }
}