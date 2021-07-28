using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace DarkCloud {
  public partial class main_form : Form {

    public main_form() {

      InitializeComponent();

      backup_dir.Text = appsettings.Default.local_dir;
      textbox_gamedir.Text = appsettings.Default.game_dir;

      checkIfLocalDirectoryExists();

      System.Reflection.Assembly assembly = 
        System.Reflection.Assembly.GetExecutingAssembly();
      System.Diagnostics.FileVersionInfo fvi = 
        System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

      this.Text += " " + fvi.FileVersion;

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

    private void saveCurrentGameSaveFiles(string gamename) {

      string appdata_path =
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

      string final_backup_path = appdata_path + "\\" + gamename;

      string final_backupdir = backup_dir.Text + "\\" + gamename +
        getRealDate() + "-" + appsettings.Default.backup_num + ".zip";

      ZipFile.CreateFromDirectory(final_backup_path, final_backupdir);

      appsettings.Default.backup_num++;
      appsettings.Default.Save();

    }

    //Enables launch button if local directory exists, disables otherwise
    private void checkIfLocalDirectoryExists() {

      if (!Directory.Exists(appsettings.Default.local_dir))
        launch_button.Enabled = false;
      else
        launch_button.Enabled = true;

    }

    private void backup_dir_TextChanged(object sender, EventArgs e) {

      appsettings.Default.local_dir = backup_dir.Text;
      appsettings.Default.Save();

      checkIfLocalDirectoryExists();

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

      String game_detected = detectGameInPathByString();
      Console.WriteLine(textbox_gamedir);
      String gamepath = textbox_gamedir.Text + @"\" + game_detected + @".exe";
      Console.WriteLine(textbox_gamedir);

      //Check if game executable file exists then start the process
      if (File.Exists(gamepath)) {

        saveCurrentGameSaveFiles(game_detected);

        Process game_process = Process.Start(gamepath);

        checkRunningProcessStatus(game_process);
        game_process.WaitForExit();
        checkRunningProcessStatus(game_process);

      } else {

        MessageBox.Show(
         @"Cannot find the executable path specified",
         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
        );

      }

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
