namespace DarkCloud {
  partial class main_form {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
      this.launch_button = new System.Windows.Forms.Button();
      this.backup_dir = new System.Windows.Forms.TextBox();
      this.folder_browser = new System.Windows.Forms.FolderBrowserDialog();
      this.backup_dir_button = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.textbox_gamedir = new System.Windows.Forms.TextBox();
      this.game_dir_button = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.status_label = new System.Windows.Forms.Label();
      this.process_status_label = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // launch_button
      // 
      this.launch_button.Location = new System.Drawing.Point(190, 107);
      this.launch_button.Name = "launch_button";
      this.launch_button.Size = new System.Drawing.Size(75, 23);
      this.launch_button.TabIndex = 1;
      this.launch_button.Text = "Launch";
      this.launch_button.UseVisualStyleBackColor = true;
      this.launch_button.Click += new System.EventHandler(this.launch_button_Click);
      // 
      // backup_dir
      // 
      this.backup_dir.Location = new System.Drawing.Point(12, 23);
      this.backup_dir.Name = "backup_dir";
      this.backup_dir.Size = new System.Drawing.Size(221, 20);
      this.backup_dir.TabIndex = 3;
      this.backup_dir.TextChanged += new System.EventHandler(this.backup_dir_TextChanged);
      // 
      // backup_dir_button
      // 
      this.backup_dir_button.Location = new System.Drawing.Point(239, 23);
      this.backup_dir_button.Name = "backup_dir_button";
      this.backup_dir_button.Size = new System.Drawing.Size(26, 20);
      this.backup_dir_button.TabIndex = 4;
      this.backup_dir_button.Text = "...";
      this.backup_dir_button.UseVisualStyleBackColor = true;
      this.backup_dir_button.Click += new System.EventHandler(this.backup_dir_button_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Backup Output Dir";
      // 
      // textbox_gamedir
      // 
      this.textbox_gamedir.Location = new System.Drawing.Point(12, 67);
      this.textbox_gamedir.Name = "textbox_gamedir";
      this.textbox_gamedir.Size = new System.Drawing.Size(221, 20);
      this.textbox_gamedir.TabIndex = 6;
      // 
      // game_dir_button
      // 
      this.game_dir_button.Location = new System.Drawing.Point(239, 67);
      this.game_dir_button.Name = "game_dir_button";
      this.game_dir_button.Size = new System.Drawing.Size(26, 20);
      this.game_dir_button.TabIndex = 7;
      this.game_dir_button.Text = "...";
      this.game_dir_button.UseVisualStyleBackColor = true;
      this.game_dir_button.Click += new System.EventHandler(this.game_dir_button_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 51);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(114, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Game executable path";
      // 
      // status_label
      // 
      this.status_label.AutoSize = true;
      this.status_label.Location = new System.Drawing.Point(9, 112);
      this.status_label.Name = "status_label";
      this.status_label.Size = new System.Drawing.Size(40, 13);
      this.status_label.TabIndex = 9;
      this.status_label.Text = "Status:";
      // 
      // process_status_label
      // 
      this.process_status_label.AutoSize = true;
      this.process_status_label.ForeColor = System.Drawing.Color.Red;
      this.process_status_label.Location = new System.Drawing.Point(45, 112);
      this.process_status_label.Name = "process_status_label";
      this.process_status_label.Size = new System.Drawing.Size(62, 13);
      this.process_status_label.TabIndex = 10;
      this.process_status_label.Text = "Not running";
      // 
      // main_form
      // 
      this.ClientSize = new System.Drawing.Size(279, 139);
      this.Controls.Add(this.process_status_label);
      this.Controls.Add(this.status_label);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.game_dir_button);
      this.Controls.Add(this.textbox_gamedir);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.backup_dir_button);
      this.Controls.Add(this.backup_dir);
      this.Controls.Add(this.launch_button);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "main_form";
      this.Text = "DarkClouds";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button launch_button;
    private System.Windows.Forms.TextBox backup_dir;
    private System.Windows.Forms.FolderBrowserDialog folder_browser;
    private System.Windows.Forms.Button backup_dir_button;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textbox_gamedir;
    private System.Windows.Forms.Button game_dir_button;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label status_label;
    private System.Windows.Forms.Label process_status_label;
  }
}

