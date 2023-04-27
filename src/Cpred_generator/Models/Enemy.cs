using System.Collections;
using System.Reflection;
using System.Text;

namespace Cpred_generator.Models;
public class Enemy {
  public string? Name { get; set; }

  public int Health { get; set; }

  public List<Skill>? Skills { get; set; }

  public List<Attributes>? Attributes { get; set; }

  public List<Weapon>? Weapons { get; set; }

  public List<Ammo>? Ammo { get; set; }

  public List<CyberWare>? CyberWare { get; set; }

  public List<Armor>? Armor { get; set; }

  public Enemy(string name) {
    Name = name;
  }
  public void PrintAttributes() {
    PropertyInfo[] properties = typeof(Enemy).GetProperties();
    foreach (PropertyInfo property in properties) {
      var value = property.GetValue(this);
      if (value is List<Attributes>) {
        var list = (IList)value;
        value = transformarAtributos((List<Attributes>)list);
      }
      if (value is List<Skill>) {
        var list = (IList)value;
        value = transformarSkills((List<Skill>)list);
      }
      if (property.GetValue(this) != null) { Console.WriteLine($"{property.Name}: {value}"); }

    }
  }

  private static string transformarAtributos(List<Attributes> lista) {
    var sb = new StringBuilder();
    foreach (var attr in lista) {
      sb.Append("\n");
      sb.Append(attr.Name + ": " + attr.Level + "\n");
    }
    return sb.ToString();
  }
  private static string transformarSkills(List<Skill> lista) {
    var sb = new StringBuilder();
    foreach (var attr in lista) {
      sb.Append("\n");
      sb.Append(attr.Name + ": " + attr.Level + "\n");
    }
    return sb.ToString();
  }
}
