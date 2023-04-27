using Cpred_generator.Interfaces;

namespace Cpred_generator.Models;

public class Skill : IStat {
  public string? Name { get; set; }
  public int Level { get; set; }
}
