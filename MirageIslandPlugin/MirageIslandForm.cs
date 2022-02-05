using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MirageIslandPlugin
{
    public partial class MirageIslandForm : Form
    {
        private readonly SAV3 sav;
        private readonly List<SlotCache> cache;
        private int seed;

        public PKM? SelectedPKM = null;

        public MirageIslandForm(SAV3 sav)
        {
            InitializeComponent();
            
            this.sav = sav;

            seed = sav.GetEventConst(0x24);

            cache = new List<SlotCache>(sav.BoxSlotCount + (sav.HasParty ? 6 : 0));
            SlotInfoLoader.AddFromSaveFile(sav, cache);

            MirageIslandSeedBox.Text = seed.ToString("X4");
        }

        private void SetPKMList()
        {
            PKMList.Items.Clear();

            foreach(SlotCache entry in cache)
            {
                var entity = entry.Entity;
                if ((entity.PID & 0xFFFF) == seed)
                    _ = PKMList.Items.Add($"{SpeciesName.GetSpeciesName(entity.Species, 2)}{(entity.IsNicknamed ? " (" + entity.Nickname + ")" : "")} {GetSlotInfo(entry)}");
            }
        }

        private string GetSlotInfo(SlotCache entry)
        {
            return entry.Source switch
            {
                SlotInfoBox box => $"[Box {box.Box + 1}, Slot {box.Slot + 1}]",
                SlotInfoParty party => $"[Party, Slot: {party.Slot}]",
                _ => ""
            };
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            sav.SetEventConst(0x24, (ushort)Util.GetHexValue(MirageIslandSeedBox.Text));
            Close();
        }

        private void MirageIslandSeedBox_TextChanged(object sender, EventArgs e)
        {
            seed = (int)Util.GetHexValue(MirageIslandSeedBox.Text);

            SetPKMList();
        }
    }
}
