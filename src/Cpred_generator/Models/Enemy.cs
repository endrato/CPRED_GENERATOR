namespace Cpred_generator.Models;
public class Enemy {
  public string Name { get; set; }
  public int Health { get; set; }
  public int ArmorClass { get; set; }
  public List<Weapon> Weapons { get; set; }
  public List<Ammo> Ammo { get; set; }
  public List<CyberWare> CyberWare { get; set; }
  public List<Armor> Armor { get; set; }

  public Enemy(string name, int health, int armorClass) {
    Name = name;
    Health = health;
    ArmorClass = armorClass;
    Weapons = new List<Weapon>();
    Ammo = new List<Ammo>();
    CyberWare = new List<CyberWare>();
    Armor = new List<Armor>();
  }
}
