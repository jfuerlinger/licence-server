using System;

namespace LicenceManager.Core
{
  public class Licence
  {
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime ValidUntil { get; set; }
    public string Comment { get; set; }

    public override string ToString() => $"UserName={UserName} ValidUntil={ValidUntil.ToShortDateString()}";
  }
}
