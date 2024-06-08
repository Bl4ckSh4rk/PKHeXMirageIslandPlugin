using System;
using System.Collections.Generic;

namespace MirageIslandPlugin;

// Partially based on PKHeX's LocalizationUtil, thanks Kaphotics!
// https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/ResourceUtil.cs
// https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/Localization/LocalizationUtil.cs
public static class LocalizationUtil
{
    private const string TranslationSplitter = " = ";
    private const string LineSplitter = "\n";

    public static void SetLocalization(string currentCultureCode)
    {
        var txt = Properties.Resources.ResourceManager.GetObject($"lang_{currentCultureCode}")?.ToString();
        SetLocalization(txt == null ? [] : txt.Split(LineSplitter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
    }

    private static void SetLocalization(IReadOnlyCollection<string> lines)
    {
        if (lines.Count == 0)
            return;

        Dictionary<string, string> dict = [];
        foreach (var line in lines)
        {
            var index = line.IndexOf(TranslationSplitter, StringComparison.Ordinal);
            if (index < 0)
                continue;

            dict.Add(line[..index], line[(index + TranslationSplitter.Length)..]);
        }

        TranslationStrings.PluginName = dict[nameof(TranslationStrings.PluginName)];
        TranslationStrings.MirageIsland = dict[nameof(TranslationStrings.MirageIsland)];
        TranslationStrings.WillLetYouSeeMirageIsland = dict[nameof(TranslationStrings.WillLetYouSeeMirageIsland)];
        TranslationStrings.Seed = dict[nameof(TranslationStrings.Seed)];
        TranslationStrings.SeedExplanation = dict[nameof(TranslationStrings.SeedExplanation)];
        TranslationStrings.Save = dict[nameof(TranslationStrings.Save)];
        TranslationStrings.Box = dict[nameof(TranslationStrings.Box)];
        TranslationStrings.Party = dict[nameof(TranslationStrings.Party)];
        TranslationStrings.Slot = dict[nameof(TranslationStrings.Slot)];
    }
}
