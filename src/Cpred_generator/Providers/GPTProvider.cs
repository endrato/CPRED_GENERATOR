using OpenAI.API;

namespace Cpred_generator.Providers;

public class GPTProvider {
  private readonly OpenAIAPI client;
  private readonly string engine;
  private const double temperature = 0.1;

  public GPTProvider(string apiKey, string engine) {
    client = new OpenAIAPI(apiKey);
    this.engine = engine;
  }

  public async Task<string> GetTextAsync(string prompt) {
    var response = await client.Completions.CreateCompletionAsync(
      model: engine,
      prompt: prompt,
      temperature: temperature
    );
    return response.ToString();
    throw new System.Exception("Failed to complete text.");
  }
}
