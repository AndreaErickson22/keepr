using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _kr;
    private object keep;

    public string Id { get; private set; }

    public KeepsController(KeepRepository kr)
    {
      _kr = kr;
    }


    //Get All Keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> keepList = _kr.GetAllKeeps();
      if (keepList != null)
      {
        return Ok(keepList);
      }
      return BadRequest("Could not collect list of keeps");
    }

    //Get by Keep Id

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      Keep keepId = _kr.GetById(id);
      if (keepId != null)
      {
        return Ok(keepId);
      }
      return BadRequest("Unable to process your request for Keeps by id");
    }

    //Post or Create a Keep

    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Create([FromBody]Keep newKeep)
    {

      string userId = HttpContext.User.Identity.Name;
      keep.userId = userId;
      Keep result = _kr.CreateKeep(newKeep);

      if (result != null)
      {
        return result;
      }
      return BadRequest("Could not make new keep");
    }

    //Put or modify a Keep

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Keep> Put(int id, [FromBody]Keep editedKeep)
    {
      //must be logged in to edit a keep
      string userId = HttpContext.User.Identity.Name;
      Keep result = _kr.EditKeep(id, editedKeep, userId);

      if (result != null)
      {
        return result;
      }
      return BadRequest("Could not modify keep");
    }

    //DELETE KEEP

    // [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteKeep(int id)
    {
      if (_kr.DeleteKeep(id))

      {
        return Ok();
      }
      return BadRequest("Unable to delete this keep");
    }

  }
}
