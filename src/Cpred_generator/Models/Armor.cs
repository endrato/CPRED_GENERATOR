namespace Cpred_generator.Models;
public class Armor : GeneralItem {
  public int ArmorClass { get; set; }

  public Armor(string name, string description, int ammount, int armorClass) : base(name, description, ammount) {
    ArmorClass = armorClass;
  }
}
