using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vaultkeep
  {
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }
    [Required]
    public int UserId { get; set; }


  }
}