using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace MirageIslandPlugin;

public class MirageIsland : IPlugin
{
    public string Name => TranslationStrings.PluginName;
    public int Priority => 1; // Loading order, lowest is first.
    public ISaveFileProvider SaveFileEditor { get; private set; } = null!;

    private ToolStripMenuItem? ctrl;

    public void Initialize(params object[] args)
    {
        LocalizationUtil.SetLocalization(GameInfo.CurrentLanguage);

        Console.WriteLine($"Loading {Name}...");
        SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider)!;
        LoadMenuStrip((ToolStrip?)Array.Find(args, z => z is ToolStrip));
    }

    private void LoadMenuStrip(ToolStrip? menuStrip)
    {
        AddPluginControl((ToolStripDropDownItem?)menuStrip?.Items.Find("Menu_Tools", false)[0]);
    }

    private void AddPluginControl(ToolStripDropDownItem? tools)
    {
        ctrl = new(Name)
        {
            Visible = false,
            Image = Properties.Resources.icon
        };
        ctrl.Click += new(OpenMirageIslandForm);
        _ = tools?.DropDownItems.Add(ctrl);
    }

    private void OpenMirageIslandForm(object? sender, EventArgs? e)
    {
        _ = new MirageIslandForm((SAV3)SaveFileEditor.SAV).ShowDialog();
    }

    public void NotifySaveLoaded()
    {
        if (ctrl != null)
            ctrl.Visible = SaveFileEditor.SAV is SAV3RS or SAV3E;
    }

    public bool TryLoadFile(string filePath) => false;
}
