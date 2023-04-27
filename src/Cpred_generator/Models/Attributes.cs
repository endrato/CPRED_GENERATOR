using Cpred_generator.Interfaces;

namespace Cpred_generator.Models;

public class Attributes : IStat {
  public string? Name { get; set; }
  public int Level { get; set; }

  public Attributes(string name, int level) {
    Name = name;
    Level = level;
  }
}
