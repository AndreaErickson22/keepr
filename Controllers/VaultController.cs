
using System.Collections.Generic;
using System;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/controller]")]
  [ApiController]

  public class VaultController : ControllerBase
  {
    private readonly VaultRepository _vr;
    private string id;

    public string Id { get; private set; }

    public VaultController(VaultRepository vr)
    {
      _vr = vr;
    }

    //GET VAULT BY ID
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault found = _vr.GetById(id);
      if (found != null)
      { return Ok(found); }

      return BadRequest("Could not get vault by id");

    }

    // POST

    [HttpPost]
    public ActionResult<Vault> Create([FromBody]Vault newVault)
    {
      Vault result = _vr.NewVault(newVault);
      if (result != null)
      {
        return result;
      }
      return BadRequest("Could not make new vault.");

    }


    //PUT

    [HttpPut]

    public ActionResult<Vault> Put([FromBody]Vault editedVault)
    {
      Vault result = _vr.modifiedVault(editedVault);
      if (result != null)
      {
        return result;
      }
      return BadRequest("could not edit this keep");
    }



    //DELETE VAULT

    [HttpDelete("{id}")]
    public ActionResult<string> DeleteVault(int id)
    {
      bool successful = _vr.DeleteVault(id);
      {
        if (!successful)
        { return BadRequest("Unable to process delete."); }
        return Ok("Vault was successfully deleted.");
      }

    }

  }

}