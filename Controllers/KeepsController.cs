using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _kr;
    // private object keep;

    // public string Id { get; private set; }

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

    //Get All Keeps by user id
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetByUser(string user)
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> keepList = _kr.GetByUserId(UserId);
      if (keepList != null)
      {
        return Ok(keepList);
      }
      return BadRequest("Could not collect list of keeps");
    }


    // //Get one by Keep Id

    // [HttpGet("{id}")]
    // public ActionResult<IEnumerable<Keep>> Get(int id)
    // {
    //   Keep keepId = _kr.GetById(id);
    //   if (keepId != null)
    //   {
    //     return Ok(keepId);
    //   }
    //   return BadRequest("Unable to process your request for Keeps by id");
    // }

    //Post or Create a Keep

    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Create([FromBody]Keep newKeep)
    {
      newKeep.UserId = HttpContext.User.Identity.Name;
      if (newKeep.UserId != null)
      {
        Keep result = _kr.CreateKeep(newKeep);
        return Ok(result);
      }
      return Unauthorized("you must login to create a keep");

    }


    //EDIT UPDATE A KEEP
    [HttpPut]
    public ActionResult<string> EditKeep([FromBody]Keep editedKeep)
    {
      int result = _kr.EditKeep(editedKeep);

      if (result == 1)
      {
        return Ok("edit complete");
      }
      return BadRequest("Could not modify keep");
    }

    //DELETE KEEP

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
