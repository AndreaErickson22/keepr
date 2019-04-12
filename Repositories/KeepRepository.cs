using System.Collections.Generic;
using System.Data;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM games WHERE id =@Id", new { Id });
    }

    public Keep CreateKeep(Keep keep)
    {
      try
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

    }
  }
}