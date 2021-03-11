using ChartTools;
using ChartTools.Lyrics;

using LyricEditor.Properties;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LyricEditor
{
    public partial class frmEditor : Form
    {
        private string openedFile = string.Empty;
        private string lastSavedLyrics = null;
        private GlobalEvent[] events;

        public frmEditor()
        {
            InitializeComponent();
            Text = Resources.defaultTitle;

            if (Settings.Default.darkMode)
                optionsMenu_DarkMode.PerformClick();

            //Subscribing to menu events because the designer does not allow it and saving removes these lines in InitializeComponent
            fileMenu_Open.Click += menuOpen_Click;
            fileMenu_Save.Click += menuSave_Click;
            fileMenu_SaveAs.Click += menuSaveAs_Click;
            fileMenu_Exit.Click += (sender, e) => Application.Exit();
            fileMenu_Reload.Click += (sender, e) => LoadFile(openedFile);
            optionsMenu_DarkMode.Click += menuDarkMode_Click;

            aboutMenu.Click += (sender, e) => MessageBox.Show("Created by TheBoxyBear.\n\nTo download the latest version, report bugs or see the source code, visit: https://github.com/theboxybear/lyriceditor\n\nClone Hero Lyric Editor is powered by the ChartTools library, available at: https://github.com/theboxybear/charttools\n\nThis software is not affiliated with the Clone Hero video game.", "About");
            helpMenu.Click += (sender, e) => MessageBox.Show("Each line is a seperate phrase.\n\nTo seperate a word into syllables, add a hyphen betwen each syllable.\n\nTo add a literal hyphen, replace it with with a equal sign.\n\nSyllables with spaces between other characters will be treated as seperate syllables.", "Help");
        }
        public frmEditor(string file) : this() => OpenFile(file);

        /// <summary>
        /// On click on fileMenu_Open
        /// </summary>
        private void menuOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Chart files|*.chart" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    OpenFile(dialog.FileName);
        }
        /// <summary>
        /// On click on fileMenu_Save
        /// </summary>
        private void menuSave_Click(object sender, EventArgs e) => SaveFile(openedFile);
        /// <summary>
        /// On click on fileMenu_SaveAs
        /// </summary>
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog() { Filter = "Chart files|*.chart" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    SaveFile(dialog.FileName);
        }

        /// <summary>
        /// Reads and displays the lyrics from a file
        /// </summary>
        private void OpenFile(string path)
        {
            try { LoadFile(path); }
            catch { return; }

            lastSavedLyrics = GetDisplayedLyrics(events.GetLyrics());
            rtxtLyrics.Text = lastSavedLyrics;

            openedFile = path;
            SetOpenedFileFeaturesEnabled(true);
        }
        /// <summary>
        /// Reads the lyrics from a file without displaying them
        /// </summary>
        private void LoadFile(string path)
        {
            try { events = GlobalEvent.FromFile(path).ToArray(); }
            catch (Exception e)
            {
                if (MessageBox.Show($"Cannot read file: {e.Message}", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    LoadFile(path);

                throw;
            }

            try { DisplaySongTitle(Metadata.FromFile(path).Title); }
            catch { DisplaySongTitle(string.Empty); }
        }
        private void SaveFile(string path)
        {
            Phrase[] lyrics = events.GetLyrics().ToArray();

            foreach ((string line, Phrase phrase) in rtxtLyrics.Lines.Zip(lyrics))
            {
                string[] splits = line.Split(' ', '-', '=');

                switch (splits.Length.CompareTo(phrase.Syllables.Count))
                {
                    case -1:
                        MessageBox.Show($"Phrase starting at {phrase.Position} \"{line.Trim()}\" contains more lyric events for the provided syllables.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 1:
                        MessageBox.Show($"Phrase starting at {phrase.Position} \"{line}\" does not contain enough lyric events to accomodate the provided syllables. If the issue is fixed using another program, reload the file.", "Cannot save file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                for (int i = 0; i < splits.Length; i++)
                    phrase.Syllables[i].RawText = splits[i][^1] == ',' ? splits[i] + ' ' : splits[i]; ;
                for (int i = splits.Length; i < phrase.Syllables.Count; i++)
                    phrase.Syllables[i].RawText = string.Empty;
            }

            events = events.SetLyrics(lyrics).ToArray();

            try { events.ToFile(path); }
            catch (Exception e)
            {
                MessageBox.Show($"Cannot save file: {e.Message}", "Error");
                return;
            }

            lastSavedLyrics = rtxtLyrics.Text;
        }

        private string GetDisplayedLyrics(IEnumerable<Phrase> lyrics) => string.Join('\n', lyrics.Select(p => p.RawText));

        //On closure of the application
        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (openedFile != string.Empty && rtxtLyrics.Text != lastSavedLyrics)
                e.Cancel = MessageBox.Show("You have unsaved changes. Are you sure you want to quit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No;
        }
        private void menuDarkMode_Click(object sender, EventArgs e)
        {
            if (optionsMenu_DarkMode.Checked)
            {
                rtxtLyrics.BackColor = Color.Black;
                rtxtLyrics.ForeColor = Color.White;
            }
            else
            {
                rtxtLyrics.BackColor = SystemColors.Control;
                rtxtLyrics.ForeColor = SystemColors.ControlText;
            }

            Settings.Default.darkMode = optionsMenu_DarkMode.Checked;
        }

        /// <summary>
        /// Set the enabled state of features limited to when a file is opened
        /// </summary>
        private void SetOpenedFileFeaturesEnabled(bool value) => fileMenu_Reload.Enabled = fileMenu_Save.Enabled = fileMenu_SaveAs.Enabled = value;

        /// <summary>
        /// Displays the title of a song to the titlebar
        /// </summary>
        /// <remarks>Sending an empty string will reset to the default title</remarks>
        private void DisplaySongTitle(string title) => Text = title == string.Empty ? Resources.defaultTitle : $"{title} - {Resources.defaultTitle}";
    }
}
