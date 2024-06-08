using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MirageIslandPlugin;

public partial class MirageIslandForm : Form
{
    private readonly SAV3 sav;
    private readonly List<SlotCache> cache;
    private ushort seed;
    private const byte MIRAGE_ISLAND_WORK = 0x24;

    public PKM? SelectedPKM = null;

    public MirageIslandForm(SAV3 sav)
    {
        InitializeComponent();

        this.sav = sav;

        seed = sav.GetWork(MIRAGE_ISLAND_WORK);

        cache = new List<SlotCache>(sav.BoxSlotCount + (sav.HasParty ? 6 : 0));
        SlotInfoLoader.AddFromSaveFile(sav, cache);

        MirageIslandSeedBox.Value = seed;
        UpdatePKMList();
    }

    private void UpdatePKMList()
    {
        PKMList.Items.Clear();

        foreach (SlotCache entry in cache)
        {
            var entity = entry.Entity;
            if (entity.Species != 0 && (entity.PID & 0xFFFF) == seed)
            {
                _ = PKMList.Items.Add($"{GameInfo.Strings.Species[entity.Species]}{(entity.IsNicknamed ? " (" + entity.Nickname + ")" : "")} {GetSlotInfo(entry)}");
            }
        }
    }

    private static string GetSlotInfo(SlotCache entry)
    {
        return entry.Source switch
        {
            SlotInfoBox box => $"[{TranslationStrings.Box} {box.Box + 1}, {TranslationStrings.Slot} {box.Slot + 1}]",
            SlotInfoParty party => $"[{TranslationStrings.Party}, {TranslationStrings.Slot} {party.Slot}]",
            _ => ""
        };
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        sav.SetWork(MIRAGE_ISLAND_WORK, (ushort)MirageIslandSeedBox.Value);
        Close();
    }

    private void MirageIslandSeedBox_ValueChanged(object sender, EventArgs e)
    {
        seed = (ushort)MirageIslandSeedBox.Value;

        UpdatePKMList();
    }
}
