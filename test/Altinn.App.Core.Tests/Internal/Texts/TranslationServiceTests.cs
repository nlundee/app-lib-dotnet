using Altinn.App.Core.Internal.App;
using Altinn.App.Core.Internal.Language;
using Altinn.App.Core.Internal.Texts;
using Altinn.App.Core.Models;
using Altinn.Platform.Storage.Interface.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace Altinn.App.Core.Tests.Internal.Texts;

public class TranslationServiceTests
{
    private readonly Mock<IAppResources> _appResourcesMock = new(MockBehavior.Strict);
    private readonly IServiceCollection _services = new ServiceCollection();

    public TranslationServiceTests(ITestOutputHelper outputHelper)
    {
        _appResourcesMock
            .Setup(appResources => appResources.GetTexts(It.IsAny<string>(), It.IsAny<string>(), LanguageConst.Nb))
            .ReturnsAsync(
                new TextResource
                {
                    Resources =
                    [
                        new TextResourceElement { Id = "text", Value = "bokmål" },
                        new TextResourceElement { Id = "text2", Value = "bokmål2" },
                    ],
                }
            );

        _appResourcesMock
            .Setup(appResources => appResources.GetTexts(It.IsAny<string>(), It.IsAny<string>(), LanguageConst.En))
            .ReturnsAsync(
                new TextResource { Resources = [new TextResourceElement { Id = "text", Value = "english" }] }
            );

        // Fallback for nn that returns null
        _appResourcesMock
            .Setup(appResources => appResources.GetTexts(It.IsAny<string>(), It.IsAny<string>(), LanguageConst.Nn))
            .ReturnsAsync((TextResource?)null);

        _services.AddSingleton(_appResourcesMock.Object);
        _services.AddSingleton<ITranslationService, TranslationService>();
        _services.AddSingleton(new AppIdentifier("ttd", "test"));
        _services.AddFakeLoggingWithXunit(outputHelper);
    }

    [Fact]
    public async Task TranslateTextKey_Returns_Nb()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateTextKey("text", LanguageConst.Nb);
        Assert.Equal("bokmål", result);
    }

    [Fact]
    public async Task TranslateTextKey_Returns_En()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateTextKey("text", LanguageConst.En);
        Assert.Equal("english", result);
    }

    [Fact]
    public async Task TranslateTextKey_Default_Nb()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateTextKey("text", null);
        Assert.Equal("bokmål", result);
    }

    [Fact]
    public async Task TranslateTextKey_Fallback_Nb()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateTextKey("text", LanguageConst.Nn);
        Assert.Equal("bokmål", result);
    }

    [Fact]
    public async Task TranslateTextKey_Fail_Missing()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateTextKey("missing", "nb");
        Assert.Null(result);
    }

    [Fact]
    public async Task TranslateTextKeyLenient_Returns_Null_If_Key_Is_Null()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateTextKeyLenient(null, LanguageConst.Nb);
        Assert.Null(result);
    }

    [Fact]
    public async Task TranslateFirstMatchingTextKey_Returns_First_Match()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateFirstMatchingTextKey(
            LanguageConst.Nb,
            "missing",
            "text2",
            "text"
        );
        Assert.Equal("bokmål2", result);
    }

    [Fact]
    public async Task TranslateFirstMatchingTextKey_Returns_Null_If_No_Match()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateFirstMatchingTextKey(
            LanguageConst.Nb,
            "missing",
            "missing2",
            "missing3"
        );
        Assert.Null(result);
    }

    [Fact]
    public async Task TranslateFirstMatchingTextKey_Default_Nb()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateFirstMatchingTextKey(null, "text");
        Assert.Equal("bokmål", result);
    }

    [Fact]
    public async Task TranslateFirstMatchingTextKey_Fallback_Nb()
    {
        await using var provider = _services.BuildServiceProvider();
        var translationService = provider.GetRequiredService<ITranslationService>();
        var result = await translationService.TranslateFirstMatchingTextKey(LanguageConst.Nn, "text");
        Assert.Equal("bokmål", result);
    }
}
