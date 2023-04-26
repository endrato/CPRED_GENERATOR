namespace Cpred_generator.Models;
public class CyberWare : GeneralItem {
  public Dice HumanityCost { get; set; }

  public CyberWare(string name, string description, int ammount, Dice humanityCost) : base(name, description, ammount) {
    HumanityCost = humanityCost;
  }
}
