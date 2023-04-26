namespace Cpred_generator.Models;
public class Ammo : GeneralItem {

  public Ammo(string name, string description, int ammount, AmmoType ammoType) : base(name, description, ammount) {
    AmmoType = ammoType;
  }
  public AmmoType AmmoType { get; set; }
}
