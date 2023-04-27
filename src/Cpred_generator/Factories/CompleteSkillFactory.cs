using System.Text.Json;
using Cpred_generator.Models;

namespace Cpred_generator.Factories;

public class CompleteSkillFactory {
  private const int skillPoint = 86;
  private const int skillMax = 6;

  private static readonly List<string> MandatorySkillList = new() { "Athletics", "Brawling", "Concentration", "Conversation", "Education", "Evasion", "First Aid", "Human Perception", "Language", "Local Expert", "Perception", "Persuasion", "Stealth" };
  private static readonly List<string> CCSkillList = new() { "Brawling", "Evasion", "Martial Arts", "Melee Weapon" };
  private static readonly List<string> WeaponSkillList = new() { "Archery", "Autofire", "Handgun", "Heavy Weapons", "Shoulder Arms" };
  public List<CompleteSkill> CreateCompleteSkillsList(List<Attributes> attributes, bool cc) {
    return assignSkills(getListFromFile(), attributes, cc);
  }
  private List<CompleteSkill> getListFromFile() {
    var filePath = Path.Combine("../../../utils", "skills.json");
    var jsonString = File.ReadAllText(filePath);
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var skillsList = JsonSerializer.Deserialize<List<CompleteSkill>>(jsonString, options);
    if (skillsList == null) { throw new DirectoryNotFoundException(); }
    return skillsList;
  }

  private List<CompleteSkill> assignSkills(List<CompleteSkill> skillList, List<Attributes> attributes, bool cc) {
    var attributepoints = getAttributeEquivalences(attributes);
    return completeSkills(attributepoints, skillList, skillPoint, cc);
  }
  private List<CompleteSkill> completeSkills(Dictionary<string, int> attributepoints, List<CompleteSkill> skillList, int points, bool cc) {
    var random = new Random();
    for (var i = 0; i < skillList.Count; i++) {
      if (points < 0) { break; }
      attributepoints.TryGetValue(skillList[i].Category, out var basePoints);
      var name = skillList[i].Name;
      skillList[i].Base = skillList[i].Base > 0 ? skillList[i].Base : skillList[i].Base + basePoints;
      var assignatedValue = random.Next(0, 2);
      if (CCSkillList.Contains(name) && cc) { assignatedValue *= 2; }
      if (WeaponSkillList.Contains(name) && !cc) { assignatedValue *= 2; }
      skillList[i].Stat += assignatedValue;
      if (skillList[i].X2 == true) {
        assignatedValue *= 2;
      }
      if (MandatorySkillList.Contains(skillList[i].Name) && skillList[i].Stat < 2) {
        skillList[i].Stat += 2;
        assignatedValue += 2;
      }
      points -= assignatedValue;
    }
    if (points > 0) { return completeSkills(attributepoints, skillList, points, cc); }
    return skillList;
  }

  private Dictionary<string, int> getAttributeEquivalences(List<Attributes> attributes) {
    var attributepoints = new Dictionary<string, int>();
    foreach (var attribute in attributes) {
      attributepoints.Add(attribute.Name, attribute.Level);
    }
    return attributepoints;
  }
}
