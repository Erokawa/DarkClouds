using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using Microsoft.Win32;

namespace DarkCloud {
  public partial class Form1 : Form {

    public Form1() {

      InitializeComponent();

      backup_dir.Text = appsettings.Default.local_dir;
      textbox_gamedir.Text = appsettings.Default.game_dir;

      MessageBox.Show(
        @"Be sure to have installed 7zip in your system 'Program Files\7-Zip'", 
        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
      );

    }

    private string detectGameInPathByString() {

      string game_detected = "Not found";

      if(textbox_gamedir.Text.Contains("Game")) {

        if (textbox_gamedir.Text.Contains("III")) {

          game_detected = "DarkSoulsIII";

        } else if (textbox_gamedir.Text.Contains("II")) {

          game_detected = "DarkSoulsII";

        }

      }

      return game_detected;

    }

    private string getRealDate() {

      String day = DateTime.Now.Date.Day.ToString();
      String month = DateTime.Now.Date.Month.ToString();
      String year = DateTime.Now.Date.Year.ToString();

      return "_" + day + "_" + month + "_" + year;

    }

    private void checkRunningProcessStatus(Process process) {

      if (process.HasExited) {

        process_status_label.Text = "Not running";
        process_status_label.ForeColor = Color.Red;

      } else {

        process_status_label.Text = "Running";
        process_status_label.ForeColor = Color.Green;

      }

    }

    private void backup_dir_TextChanged(object sender, EventArgs e) {

      appsettings.Default.local_dir = backup_dir.Text;
      appsettings.Default.Save();

    }

    private void game_dir_button_Click(object sender, EventArgs e) {

      if (folder_browser.ShowDialog() == DialogResult.OK) {

        textbox_gamedir.Text = folder_browser.SelectedPath;
        appsettings.Default.game_dir = textbox_gamedir.Text;
        Console.WriteLine(appsettings.Default.game_dir);
        appsettings.Default.Save();
        folder_browser.SelectedPath = "";

      }

    }

    private void launch_button_Click(object sender, EventArgs e) {

      string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
      Process bat_process = new Process();
      bat_process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

      //Change directory path if the executable file its installed of opened from vs
      if (System.Diagnostics.Debugger.IsAttached) {
        bat_process.StartInfo.FileName = path + @"\bat_files\savedata.bat";
      } else {
        bat_process.StartInfo.FileName =
          AppDomain.CurrentDomain.BaseDirectory + @"bat_files\savedata.bat";
      }

      String game_detected = detectGameInPathByString();
      String date_string = getRealDate();

      bat_process.StartInfo.Arguments = String.Format(
      "\"{0}\" \"{1}\" \"{2}\" \"{3}\" \"{4}\"",
      game_detected, backup_dir.Text, textbox_gamedir.Text
      + @"\" + game_detected + @".exe", game_detected + @".exe", date_string);

      Console.WriteLine("Process arguments: " + bat_process.StartInfo.Arguments);
      bat_process.Start();
      checkRunningProcessStatus(bat_process);
      bat_process.WaitForExit();
      checkRunningProcessStatus(bat_process);

    }

    private void backup_dir_button_Click(object sender, EventArgs e) {

      if (folder_browser.ShowDialog() == DialogResult.OK) {

        backup_dir.Text = folder_browser.SelectedPath;
        appsettings.Default.local_dir = backup_dir.Text;
        Console.WriteLine(appsettings.Default.local_dir);
        appsettings.Default.Save();
        folder_browser.SelectedPath = "";

      }

    }
  }

}
