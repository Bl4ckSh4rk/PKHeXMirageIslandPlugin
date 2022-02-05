using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace MirageIslandPlugin
{
    public class MirageIsland : IPlugin
    {
        public string Name => "Mirage Island Tool";
        public int Priority => 1; // Loading order, lowest is first.
        public ISaveFileProvider SaveFileEditor { get; private set; } = null!;
        public IPKMView PKMEditor { get; private set; } = null!;

        private ToolStripMenuItem? ctrl;

        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            if (args == null)
                return;
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider)!;
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView)!;
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            LoadMenuStrip(menu);
        }

        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            var tools = (ToolStripDropDownItem)items.Find("Menu_Tools", false)[0];
            AddPluginControl(tools);
        }

        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            ctrl = new ToolStripMenuItem(Name);
            tools.DropDownItems.Add(ctrl);
            ctrl.Image = Properties.Resources.icon;
            ctrl.Click += new EventHandler(OpenFeebasLocatorForm);
            ctrl.Enabled = false;
        }

        private MirageIslandForm? mif;

        private void OpenFeebasLocatorForm(object sender, EventArgs e)
        {
            mif = new MirageIslandForm((SAV3)SaveFileEditor.SAV);
            mif.ShowDialog();
            if (mif.SelectedPKM != null)
                PKMEditor.PopulateFields(mif.SelectedPKM);
        }

        public void NotifySaveLoaded()
        {
            if (ctrl != null)
                ctrl.Enabled = SaveFileEditor.SAV is SAV3RS or SAV3E;
        }
        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }
    }
}
