using Cpred_generator.Factories;

namespace Cpred_generator;
class Program {
  static Task Main(string[] args) {
    var factory = new EnemyFactory();
    factory.generateRandomEnemy();

    return Task.CompletedTask;
  }
}
