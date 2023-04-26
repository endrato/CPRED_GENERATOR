namespace Cpred_generator.Models;
public class Weapon : GeneralItem {
  public Dice Damage { get; set; }
  public Dice Range { get; set; }
  public AmmoType AmmoType { get; set; }

  public Weapon(string name, string description, int ammount, Dice damage, Dice range, AmmoType ammoType) : base(name, description, ammount) {
    Damage = damage;
    Range = range;
    AmmoType = ammoType;
  }
}
