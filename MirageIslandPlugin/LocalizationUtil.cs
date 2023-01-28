using PKHeX.Core;
using System;
using System.Collections.Generic;

namespace MirageIslandPlugin;

// Partially based on PKHeX's LocalizationUtil, thanks Kaphotics!
// https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/ResourceUtil.cs
// https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/Localization/LocalizationUtil.cs
public static class LocalizationUtil
{
    private const string TranslationSplitter = " = ";
    private const string StringCachePrefix = nameof(MirageIslandPlugin); // to distinguish from cashed PKHeX resources

    public static void SetLocalization(string currentCultureCode)
    {
        SetLocalization(GetStringList($"lang_{currentCultureCode}"));
    }

    private static string[] GetStringList(string fileName)
    {
        if (Util.IsStringListCached($"{StringCachePrefix}_{fileName}", out var result))
            return result;
        var txt = Properties.Resources.ResourceManager.GetObject(fileName)?.ToString();
        return Util.LoadStringList($"{StringCachePrefix}_{fileName}", txt);
    }

    private static void SetLocalization(IReadOnlyCollection<string> lines)
    {
        if (lines.Count == 0)
            return;
        foreach (var line in lines)
        {
            var index = line.IndexOf(TranslationSplitter, StringComparison.Ordinal);
            if (index < 0)
                continue;
            var prop = line[..index];
            var value = line[(index + TranslationSplitter.Length)..];

            switch (prop)
            {
                case nameof(TranslationStrings.PluginName):
                    TranslationStrings.PluginName = value;
                    break;
                case nameof(TranslationStrings.MirageIsland):
                    TranslationStrings.MirageIsland = value;
                    break;
                case nameof(TranslationStrings.WillLetYouSeeMirageIsland):
                    TranslationStrings.WillLetYouSeeMirageIsland = value;
                    break;
                case nameof(TranslationStrings.Seed):
                    TranslationStrings.Seed = value;
                    break;
                case nameof(TranslationStrings.SeedExplanation):
                    TranslationStrings.SeedExplanation = value;
                    break;
                case nameof(TranslationStrings.Save):
                    TranslationStrings.Save = value;
                    break;
                case nameof(TranslationStrings.Box):
                    TranslationStrings.Box = value;
                    break;
                case nameof(TranslationStrings.Party):
                    TranslationStrings.Party = value;
                    break;
                case nameof(TranslationStrings.Slot):
                    TranslationStrings.Slot = value;
                    break;
            }
        }
    }
}
