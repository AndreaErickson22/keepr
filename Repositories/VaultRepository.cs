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
    private object idVault;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vault Where id = @Id, new {Id}");

    }
    public Vault NewVault(Vault newVault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults(name, description, userId) VALUES (@Name, @Description, @UserId);
SELECT LAST INSERT ID();", newVault);
        newVault.Id = id;
        return newVault;

      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public Vault modifiedVault(int id, Vault editedVault)
    {
      try
      {
        string query = @"UPDATE vaults SET name = @editedVault.Name, description = @editedVault.Description, SELECT * FROM vaults WHERE id = @id;";

        return _db.QueryFirstOrDefault<Vault>(query, new { id, editedVault });

      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    internal Vault modifiedVault(Vault editedVault)
    {
      throw new NotImplementedException();
    }


    internal bool DeleteVault(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }







  }
}