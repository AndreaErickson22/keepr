using keepr.Repositories;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Keepr.Controllers;
using System.Collections.Generic;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class VaultKeepsController : ControllerBase

  {
    private readonly VaultKeepsRepository _vkr;
    // private object newVaultkeep;

    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }


    //GET ALL KEEPS IN VAULT KEEPS BY VAULT ID
    [HttpGet("{id}/vault")]
    public ActionResult<IEnumerable<User>> GetVaultKeeps(int id)
    {
      IEnumerable<Keep> results = _vkr.GetKeeps(id);
      return Ok(results);
    }


    //   //Create VAULT KEEP
    //   [HttpPost("{vaultId}")]
    //   [Authorize]
    //   public ActionResult<Vaultkeep> newVaultKeep([FromBody]Vaultkeep newVaultKeep)
    //   {
    //     newVaultKeep.UserId = HttpContext.User.Identity.Name;
    //     Vaultkeep result = _vkr.NewVaultKeep(newVaultKeep);
    //     if (newVaultKeep == null)
    //     {
    //       return BadRequest("did not create new vault keep");
    //     }
    //     return Ok(newVaultKeep)
    //       ;
    //   }

    // }

    // // //DELETE KEEPS FROM VAULT

    // [HttpDelete("{id}")]
    // public ActionResult<string> Delete[FromBody] VaultKeepsController vaultkeep)
    // {
    //  var result = _vkr.DeleteVaultKeep(vaultkeep);
    //   if (!successful) 
    //   { return BadRequest(); }
    //   return Ok();
  }
// //Get ALL KEEPS IN VAULT BY USER ID
// [HttpGet("{id}/user")]
// public ActionResult<IEnumerable<User>> GetVaultKeepsUserId(int id)
// {
//   IEnumerable<Keep> results = _vkr.GetKeeps(id);
//   return Ok(results);
// }


// //Get ALL KEEPS IN VAULT BY KEEP ID
// [HttpGet("{id}/keeps")]
// public ActionResult<IEnumerable<Keep>> GetKeeps(int id)
// {
//   IEnumerable<Keep> results = _vkr.GetKeeps(id);
//   return Ok(results);
// }

// [HttpDelete("{id}/user")]
// public ActionResult<IEnumberable<User>> DeleteVaultKeeps(int id)


