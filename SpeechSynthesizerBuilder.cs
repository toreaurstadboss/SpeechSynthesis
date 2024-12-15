using Microsoft.CognitiveServices.Speech;

namespace ToreAurstadIT.AzureAIDemo.SpeechSynthesis;

public class SpeechSynthesizerBuilder
{

    private string? _subscriptionKey = null;
    private string? _subscriptionRegion = null;

    public static SpeechSynthesizerBuilder Instance => new SpeechSynthesizerBuilder();

    public SpeechSynthesizerBuilder WithSubscription(string? subscriptionKey = null, string? region = null)
    {
        _subscriptionKey = subscriptionKey ?? Environment.GetEnvironmentVariable("AZURE_AI_SERVICES_SPEECH_KEY", EnvironmentVariableTarget.User);
        _subscriptionRegion = region ?? Environment.GetEnvironmentVariable("AZURE_AI_SERVICES_SPEECH_REGION", EnvironmentVariableTarget.User);
        return this;
    }

    public SpeechSynthesizer Build()
    {
        var config = SpeechConfig.FromSubscription(_subscriptionKey, _subscriptionRegion);
        var speechSynthesizer = new SpeechSynthesizer(config);
        return speechSynthesizer;
    }




}