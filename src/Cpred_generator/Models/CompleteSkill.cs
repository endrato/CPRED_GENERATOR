namespace Cpred_generator.Models;
public class CompleteSkill {
  public string Name { get; set; }
  public string Category { get; set; }
  public bool X2 { get; set; }
  public int Base { get; set; }
  public int Stat { get; set; }

  public CompleteSkill(string name, string category, bool x2) {
    Name = name;
    Category = category;
    X2 = x2;
    Base = 0;
    Stat = 0;
  }
}
