using Cpred_generator.Models;

namespace Cpred_generator.Factories;
internal class EnemyFactory {
  private const int maxAttribute = 6;

  private readonly CompleteSkillFactory skillFactory;

  public EnemyFactory() {
    skillFactory = new CompleteSkillFactory();
  }

  public Enemy generateEnemy(int level, string name, double danger, bool cc) {
    var attributes = GenerateAttributes(level, danger, cc);
    Enemy enemy = new Enemy(name) {
      Attributes = attributes,
      Skills = generateSkills(attributes, cc)
    };
    enemy.Health = getHP(enemy.Attributes[1].Level, enemy.Attributes[2].Level);
    return enemy;
  }

  public void generateRandomEnemy() {
    var random = new Random();
    var randomInt = random.Next(0, 4);
    var randomString = Path.GetRandomFileName().Replace(".", "");
    var randomDouble = random.NextDouble();
    var randomBoolean = random.Next(2) == 1;
    var enemy = generateEnemy(randomInt, randomString, randomDouble, randomBoolean);
    enemy.PrintAttributes();
  }


  private int getHP(int body, int will) {
    var average = (body + will) / 2;
    return 10 + 5 * average;
  }
  private List<Attributes> GenerateAttributes(int level, double danger, bool cc) {
    int[] AttributesPoints = { 35, 47, 55, 60, 65 };
    var dangerstats = (int)Math.Ceiling((15.0 * danger));
    var minPointsPerAttributes = 2;
    var remainingPoints = AttributesPoints[level] - dangerstats;
    var weaponstat = cc ? 5 : 4;
    int[] attArray = new int[10];
    attArray = getAttArray(attArray, remainingPoints, dangerstats, weaponstat);
    var Attributes = new List<Attributes> {
        new Attributes("MOVE", minPointsPerAttributes),
        new Attributes("WILL", minPointsPerAttributes),
        new Attributes("BODY", minPointsPerAttributes),
        new Attributes("REF", minPointsPerAttributes),
        new Attributes("DEX", minPointsPerAttributes),
        new Attributes("EMP", minPointsPerAttributes),
        new Attributes("INT", minPointsPerAttributes),
        new Attributes("LUCK", minPointsPerAttributes),
        new Attributes("TECH", minPointsPerAttributes),
        new Attributes("COOL", minPointsPerAttributes)
    };
    var random = new Random();
    var max = Attributes.Count();
    Stack<int> used = new Stack<int>();
    while (used.Count < 10) {
      var index = random.Next(0, max);
      if (!used.Contains(index)) {
        Attributes[index].Level = Attributes[index].Level + attArray[index];
        used.Push(index);
      }
    }
    return Attributes;
  }

  private int[] getAttArray(int[] numbers, int remainingPoints, int danger, int weaponstat) {
    var random = new Random();
    var dangersum = (int)Math.Floor((double)(danger / 4));

    for (int i = 0; i < numbers.Length; i++) {
      if (remainingPoints < 0) { return numbers; }
      int maxPossibleValue = Math.Min(4, remainingPoints);
      var assignatedValue = random.Next(0, maxPossibleValue + 1);
      numbers[i] = numbers[i] + assignatedValue;
      if (i < 2 || i == weaponstat) {
        numbers[i] += dangersum;
        assignatedValue += dangersum;
      }
      if (numbers[i] > maxAttribute) {
        var exceded = numbers[i] - maxAttribute;
        numbers[i] = maxAttribute;
        remainingPoints = remainingPoints + exceded;
      }
      remainingPoints -= assignatedValue;
    }
    if (remainingPoints > 0) { numbers = getAttArray(numbers, remainingPoints, 0, 0); }
    return numbers;
  }

  private List<Skill> generateSkills(List<Attributes> attributes, bool cc) {
    var completeSkills = skillFactory.CreateCompleteSkillsList(attributes, cc);
    List<Skill> skills = completeSkills.Select(cs => new Skill {
      Name = cs.Name,
      Level = cs.Base + cs.Stat,
    }).ToList();
    return skills;
  }
}
