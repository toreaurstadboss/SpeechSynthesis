## Azure AI Speech Synthesis DEMO

You can create a TTS - Text To Speech service using Azure AI service for this. This Speech service in this demo uses the library Nuget `Microsoft.CognitiveServices.Speech`.

This repo contains a simple demo using Azure AI Speech synthesis using Azure.CognitiveServices.SpeechSynthesis.
It provides a simple way of synthesizing text to speech using Azure AI services.

The code provides a simple builder for creating a SpeechSynthesizer instance.

```csharp
using Microsoft.CognitiveServices.Speech;

namespace ToreAurstadIT.AzureAIDemo.SpeechSynthesis;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Your text to speech input");
        string? text = Console.ReadLine();

        using (var synthesizer = SpeechSynthesizerBuilder.Instance.WithSubscription().Build())
        {
            using (var result = await synthesizer.SpeakTextAsync(text))
            {
                string reasonResult = result.Reason switch
                {
                    ResultReason.SynthesizingAudioCompleted => $"The following text succeeded successfully: {text}",
                    _ => $"Result of speeech synthesis: {result.Reason}"
                };
                Console.WriteLine(reasonResult);
            }
        }

    }

}

```
