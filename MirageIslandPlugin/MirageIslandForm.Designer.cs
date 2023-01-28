namespace MirageIslandPlugin;

partial class MirageIslandForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.LocationLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PKMList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MirageIslandSeedBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MirageIslandSeedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(10, 10);
            this.LocationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(0, 15);
            this.LocationLabel.TabIndex = 3;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(270, 185);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(70, 30);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = TranslationStrings.Save;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = TranslationStrings.MirageIsland;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 186);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = TranslationStrings.Seed;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PKMList);
            this.groupBox1.Location = new System.Drawing.Point(14, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(322, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = TranslationStrings.WillLetYouSeeMirageIsland;
            // 
            // PKMList
            // 
            this.PKMList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PKMList.FormattingEnabled = true;
            this.PKMList.ItemHeight = 15;
            this.PKMList.Location = new System.Drawing.Point(8, 23);
            this.PKMList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PKMList.Name = "PKMList";
            this.PKMList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.PKMList.Size = new System.Drawing.Size(306, 94);
            this.PKMList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(132, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = TranslationStrings.SeedExplanation;
            // 
            // MirageIslandSeedBox
            // 
            this.MirageIslandSeedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MirageIslandSeedBox.Hexadecimal = true;
            this.MirageIslandSeedBox.Location = new System.Drawing.Point(55, 183);
            this.MirageIslandSeedBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MirageIslandSeedBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MirageIslandSeedBox.Name = "MirageIslandSeedBox";
            this.MirageIslandSeedBox.Size = new System.Drawing.Size(70, 23);
            this.MirageIslandSeedBox.TabIndex = 2;
            this.MirageIslandSeedBox.ValueChanged += new System.EventHandler(this.MirageIslandSeedBox_ValueChanged);
            // 
            // MirageIslandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 228);
            this.Controls.Add(this.MirageIslandSeedBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LocationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(522, 859);
            this.MinimumSize = new System.Drawing.Size(366, 267);
            this.Name = "MirageIslandForm";
            this.ShowIcon = false;
            this.Text =TranslationStrings.PluginName;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MirageIslandSeedBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LocationLabel;
    private System.Windows.Forms.Button SaveButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ListBox PKMList;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown MirageIslandSeedBox;
}