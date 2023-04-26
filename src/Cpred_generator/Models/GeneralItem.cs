namespace Cpred_generator.Models;
public class GeneralItem {
  public GeneralItem(string name, string description, int ammount) {
    Name = name;
    Description = description;
    Ammount = ammount;
  }
  public string Name { get; set; }

  public string Description { get; set; }

  public int Ammount { get; set; }
}
