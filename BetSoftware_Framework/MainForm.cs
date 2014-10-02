//  MainForm.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Main form.
/// </summary>
namespace BetSoftware_Framework
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Security.Policy;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.XPath;

    /// <summary>
    /// Main form class.
    /// </summary>
    public class MainForm : Form
    {
        /* Class variables */

        /// <summary>
        /// Holds items across SelectedIndexChanged calls.
        /// </summary>
        private Dictionary<string, List<string>> lbsic = new Dictionary<string, List<string>>();

        /// <summary>
        /// BetMarshal list.
        /// </summary>
        private List<BetMarshal> marshals = new List<BetMarshal>();

        /// <summary>
        /// Base directories.
        /// </summary>
        private List<string> baseDirs = new List<string>() { "Utilities", "Input", "BetSelection", "MoneyManagement", "Display", "Output" };

        /// <summary>
        /// Game subdirectories.
        /// </summary>
        private List<string> gameDirs = new List<string>() { "Roulette", "Baccarat", "Multigame" };

        /// <summary>
        /// Module directory.
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> moduleDir = new Dictionary<string, Dictionary<string, string>>();

        /* Main form GUI */

        /// <summary>
        /// The launch button.
        /// </summary>
        private Button launchButton;

        /// <summary>
        /// The launcher label.
        /// </summary>
        private Label launcherLabel;

        /// <summary>
        /// The web label.
        /// </summary>
        private Label webLabel;

        /// <summary>
        /// The web link label.
        /// </summary>
        private LinkLabel webLinkLabel;

        /// <summary>
        /// The bet selection listbox.
        /// </summary>
        private ListBox betSelectionListBox;

        /// <summary>
        /// The display listbox.
        /// </summary>
        private ListBox displayListBox;

        /// <summary>
        /// The input listbox.
        /// </summary>
        private ListBox inputListBox;

        /// <summary>
        /// The money management listbox.
        /// </summary>
        private ListBox moneyManagementListBox;

        /// <summary>
        /// The output listbox.
        /// </summary>
        private ListBox outputListBox;

        /// <summary>
        /// The utilities listbox.
        /// </summary>
        private ListBox utilitiesListBox;

        /// <summary>
        /// The menu strip
        /// </summary>
        private MenuStrip mainMenuStrip;

        /// <summary>
        /// The status strip.
        /// </summary>
        private StatusStrip mainStatusStrip;

        /// <summary>
        /// The main tab control.
        /// </summary>
        private TabControl mainTabControl;

        /// <summary>
        /// The bet selection tab page.
        /// </summary>
        private TabPage betSelectionTabPage;

        /// <summary>
        /// The display tab page.
        /// </summary>
        private TabPage displayTabPage;

        /// <summary>
        /// The input tab page.
        /// </summary>
        private TabPage inputTabPage;

        /// <summary>
        /// The money management tab page.
        /// </summary>
        private TabPage moneyManagementTabPage;

        /// <summary>
        /// The output tab page.
        /// </summary>
        private TabPage outputTabPage;

        /// <summary>
        /// The utilities tab page.
        /// </summary>
        private TabPage utilitiesTabPage;

        /// <summary>
        /// The about tool strip menu item.
        /// </summary>
        private ToolStripMenuItem aboutToolStripMenuItem;

        /// <summary>
        /// The always ontop tool strip menu item.
        /// </summary>
        private ToolStripMenuItem alwaysOntopToolStripMenuItem;

        /// <summary>
        /// The ask on exit tool strip menu item.
        /// </summary>
        private ToolStripMenuItem askOnExitToolStripMenuItem;

        /// <summary>
        /// The exit tool strip menu item.
        /// </summary>
        private ToolStripMenuItem exitToolStripMenuItem;

        /// <summary>
        /// The file tool strip menu item.
        /// </summary>
        private ToolStripMenuItem fileToolStripMenuItem;

        /// <summary>
        /// The help tool strip menu item.
        /// </summary>
        private ToolStripMenuItem helpToolStripMenuItem;

        /// <summary>
        /// The options tool strip menu item.
        /// </summary>
        private ToolStripMenuItem optionsToolStripMenuItem;

        /// <summary>
        /// The reset settings tool strip menu item.
        /// </summary>
        private ToolStripMenuItem resetSettingsToolStripMenuItem;

        /// <summary>
        /// The save position tool strip menu item.
        /// </summary>
        private ToolStripMenuItem savePositionToolStripMenuItem;

        /// <summary>
        /// The save size tool strip menu item.
        /// </summary>
        private ToolStripMenuItem saveSizeToolStripMenuItem;

        /// <summary>
        /// The undo steps tool strip menu item.
        /// </summary>
        private ToolStripMenuItem undoStepsToolStripMenuItem;

        /// <summary>
        /// The status tool strip status label.
        /// </summary>
        private ToolStripStatusLabel statusToolStripStatusLabel;

        /// <summary>
        /// The launch tree view.
        /// </summary>
        private TreeView launchTreeView;

        /// <summary>
        /// Initializes a new instance of the <see cref="BetSoftware_Framework.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            TreeNode treeNode1 = new TreeNode("Utilities");
            TreeNode treeNode2 = new TreeNode("Input");
            TreeNode treeNode3 = new TreeNode("Bet Selection");
            TreeNode treeNode4 = new TreeNode("Money Management");
            TreeNode treeNode5 = new TreeNode("Display");
            TreeNode treeNode6 = new TreeNode("Output");
            this.mainMenuStrip = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.optionsToolStripMenuItem = new ToolStripMenuItem();
            this.undoStepsToolStripMenuItem = new ToolStripMenuItem();
            this.alwaysOntopToolStripMenuItem = new ToolStripMenuItem();
            this.askOnExitToolStripMenuItem = new ToolStripMenuItem();
            this.saveSizeToolStripMenuItem = new ToolStripMenuItem();
            this.savePositionToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.resetSettingsToolStripMenuItem = new ToolStripMenuItem();
            this.webLinkLabel = new LinkLabel();
            this.launchTreeView = new TreeView();
            this.webLabel = new Label();
            this.launcherLabel = new Label();
            this.launchButton = new Button();
            this.mainTabControl = new TabControl();
            this.utilitiesTabPage = new TabPage();
            this.utilitiesListBox = new ListBox();
            this.inputTabPage = new TabPage();
            this.inputListBox = new ListBox();
            this.betSelectionTabPage = new TabPage();
            this.betSelectionListBox = new ListBox();
            this.moneyManagementTabPage = new TabPage();
            this.moneyManagementListBox = new ListBox();
            this.displayTabPage = new TabPage();
            this.displayListBox = new ListBox();
            this.outputTabPage = new TabPage();
            this.outputListBox = new ListBox();
            this.mainStatusStrip = new StatusStrip();
            this.statusToolStripStatusLabel = new ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.utilitiesTabPage.SuspendLayout();
            this.inputTabPage.SuspendLayout();
            this.betSelectionTabPage.SuspendLayout();
            this.moneyManagementTabPage.SuspendLayout();
            this.displayTabPage.SuspendLayout();
            this.outputTabPage.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();

            // mainMenuStrip
            this.mainMenuStrip.Items.AddRange(new ToolStripItem[]
                {
                    this.fileToolStripMenuItem,
                    this.optionsToolStripMenuItem,
                    this.helpToolStripMenuItem
                });
            this.mainMenuStrip.Location = new Point(0, 0);
            this.mainMenuStrip.Name = "ms";
            this.mainMenuStrip.Size = new Size(551, 24);
            this.mainMenuStrip.TabIndex = 21;
            this.mainMenuStrip.Text = "menuStrip1";

            // fileToolStripMenuItem
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                {
                    this.exitToolStripMenuItem
                });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";

            // exitToolStripMenuItem
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            /* this.exitToolStripMenuItem.Image = Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("close")); */
            this.exitToolStripMenuItem.Click += new EventHandler(this.ExitToolStripMenuItem_Click);

            // undoStepsToolStripMenuItem
            this.undoStepsToolStripMenuItem.Name = "undoStepsToolStripMenuItem";
            this.undoStepsToolStripMenuItem.Size = new Size(193, 22);
            this.undoStepsToolStripMenuItem.Text = "Set &undo steps (10)";

            // alwaysOntopToolStripMenuItem
            this.alwaysOntopToolStripMenuItem.Checked = true;
            this.alwaysOntopToolStripMenuItem.Name = "alwaysOntopToolStripMenuItem";
            this.alwaysOntopToolStripMenuItem.Size = new Size(193, 22);
            this.alwaysOntopToolStripMenuItem.Text = "Always on &top";
            this.alwaysOntopToolStripMenuItem.Click += new EventHandler(this.AlwaysOntopToolStripMenuItem_Click);

            // askOnExitToolStripMenuItem
            this.askOnExitToolStripMenuItem.Checked = true;
            this.askOnExitToolStripMenuItem.Name = "askOnExitToolStripMenuItem";
            this.askOnExitToolStripMenuItem.Size = new Size(152, 22);
            this.askOnExitToolStripMenuItem.Text = "&Ask on exit";
            this.askOnExitToolStripMenuItem.Click += new EventHandler(this.ToolStripMenuItem_Click);

            // saveSizeToolStripMenuItem
            this.saveSizeToolStripMenuItem.Checked = true;
            this.saveSizeToolStripMenuItem.CheckState = CheckState.Checked;
            this.saveSizeToolStripMenuItem.Name = "saveSizeToolStripMenuItem";
            this.saveSizeToolStripMenuItem.Size = new Size(193, 22);
            this.saveSizeToolStripMenuItem.Text = "Save modules size";
            this.saveSizeToolStripMenuItem.Click += new EventHandler(this.ToolStripMenuItem_Click);

            // savePositionToolStripMenuItem
            this.savePositionToolStripMenuItem.Checked = true;
            this.savePositionToolStripMenuItem.Name = "savePositionToolStripMenuItem";
            this.savePositionToolStripMenuItem.Size = new Size(193, 22);
            this.savePositionToolStripMenuItem.Text = "Save modules &position";
            this.savePositionToolStripMenuItem.Click += new EventHandler(this.ToolStripMenuItem_Click);

            // resetSettingsToolStripMenuItem
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.resetSettingsToolStripMenuItem.Text = "Reset settings";
            /* this.resetSettingsToolStripMenuItem.Image = Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("reload")); */
            /* TODO this.resetSettingsToolStripMenuItem.Click += new System.EventHandler(this.ResetSettingsToolStripMenuItem_Click); */

            // optionsToolStripMenuItem
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                {
                    // this.undoStepsToolStripMenuItem,
                    // this.saveSizeToolStripMenuItem,
                    // this.resetSettingsToolStripMenuItem,
                    this.alwaysOntopToolStripMenuItem,
                    this.askOnExitToolStripMenuItem,
                    this.savePositionToolStripMenuItem
                });
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
                {
                    this.aboutToolStripMenuItem
                });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";

            // aboutToolStripMenuItem
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            /* this.aboutToolStripMenuItem.Image = Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("info")); */
            this.aboutToolStripMenuItem.Click += new EventHandler(this.AboutToolStripMenuItem_Click);

            // webLinkLabel
            this.webLinkLabel.Location = new Point(217, 196);
            this.webLinkLabel.Name = "llWeb";
            this.webLinkLabel.Size = new Size(135, 13);
            this.webLinkLabel.TabIndex = 37;
            this.webLinkLabel.TabStop = true;
            this.webLinkLabel.Text = "www.BetSelection.cc";
            this.webLinkLabel.Visible = true;
            this.webLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.WebLinkLabel_LinkClicked);

            // launchTreeView
            this.launchTreeView.Enabled = false;
            this.launchTreeView.HideSelection = false;
            this.launchTreeView.Sorted = false;
            this.launchTreeView.Location = new Point(9, 212);
            this.launchTreeView.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.launchTreeView.Name = "launchTreeView";
            treeNode1.Name = "tnUtilities";
            treeNode1.Text = "Utilities";
            treeNode2.Name = "tnInput";
            treeNode2.Text = "Input";
            treeNode3.Name = "tnBetSelection";
            treeNode3.Text = "Bet Selection";
            treeNode4.Name = "tnMoneyManagement";
            treeNode4.Text = "Money Management";
            treeNode5.Name = "tnDisplay";
            treeNode5.Text = "Display";
            treeNode6.Name = "tnOutput";
            treeNode6.Text = "Output";
            this.launchTreeView.Nodes.AddRange(new TreeNode[]
                {
                    treeNode1,
                    treeNode2,
                    treeNode3,
                    treeNode4,
                    treeNode5,
                    treeNode6
                });
            this.launchTreeView.Size = new Size(328, 122);
            this.launchTreeView.TabIndex = 34;
            this.launchTreeView.Visible = true;

            // webLabel
            this.webLabel.AutoSize = true;
            this.webLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.webLabel.Location = new Point(186, 197);
            this.webLabel.Name = "lWeb";
            this.webLabel.Size = new Size(33, 13);
            this.webLabel.TabIndex = 35;
            this.webLabel.Text = "Web:";
            this.webLabel.Visible = true;

            // launcherLabel
            this.launcherLabel.AutoSize = true;
            this.launcherLabel.Enabled = false;
            this.launcherLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.launcherLabel.Location = new Point(6, 196);
            this.launcherLabel.Name = "lLauncher";
            this.launcherLabel.Size = new Size(64, 13);
            this.launcherLabel.TabIndex = 36;
            this.launcherLabel.Text = "Launcher:";
            this.launcherLabel.Visible = true;

            // launchButton
            this.launchButton.Enabled = false;
            this.launchButton.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.launchButton.ForeColor = Color.Red;
            this.launchButton.Location = new Point(9, 337);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new Size(328, 30);
            this.launchButton.TabIndex = 31;
            this.launchButton.Text = "Launch!";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Visible = true;
            this.launchButton.Click += new System.EventHandler(this.LaunchButton_Click);

            // mainTabControl
            this.mainTabControl.Controls.Add(this.utilitiesTabPage);
            this.mainTabControl.Controls.Add(this.inputTabPage);
            this.mainTabControl.Controls.Add(this.betSelectionTabPage);
            this.mainTabControl.Controls.Add(this.moneyManagementTabPage);
            this.mainTabControl.Controls.Add(this.displayTabPage);
            this.mainTabControl.Controls.Add(this.outputTabPage);
            this.mainTabControl.Location = new Point(6, 28);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new Size(335, 157);
            this.mainTabControl.TabIndex = 29;
            this.mainTabControl.Visible = true;

            // utilitiesTabPage
            this.utilitiesTabPage.Controls.Add(this.utilitiesListBox);
            this.utilitiesTabPage.Location = new Point(4, 22);
            this.utilitiesTabPage.Name = "utilitiesTabPage";
            this.utilitiesTabPage.Size = new Size(327, 147);
            this.utilitiesTabPage.TabIndex = 6;
            this.utilitiesTabPage.Text = "Utilities";
            this.utilitiesTabPage.UseVisualStyleBackColor = true;

            // utilitiesListBox
            this.utilitiesListBox.FormattingEnabled = true;
            this.utilitiesListBox.Location = new Point(8, 12);
            this.utilitiesListBox.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.utilitiesListBox.Name = "utilitiesListBox";
            this.utilitiesListBox.Tag = "tnUtilities";
            this.utilitiesListBox.SelectionMode = SelectionMode.MultiSimple;
            this.utilitiesListBox.Size = new Size(311, 122);
            this.utilitiesListBox.Sorted = true;
            this.utilitiesListBox.TabIndex = 9;
            this.utilitiesListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);

            // inputTabPage
            this.inputTabPage.Controls.Add(this.inputListBox);
            this.inputTabPage.Location = new Point(4, 22);
            this.inputTabPage.Name = "inputTabPage";
            this.inputTabPage.Padding = new Padding(3);
            this.inputTabPage.Size = new Size(327, 147);
            this.inputTabPage.TabIndex = 0;
            this.inputTabPage.Text = "Input";
            this.inputTabPage.UseVisualStyleBackColor = true;

            // inputListBox
            this.inputListBox.FormattingEnabled = true;
            this.inputListBox.Location = new Point(8, 12);
            this.inputListBox.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.inputListBox.Name = "inputListBox";
            this.inputListBox.SelectionMode = SelectionMode.MultiSimple;
            this.inputListBox.Size = new Size(311, 122);
            this.inputListBox.Sorted = true;
            this.inputListBox.TabIndex = 6;
            this.inputListBox.Tag = "tnInput";
            this.inputListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);

            // betSelectionTabPage
            this.betSelectionTabPage.Controls.Add(this.betSelectionListBox);
            this.betSelectionTabPage.Location = new Point(4, 22);
            this.betSelectionTabPage.Name = "betSelectionTabPage";
            this.betSelectionTabPage.Padding = new Padding(3);
            this.betSelectionTabPage.Size = new Size(327, 147);
            this.betSelectionTabPage.TabIndex = 1;
            this.betSelectionTabPage.Text = "Bet S.";
            this.betSelectionTabPage.UseVisualStyleBackColor = true;

            // betSelectionListBox
            this.betSelectionListBox.FormattingEnabled = true;
            this.betSelectionListBox.Location = new Point(8, 12);
            this.betSelectionListBox.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.betSelectionListBox.Name = "betSelectionListBox";
            this.betSelectionListBox.Tag = "tnBetSelection";
            this.betSelectionListBox.SelectionMode = SelectionMode.MultiSimple;
            this.betSelectionListBox.Size = new Size(311, 122);
            this.betSelectionListBox.Sorted = true;
            this.betSelectionListBox.TabIndex = 4;
            this.betSelectionListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);

            // moneyManagementTabPage
            this.moneyManagementTabPage.Controls.Add(this.moneyManagementListBox);
            this.moneyManagementTabPage.Location = new Point(4, 22);
            this.moneyManagementTabPage.Name = "moneyManagementTabPage";
            this.moneyManagementTabPage.Padding = new Padding(3);
            this.moneyManagementTabPage.Size = new Size(327, 147);
            this.moneyManagementTabPage.TabIndex = 2;
            this.moneyManagementTabPage.Text = "Mon. M.";
            this.moneyManagementTabPage.UseVisualStyleBackColor = true;

            // moneyManagementListBox
            this.moneyManagementListBox.FormattingEnabled = true;
            this.moneyManagementListBox.Location = new Point(8, 12);
            this.moneyManagementListBox.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.moneyManagementListBox.Name = "moneyManagementListBox";
            this.moneyManagementListBox.Tag = "tnMoneyManagement";
            this.moneyManagementListBox.SelectionMode = SelectionMode.MultiSimple;
            this.moneyManagementListBox.Size = new Size(311, 122);
            this.moneyManagementListBox.Sorted = true;
            this.moneyManagementListBox.TabIndex = 6;
            this.moneyManagementListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);

            // displayTabPage
            this.displayTabPage.Controls.Add(this.displayListBox);
            this.displayTabPage.Location = new Point(4, 22);
            this.displayTabPage.Name = "displayTabPage";
            this.displayTabPage.Size = new Size(327, 147);
            this.displayTabPage.TabIndex = 3;
            this.displayTabPage.Text = "Display";
            this.displayTabPage.UseVisualStyleBackColor = true;

            // displayListBox
            this.displayListBox.FormattingEnabled = true;
            this.displayListBox.Location = new Point(8, 12);
            this.displayListBox.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.displayListBox.Name = "displayListBox";
            this.displayListBox.Tag = "tnDisplay";
            this.displayListBox.SelectionMode = SelectionMode.MultiSimple;
            this.displayListBox.Size = new Size(311, 122);
            this.displayListBox.Sorted = true;
            this.displayListBox.TabIndex = 6;
            this.displayListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);

            // outputTabPage
            this.outputTabPage.Controls.Add(this.outputListBox);
            this.outputTabPage.Location = new Point(4, 22);
            this.outputTabPage.Name = "outputTabPage";
            this.outputTabPage.Size = new Size(327, 147);
            this.outputTabPage.TabIndex = 5;
            this.outputTabPage.Text = "Output";
            this.outputTabPage.UseVisualStyleBackColor = true;

            // outputListBox
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.Location = new Point(8, 12);
            this.outputListBox.Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Bold);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Tag = "tnOutput";
            this.outputListBox.SelectionMode = SelectionMode.MultiSimple;
            this.outputListBox.Size = new Size(311, 122);
            this.outputListBox.Sorted = true;
            this.outputListBox.TabIndex = 6;
            this.outputListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);

            // mainStatusStrip
            this.mainStatusStrip.Items.AddRange(new ToolStripItem[]
                {
                    this.statusToolStripStatusLabel
                });
            this.mainStatusStrip.Location = new Point(0, 425);
            this.mainStatusStrip.Name = "ss";
            this.mainStatusStrip.Size = new Size(551, 22);
            this.mainStatusStrip.TabIndex = 26;

            // statusToolStripStatusLabel
            this.statusToolStripStatusLabel.Font = new Font("Segoe UI", 9F, (FontStyle)(FontStyle.Bold | FontStyle.Italic), GraphicsUnit.Point, (byte)0);
            this.statusToolStripStatusLabel.ForeColor = Color.Blue;
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new Size(95, 17);
            this.statusToolStripStatusLabel.Text = Data.StepOne;

            // MainForm
            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoSize = Environment.OSVersion.Platform == PlatformID.Unix; // Mono runtime AutoSize fix
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new Size(354, 395);
            this.StartPosition = FormStartPosition.Manual;
            this.MaximizeBox = false;
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.webLinkLabel);
            this.Controls.Add(this.launchTreeView);
            this.Controls.Add(this.webLabel);
            this.Controls.Add(this.launcherLabel);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainStatusStrip);
            this.Name = "MainForm";
            this.Text = "BetSoftware Framework";
            this.Load += new EventHandler(this.MainForm_Load);
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.Icon = Data.Icon;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.utilitiesTabPage.ResumeLayout(false);
            this.inputTabPage.ResumeLayout(false);
            this.betSelectionTabPage.ResumeLayout(false);
            this.moneyManagementTabPage.ResumeLayout(false);
            this.displayTabPage.ResumeLayout(false);
            this.outputTabPage.ResumeLayout(false);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        [STAThread]
        public static void Main(string[] args)
        {
            // Check there are arguments
            if (args.Length == 0)
            {
                // Not present
                // TODO MessageBox.Show("Missing initialization arguments." + Environment.NewLine + "Please use BetSoftware_Loader.exe", "Invalid initialization", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Set game
            /* TODO Data.Game = "Roulette";*/

            // Launch
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close this form to exit application
            this.Close();
        }

        /// <summary>
        /// Shows about form
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display about msg 
            MessageBox.Show("Programmed by Victor/VLS for the BetSelection.cc community." + Environment.NewLine + Environment.NewLine + "(October 2014 / Version: 0.1" /* TODO Application.ProductVersion */ + ")", "About BetSoftware Framework", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles form closing 
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if must ask
            if (this.askOnExitToolStripMenuItem.Checked)
            {
                // Ask
                if (MessageBox.Show("Would you like to exit now?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    // Cancel form close
                    e.Cancel = true;

                    // Exit FormClosing procedure
                    return;
                }
            }

            // Instantiate XmlTextWriter
            XmlTextWriter writer = new XmlTextWriter(Data.XmlFile, null);

            // Set formatting
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;

            // Document start
            writer.WriteStartDocument();

            // Root start
            writer.WriteStartElement("BetSoftware");

            // Options start
            writer.WriteStartElement("Options");

            // Write options
            foreach (ToolStripMenuItem tsmi in this.optionsToolStripMenuItem.DropDownItems)
            {
                // Save checked status
                writer.WriteElementString(tsmi.Name.Replace("ToolStripMenuItem", string.Empty), tsmi.CheckState.ToString());
            }

            // Options end
            writer.WriteEndElement();

            /* Coordinates */

            // Coordinates start
            writer.WriteStartElement("Coordinates");

            // Iterate through forms
            foreach (Form frm in Application.OpenForms)
            {
                // Current form start
                writer.WriteStartElement(frm.Name);

                // Save coordinates
                writer.WriteElementString("x", frm.Left.ToString());
                writer.WriteElementString("y", frm.Top.ToString());

                // Current form end
                writer.WriteEndElement();
            }

            // Coordinates end
            writer.WriteEndElement();

            // Root start
            writer.WriteEndElement();

            // Document end
            writer.WriteEndDocument();

            // Close writer
            writer.Close();
        }

        /// <summary>
        /// Sets the options.
        /// </summary>
        private void SetOptions()
        {
            // File Size
            FileInfo xmlInfo = new FileInfo(Data.XmlFile);

            // Check for XML file's existence and length
            if (File.Exists(Data.XmlFile) && xmlInfo.Length > 0)
            {
                // Set XPath Document                
                XPathDocument document = new XPathDocument(Data.XmlFile);

                // Create XPath Navigator
                XPathNavigator navigator = document.CreateNavigator();

                // Process Options
                foreach (XPathNavigator section in navigator.Select("/BetSoftware/Options"))
                {
                    foreach (XPathNavigator node in section.SelectChildren(XPathNodeType.All))
                    {
                        // Toggle options
                        foreach (ToolStripMenuItem tsmi in this.optionsToolStripMenuItem.DropDownItems)
                        {
                            // Set CheckState
                            if (tsmi.Name == node.Name + "ToolStripMenuItem")
                            {
                                // Load from file
                                tsmi.CheckState = node.InnerXml == "Checked" ? CheckState.Checked : CheckState.Unchecked;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles launch button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void LaunchButton_Click(object sender, EventArgs e)
        {
            // Add new BetMarshal to list
            this.marshals.Add(new BetMarshal());

            // Iterate parent nodes
            foreach (TreeNode ptn in this.launchTreeView.Nodes)
            {
                // Iterate child nodes
                foreach (TreeNode ctn in ptn.Nodes)
                {
                    // Load assembly
                    Assembly asm = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + ptn.Name.Substring(2) + Path.DirectorySeparatorChar + this.moduleDir[ptn.Name.Substring(2)][ctn.Name] + Path.DirectorySeparatorChar + this.DisplayNameToNameSpace(ctn.Name) + ".dll");

                    // Get type
                    Type type = asm.GetType(this.DisplayNameToNameSpace(ctn.Name) + "." + this.DisplayNameToNameSpace(ctn.Name));

                    // Set module instance
                    object obj = Activator.CreateInstance(type);

                    // Add to marshals
                    this.marshals[this.marshals.Count - 1].AddModule(ptn.Name.Substring(2), obj);

                    // Invoke initialization
                    type.GetMethod("Init").Invoke(obj, new object[] { this.marshals[this.marshals.Count - 1] });
                }
            }
        }

        /// <summary>
        /// Sets TopMost in open forms
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void AlwaysOntopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle first
            this.ToolStripMenuItem_Click(sender, e);

            // Set TopMost
            this.TopMostForms(this.alwaysOntopToolStripMenuItem.Checked);
        }

        /// <summary>
        /// Sets TopMost status in open forms.
        /// </summary>
        /// <param name="flag">TopMost value</param>
        private void TopMostForms(bool flag)
        {
            // Loop through open forms
            foreach (Form f in Application.OpenForms)
            {
                // Set it
                f.TopMost = flag;
            }
        }

        /// <summary>
        /// Generic event handler for ToolStripMenuItem
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        }

        /// <summary>
        /// Launches BetSelection.cc using default browser
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void WebLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Launch site
            Process.Start("http://betselection.cc");
        }

        /// <summary>
        /// Adds to (or removes from) TreeView
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Declare listbox
            ListBox lb = null;

            // Suspend TreeView drawing
            this.launchTreeView.SuspendLayout();

            // Act on ListBox tag
            switch (((ListBox)sender).Tag.ToString())
            {
            // Utilities
                case "tnUtilities":

                    // Set ListBox
                    lb = this.utilitiesListBox;

                    break;

            // Input
                case "tnInput":

                    // Set ListBox
                    lb = this.inputListBox;

                    break;

            // Bet selection
                case "tnBetSelection":

                    // Set ListBox
                    lb = this.betSelectionListBox;

                    break;

            // Money management
                case "tnMoneyManagement":

                    // Set ListBox
                    lb = this.moneyManagementListBox;

                    break;

            // Display
                case "tnDisplay":

                    // Set ListBox
                    lb = this.displayListBox;

                    break;

            // Output
                case "tnOutput":

                    // Set ListBox
                    lb = this.outputListBox;

                    break;
            }

            /* Process added or removed module */

            // Last module
            string lastModule = string.Empty;

            // Last index
            int removedIndex = -1;

            // Compare collections
            if (this.lbsic[lb.Name].Count > 0)
            {
                // Check for addition
                if (this.lbsic[lb.Name].Count < lb.SelectedItems.Count)
                {
                    // Iterate items
                    foreach (object item in lb.SelectedItems)
                    {
                        // Check for presence in object collection
                        if (!this.lbsic[lb.Name].Contains(item.ToString()))
                        {
                            // Set module
                            lastModule = item.ToString();

                            // Exit loop
                            break;
                        }
                    }
                }
                else
                {
                    /* Removal, get item index */

                    // Iterate items
                    foreach (object item in lb.SelectedItems)
                    {
                        // Check for presence in object collection
                        if (this.lbsic[lb.Name].Contains(item.ToString()))
                        {
                            // Remove 
                            this.lbsic[lb.Name].Remove(item.ToString());
                        }
                    }

                    // Get index in TreeView nodes                        
                    foreach (TreeNode tn in this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes)
                    {
                        // Check for module text
                        if (tn.Text == this.lbsic[lb.Name][0].ToString())
                        {
                            // Set index
                            removedIndex = tn.Index;

                            // Exit loop
                            break;
                        }
                    }
                }
            }
            else
            {
                // Check for added
                if (lb.SelectedItems.Count == 1)
                {
                    // Set module
                    lastModule = lb.SelectedItem.ToString();
                }
            }

            /* Synchronize  */

            // Update TreeView
            if (removedIndex == -1)
            {
                // Add
                this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes.Add(lastModule, lastModule);
            }
            else
            {
                // Remove
                this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes.RemoveAt(removedIndex);
            }

            // Change status text
            this.statusToolStripStatusLabel.Text = Data.StepTwo;

            // Enable
            this.launchTreeView.Enabled = true;
            this.launchButton.Enabled = true;

            // Expand all nodes
            this.launchTreeView.ExpandAll();

            // Select main node
            this.launchTreeView.SelectedNode = this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()];

            /* Set last module by removal */

            // Check index
            if (removedIndex != -1)
            {
                // Check if index is present
                if (removedIndex < this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes.Count)
                {
                    // Get module at same index in TreeView nodes                        
                    foreach (TreeNode tn in this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes)
                    {
                        // Check for module index
                        if (tn.Index == removedIndex)
                        {
                            // Set last module
                            lastModule = tn.Text;
                        }
                    }
                }
                else
                {
                    // Get module at -1 index in TreeView nodes                        
                    foreach (TreeNode tn in this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes)
                    {
                        // Check for module index
                        if (tn.Index == removedIndex - 1)
                        {
                            // Set last module
                            lastModule = tn.Text;
                        }
                    }
                }
            }

            /* Select last module in TreeView */

            // Check for module
            if (lastModule != string.Empty)
            {
                // Select last selected in TreeView
                foreach (TreeNode tn in this.launchTreeView.Nodes[((ListBox)sender).Tag.ToString()].Nodes)
                {
                    // Check for module text
                    if (tn.Text == lastModule)
                    {
                        // Select module
                        this.launchTreeView.SelectedNode = tn;

                        // Exit loop
                        break;
                    }
                }
            }

            /* Prepare collection for next call */

            // Clear collection
            this.lbsic[lb.Name].Clear();

            // Set collection
            foreach (object item in lb.SelectedItems)
            {
                // Add current item
                this.lbsic[lb.Name].Add(item.ToString());
            }

            // Resume TreeView drawing
            this.launchTreeView.ResumeLayout();
        }

        /// <summary>
        /// MainForm load event handler
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Modules dictionary
            Dictionary<string, List<string>> modules = new Dictionary<string, List<string>>();

            // Process base directories
            foreach (string dir in this.baseDirs)
            {
                // Check existence
                if (Directory.Exists(/* TODO Path.Combine */ AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + dir))
                {
                    // Add current directory to dictionary
                    modules.Add(dir, new List<string>()); 

                    // Set list of games
                    List<string> games = new List<string>() { Data.Game, "Multigame" };

                    // Iterate games
                    foreach (string game in games)
                    {
                        // Get modules
                        string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + dir + Path.DirectorySeparatorChar + this.UpperFirst(game), "*.dll");

                        // Process game modules
                        for (int i = 0; i < files.Length; i++)
                        {
                            // Check it's unique
                            if (!modules[dir].Contains(Path.GetFileNameWithoutExtension(files[i])))
                            {
                                // Add current module
                                modules[dir].Add(Path.GetFileNameWithoutExtension(files[i]));

                                // Prepare dictionary
                                if (!this.moduleDir.ContainsKey(dir))
                                {
                                    this.moduleDir.Add(dir, new Dictionary<string, string>());
                                }

                                // Add current module dir
                                this.moduleDir[dir].Add(this.NameSpaceToDisplayName(Path.GetFileNameWithoutExtension(files[i])), game);
                            }
                        }
                    }
                }
                else
                {
                    // Create base directory
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + dir);

                    // Process game subdirectories
                    foreach (string subdir in this.gameDirs)
                    {
                        // Create game subdirectory
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + dir + Path.DirectorySeparatorChar + subdir);
                    }
                }
            }

            /* TODO Handle possible race condition when creating directories. Validate their full creation before proceeding. */

            try
            {
                // Process modules dictionary
                foreach (string dir in this.baseDirs)
                {
                    // Interate main tab control
                    foreach (Control mtc in this.mainTabControl.Controls)
                    {
                        // Check if it's a TabPage
                        if (mtc is TabPage)
                        {
                            // Check if it's a match                    
                            if (dir.ToLower() == mtc.Name.Substring(0, mtc.Name.Length - 7).ToLower())
                            {
                                // Iterate tab page controls
                                foreach (Control ctrl in mtc.Controls)
                                {
                                    // Check if it's a ListBox
                                    if (ctrl is ListBox)
                                    {
                                        // Check if it's a match                    
                                        if (dir.ToLower() == ctrl.Name.Substring(0, ctrl.Name.Length - 7).ToLower())
                                        {
                                            // Iterate modules
                                            foreach (string module in modules[dir])
                                            {
                                                // Add current one
                                                ((ListBox)ctrl).Items.Add(this.NameSpaceToDisplayName(module));
                                            }

                                            // Prepare dictionary for SelectedIndexChanged calls
                                            this.lbsic.Add(ctrl.Name, new List<string>());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO Improve generic error message 
                MessageBox.Show(ex.Message);
            }

            // Select input tab page 
            this.mainTabControl.SelectedTab = this.inputTabPage; /* TODO Remember last tab */

            /* Update counters */

            // Utilities counter
            if (this.utilitiesListBox.Items.Count > 0)
            {
                // Utilities count
                this.utilitiesTabPage.Text = "Util. (" + this.utilitiesListBox.Items.Count + ")";
            }

            // Input counter
            if (this.inputListBox.Items.Count > 0)
            {
                // Input count
                this.inputTabPage.Text = "In (" + this.inputListBox.Items.Count + ")";
            }

            // Bet Selection counter
            if (this.betSelectionListBox.Items.Count > 0)
            {
                // Bet Selection count
                this.betSelectionTabPage.Text = "Bet S (" + this.betSelectionListBox.Items.Count + ")";
            }

            // Money Management counter
            if (this.moneyManagementListBox.Items.Count > 0)
            {
                // Money Management count
                this.moneyManagementTabPage.Text = "MM (" + this.moneyManagementListBox.Items.Count + ")";
            }

            // Display counter
            if (this.displayListBox.Items.Count > 0)
            {
                // Display count
                this.displayTabPage.Text = "Disp. (" + this.displayListBox.Items.Count + ")";
            }

            // Output counter
            if (this.outputListBox.Items.Count > 0)
            {
                // Set count
                this.outputTabPage.Text = "Out (" + this.outputListBox.Items.Count + ")";
            }

            /* Load options */

            // File Size
            FileInfo xmlInfo = new FileInfo(Data.XmlFile);

            // Check for XML file's existence and length
            if (File.Exists(Data.XmlFile) && xmlInfo.Length > 0)
            {
                // Set options
                this.SetOptions();

                // Should set previous position?
                if (this.savePositionToolStripMenuItem.Checked)
                {
                    // Set Modules Position
                    this.SetModulesPosition();
                }
            }
            else
            {
                // Center screen
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        /// <summary>
        /// Changes passed display name to namespace.
        /// </summary>
        /// <returns>Resulting name space.</returns>
        /// <param name="displayName">Display name.</param>
        private string DisplayNameToNameSpace(string displayName)
        {
            // Check strings are there
            if (displayName.Length > 0)
            {
                // Match with regular expression
                MatchCollection matches = Regex.Matches(displayName, @"[^a-zA-Z0-9_]");

                // Walk reversed
                for (int i = matches.Count - 1; i >= 0; i--)
                {
                    // Handle space
                    if (matches[i].Value == " ")
                    {
                        // Remove original
                        displayName = displayName.Remove(matches[i].Index, 1);

                        // Insert replacement
                        displayName = displayName.Insert(matches[i].Index, "__");

                        // Next iteration
                        continue;
                    }

                    // Set encoding
                    UTF32Encoding encoding = new UTF32Encoding(); 

                    // Get current bytes
                    byte[] bytes = encoding.GetBytes(matches[i].Value.ToCharArray()); 

                    // Remove original
                    displayName = displayName.Remove(matches[i].Index, 1);

                    // Insert replacement
                    displayName = displayName.Insert(matches[i].Index, "_" + BitConverter.ToInt32(bytes, 0).ToString() + "_");
                }

                // Return processed display name
                return displayName;
            }

            // Return empty string by default
            return string.Empty;
        }

        /// <summary>
        /// Converts passed string's first letter to uppercase
        /// </summary>
        /// <param name="text">String to work with</param>
        /// <returns>String with first letter in uppercase and the rest in lowercase</returns>
        private string UpperFirst(string text)
        {
            // Check there's something to work with
            if (text.Length > 1)
            {
                // Make title case
                text = text[0].ToString().ToUpper() + text.Substring(1).ToLower();
            }

            // Return
            return text;
        }

        /// <summary>
        /// Changes namespace to display name by naming convention
        /// </summary>
        /// <param name="nameSpace">string Passed namespace</param>
        /// <returns>String with replacements</returns>
        private string NameSpaceToDisplayName(string nameSpace)
        {
            // Match with regular expression
            MatchCollection matches = Regex.Matches(nameSpace, @"_[0-9]+_");

            // Walk reversed
            for (int i = matches.Count - 1; i >= 0; i--)
            {
                /* Validate odd underscores */

                // Counter
                int count = 0;

                // Get underscores
                for (int j = matches[i].Index; j >= 0; j--)
                {
                    // Check for non-underscore
                    if (nameSpace[j].ToString() != "_")
                    {
                        // Halt flow
                        break;
                    }

                    // Rise counter
                    count++;
                }

                // Check for odd
                if ((count % 2) == 0)
                {
                    // Move to next iteration
                    continue;
                }

                // Convert
                try
                {
                    // Declare
                    int intVal;

                    // Parse from string
                    if (int.TryParse(matches[i].Value.Replace("_", string.Empty), NumberStyles.Integer, null, out intVal))
                    {
                        // Remove original
                        nameSpace = nameSpace.Remove(matches[i].Index, matches[i].Length);

                        // Insert replacement
                        nameSpace = nameSpace.Insert(matches[i].Index, char.ConvertFromUtf32(intVal).ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Let it fall through
                }
            }

            // Replace double-space with single
            nameSpace = nameSpace.Replace("__", " ");

            // Processed namespace back
            return nameSpace;
        }

        /// <summary>
        /// Sets modules position.
        /// </summary>
        private void SetModulesPosition()
        {
            // File Size
            FileInfo xmlInfo = new FileInfo(Data.XmlFile);

            // Check for XML file's existence and length
            if (File.Exists(Data.XmlFile) && xmlInfo.Length > 0)
            {
                // Set XPath Document                
                XPathDocument document = new XPathDocument(Data.XmlFile);

                // Create XPath Navigator
                XPathNavigator navigator = document.CreateNavigator();

                // Coordinates
                if (this.savePositionToolStripMenuItem.Checked)
                {
                    // Process
                    foreach (XPathNavigator section in navigator.Select("/BetSoftware/Coordinates"))
                    {
                        foreach (XPathNavigator subsection in section.SelectChildren(XPathNodeType.All))
                        {
                            // Process forms
                            foreach (Form frm in Application.OpenForms)
                            {
                                // Match
                                if (frm.Name == subsection.Name)
                                {
                                    // Set X,Y
                                    foreach (XPathNavigator node in subsection.SelectChildren(XPathNodeType.All))
                                    {
                                        // X
                                        if (node.Name == "x")
                                        {
                                            frm.Left = Convert.ToInt32(node.InnerXml);
                                        }

                                        // Y
                                        if (node.Name == "y")
                                        {
                                            frm.Top = Convert.ToInt32(node.InnerXml);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}