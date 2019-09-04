using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace MirageIslandPlugin
{
    public class MirageIsland : IPlugin
    {
        public string Name => "Mirage Island Tool";
        public int Priority => 1; // Loading order, lowest is first.
        public ISaveFileProvider SaveFileEditor { get; private set; }
        public IPKMView PKMEditor { get; private set; }

        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            if (args == null)
                return;
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            LoadMenuStrip(menu);
        }

        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            var tools = items.Find("Menu_Tools", false)[0] as ToolStripDropDownItem;
            AddPluginControl(tools);
        }

        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name);
            tools.DropDownItems.Add(ctrl);
            ctrl.Image = Properties.Resources.icon;
            ctrl.Click += new EventHandler(OpenFeebasLocatorForm);
        }

        private MirageIslandForm mif;

        private void OpenFeebasLocatorForm(object sender, EventArgs e)
        {
            if (SaveFileEditor.SAV.Version == GameVersion.S || SaveFileEditor.SAV.Version == GameVersion.R || 
			SaveFileEditor.SAV.Version == GameVersion.RS || SaveFileEditor.SAV.Version == GameVersion.E || SaveFileEditor.SAV.Version == GameVersion.RSE)
            {
                mif = new MirageIslandForm((SAV3)SaveFileEditor.SAV);
                mif.ShowDialog();
                if (mif.SelectedPKM != null)
                    PKMEditor.PopulateFields(mif.SelectedPKM);
            }
            else
                MessageBox.Show("Mirage Island Tool is only available for Ruby, Sapphire and Emerald.", "Error");
        }

        public void NotifySaveLoaded()
        {
            Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
        }
        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }
    }
}
