namespace Cpred_generator.Models;
public class Dice {
  private readonly int count;
  private readonly int sides;

  public Dice(int count, int sides) {
    this.count = count;
    this.sides = sides;
  }

  public int Roll() {
    var total = 0;
    var random = new Random();

    for (var i = 0; i < count; i++) {
      total += random.Next(1, sides + 1);
    }

    return total;
  }
}
