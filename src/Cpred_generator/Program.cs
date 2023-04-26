using Cpred_generator.Providers;

namespace Cpred_generator;
class Program {
  static async Task Main(string[] args) {
    // Inicializar proveedor de GPT-3
    var apiKey = "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";
    var engine = "davinci";
    var gptProvider = new GPTProvider(apiKey, engine);

    // Solicitar prompt al usuario
    Console.WriteLine("Ingresa tu prompt:");
    var prompt = Console.ReadLine();

    // Generar texto con el proveedor de GPT-3
    var response = await gptProvider.GetTextAsync(prompt);

    // Mostrar texto generado
    Console.WriteLine(response);
  }
}
