using System;
using PKHeX.Core;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MirageIslandPlugin
{
    public partial class MirageIslandForm : Form
    {
        private SAV3 sav;
        private List<PKM> party;
        private List<PKM> box;
        private string[] names;
        private int offset;
        private int seed;

        public PKM SelectedPKM;

        public MirageIslandForm(SAV3 sav)
        {
            InitializeComponent();

            if (sav.RS)
                offset = sav.GetBlockOffset(2) + 0x408;
            if (sav.E)
                offset = sav.GetBlockOffset(2) + 0x464;
            
            this.sav = sav;

            seed = BitConverter.ToUInt16(sav.Data, offset);

            MirageIslandSeedBox.Text = seed.ToString("X4");
        }

        private void SetPKMList()
        {
            GetPokemonWithMatchingPID();
            
            names = new string[party.Count + box.Count];
            int i = 0;

            foreach (PKM pkm in party)
            {
                names[i] = (PKX.GetSpeciesName(pkm.Species, 2) + (pkm.IsNicknamed ? " (" + pkm.Nickname + ")" : "") + " [Party]");
                i++;
            }
            foreach (PKM pkm in box)
            {
                names[i] = (PKX.GetSpeciesName(pkm.Species, 2) + (pkm.IsNicknamed ? " (" + pkm.Nickname + ")" : "") + " [Box: " + pkm.Box + ", Slot: " + pkm.Slot + "]");
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
            sav.SetData(BitConverter.GetBytes(Util.GetHexValue(MirageIslandSeedBox.Text)), offset);
            Close();
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedPKM = box[PKMList.SelectedIndex];
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
