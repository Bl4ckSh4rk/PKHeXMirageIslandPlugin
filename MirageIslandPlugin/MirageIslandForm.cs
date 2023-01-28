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

    public PKM? SelectedPKM = null;

    public MirageIslandForm(SAV3 sav)
    {
        InitializeComponent();
        
        this.sav = sav;

        seed = sav.GetWork(0x24);

        cache = new List<SlotCache>(sav.BoxSlotCount + (sav.HasParty ? 6 : 0));
        SlotInfoLoader.AddFromSaveFile(sav, cache);

        MirageIslandSeedBox.Value = seed;
    }

    private void UpdatePKMList()
    {
        PKMList.Items.Clear();

        foreach(SlotCache entry in cache)
        {
            var entity = entry.Entity;
            if (entity.Species != 0 && (entity.PID & 0xFFFF) == seed)
            {
                _ = PKMList.Items.Add($"{SpeciesName.GetSpeciesName(entity.Species, 2)}{(entity.IsNicknamed ? " (" + entity.Nickname + ")" : "")} {GetSlotInfo(entry)}");
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
        sav.SetWork(0x24, (ushort)MirageIslandSeedBox.Value);
        Close();
    }

    private void MirageIslandSeedBox_ValueChanged(object sender, EventArgs e)
    {
        seed = (ushort)MirageIslandSeedBox.Value;

        UpdatePKMList();
    }
}
