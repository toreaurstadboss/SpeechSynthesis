﻿using Microsoft.CognitiveServices.Speech;

namespace ToreAurstadIT.AzureAIDemo.SpeechSynthesis;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Your text to speech input");
        string? intialPause = "     ....     "; //this is added to avoid the text being cut in the start
        string? text = Console.ReadLine();

        using (var synthesizer = SpeechSynthesizerBuilder.Instance.WithSubscription().Build())
        {
            using (var result = await synthesizer.SpeakTextAsync(intialPause + text))
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


