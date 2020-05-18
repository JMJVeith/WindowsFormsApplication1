


namespace RealmWarsTestView
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.ConsoleWindow = new System.Windows.Forms.ListBox();
            this.AttackButton = new System.Windows.Forms.Button();
            this.timeline_list_box = new System.Windows.Forms.ListBox();
            this.turn_progress_bar = new System.Windows.Forms.ProgressBar();
            this.add_combatant_btn = new System.Windows.Forms.Button();
            this.combatant_display = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Do the Thing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ConsoleWindow
            // 
            this.ConsoleWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ConsoleWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleWindow.ItemHeight = 25;
            this.ConsoleWindow.Location = new System.Drawing.Point(16, 52);
            this.ConsoleWindow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsoleWindow.MinimumSize = new System.Drawing.Size(265, 245);
            this.ConsoleWindow.Name = "ConsoleWindow";
            this.ConsoleWindow.Size = new System.Drawing.Size(431, 229);
            this.ConsoleWindow.TabIndex = 1;
            // 
            // AttackButton
            // 
            this.AttackButton.Enabled = false;
            this.AttackButton.Location = new System.Drawing.Point(163, 15);
            this.AttackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(100, 28);
            this.AttackButton.TabIndex = 2;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = true;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // timeline_list_box
            // 
            this.timeline_list_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.timeline_list_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeline_list_box.ItemHeight = 25;
            this.timeline_list_box.Location = new System.Drawing.Point(16, 286);
            this.timeline_list_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeline_list_box.MinimumSize = new System.Drawing.Size(265, 245);
            this.timeline_list_box.Name = "timeline_list_box";
            this.timeline_list_box.Size = new System.Drawing.Size(431, 229);
            this.timeline_list_box.TabIndex = 7;
            // 
            // turn_progress_bar
            // 
            this.turn_progress_bar.Location = new System.Drawing.Point(272, 15);
            this.turn_progress_bar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.turn_progress_bar.MarqueeAnimationSpeed = 0;
            this.turn_progress_bar.Name = "turn_progress_bar";
            this.turn_progress_bar.Size = new System.Drawing.Size(133, 28);
            this.turn_progress_bar.TabIndex = 8;
            // 
            // add_combatant_btn
            // 
            this.add_combatant_btn.AutoSize = true;
            this.add_combatant_btn.Location = new System.Drawing.Point(809, 14);
            this.add_combatant_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add_combatant_btn.Name = "add_combatant_btn";
            this.add_combatant_btn.Size = new System.Drawing.Size(120, 28);
            this.add_combatant_btn.TabIndex = 11;
            this.add_combatant_btn.Text = "Add Combatant";
            this.add_combatant_btn.UseVisualStyleBackColor = true;
            this.add_combatant_btn.Click += new System.EventHandler(this.add_combatant_btn_Click);
            // 
            // combatant_display
            // 
            this.combatant_display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.combatant_display.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combatant_display.ItemHeight = 25;
            this.combatant_display.Location = new System.Drawing.Point(456, 52);
            this.combatant_display.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combatant_display.MinimumSize = new System.Drawing.Size(265, 245);
            this.combatant_display.Name = "combatant_display";
            this.combatant_display.Size = new System.Drawing.Size(265, 229);
            this.combatant_display.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 667);
            this.Controls.Add(this.combatant_display);
            this.Controls.Add(this.add_combatant_btn);
            this.Controls.Add(this.turn_progress_bar);
            this.Controls.Add(this.timeline_list_box);
            this.Controls.Add(this.AttackButton);
            this.Controls.Add(this.ConsoleWindow);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ConsoleWindow;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.ListBox timeline_list_box;
        private System.Windows.Forms.ProgressBar turn_progress_bar;
        private System.Windows.Forms.Button add_combatant_btn;
        private System.Windows.Forms.ListBox combatant_display;
    }
}

