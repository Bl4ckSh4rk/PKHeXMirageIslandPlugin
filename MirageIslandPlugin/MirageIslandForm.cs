﻿using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MirageIslandPlugin
{
    public partial class MirageIslandForm : Form
    {
        private readonly SAV3 sav;
        private List<PKM> party = new();
        private List<PKM> box = new();
        private string[] names = new string[0];
        private int seed;

        public PKM? SelectedPKM = null;

        public MirageIslandForm(SAV3 sav)
        {
            InitializeComponent();
            
            this.sav = sav;
            seed = sav.GetEventConst(0x24);
            MirageIslandSeedBox.Text = seed.ToString("X4");
        }

        private void SetPKMList()
        {
            GetPokemonWithMatchingPID();
            
            names = new string[party.Count + box.Count];
            int i = 0;

            foreach (PKM pkm in party)
            {
                names[i] = (SpeciesName.GetSpeciesName(pkm.Species, 2) + (pkm.IsNicknamed ? " (" + pkm.Nickname + ")" : "") + " [Party]");
                i++;
            }
            foreach (PKM pkm in box)
            {
                names[i] = (SpeciesName.GetSpeciesName(pkm.Species, 2) + (pkm.IsNicknamed ? " (" + pkm.Nickname + ")" : "") + " [Box: " + pkm.Box + ", Slot: " + pkm.Slot + "]");
                i++;
            }

            PKMList.Items.Clear();
            PKMList.Items.AddRange(names);
        }

        private void GetPokemonWithMatchingPID()
        {
            party = new List<PKM>();
            box = new List<PKM>();

            foreach (PKM pkm in sav.PartyData)
            {
                if ((pkm.PID & 0xFFFF) == seed && pkm.Species != 0)
                    party.Add(pkm);
            }
            
            foreach (PKM pkm in sav.BoxData)
            {
                if ((pkm.PID & 0xFFFF) == seed && pkm.Species != 0)
                    box.Add(pkm);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            sav.SetEventConst(0x24, (ushort)Util.GetHexValue(MirageIslandSeedBox.Text));
            Close();
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (party.Count != 0 && PKMList.SelectedIndex < party.Count)
                SelectedPKM = party[PKMList.SelectedIndex];
            else
                SelectedPKM = box[PKMList.SelectedIndex - party.Count];
        }

        private void ContextMenu_Open(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = PKMList.SelectedIndex == -1;
        }

        private void MirageIslandSeedBox_TextChanged(object sender, EventArgs e)
        {
            seed = (int)Util.GetHexValue(MirageIslandSeedBox.Text);

            SetPKMList();
        }
    }
}
