using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[keeps]")]
  [ApiController]
  public class KeepController : ControllerBase
  {
    private readonly KeepRepository _kr;
    public KeepController(KeepRepository_kr)
    {
      _kr = _kr;
    }
  }
}