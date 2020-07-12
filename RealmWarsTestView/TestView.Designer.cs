


namespace RealmWarsTestView
{
    partial class TestView
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
            this.start = new System.Windows.Forms.Button();
            this.console_window = new System.Windows.Forms.ListBox();
            this.AttackButton = new System.Windows.Forms.Button();
            this.timeline_window = new System.Windows.Forms.ListBox();
            this.turn_timing_bar = new System.Windows.Forms.ProgressBar();
            this.add_combatant_btn = new System.Windows.Forms.Button();
            this.combatant_window = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(103, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start Battle";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // console_window
            // 
            this.console_window.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.console_window.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_window.ItemHeight = 18;
            this.console_window.Location = new System.Drawing.Point(12, 42);
            this.console_window.MinimumSize = new System.Drawing.Size(200, 200);
            this.console_window.Name = "console_window";
            this.console_window.Size = new System.Drawing.Size(324, 184);
            this.console_window.TabIndex = 1;
            // 
            // AttackButton
            // 
            this.AttackButton.Enabled = false;
            this.AttackButton.Location = new System.Drawing.Point(122, 12);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(75, 23);
            this.AttackButton.TabIndex = 2;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = true;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // timeline_window
            // 
            this.timeline_window.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.timeline_window.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeline_window.ItemHeight = 18;
            this.timeline_window.Location = new System.Drawing.Point(12, 232);
            this.timeline_window.MinimumSize = new System.Drawing.Size(200, 200);
            this.timeline_window.Name = "timeline_window";
            this.timeline_window.Size = new System.Drawing.Size(324, 184);
            this.timeline_window.TabIndex = 7;
            // 
            // turn_timing_bar
            // 
            this.turn_timing_bar.Location = new System.Drawing.Point(204, 12);
            this.turn_timing_bar.MarqueeAnimationSpeed = 0;
            this.turn_timing_bar.Name = "turn_timing_bar";
            this.turn_timing_bar.Size = new System.Drawing.Size(100, 23);
            this.turn_timing_bar.TabIndex = 8;
            // 
            // add_combatant_btn
            // 
            this.add_combatant_btn.AutoSize = true;
            this.add_combatant_btn.Enabled = false;
            this.add_combatant_btn.Location = new System.Drawing.Point(607, 11);
            this.add_combatant_btn.Name = "add_combatant_btn";
            this.add_combatant_btn.Size = new System.Drawing.Size(90, 23);
            this.add_combatant_btn.TabIndex = 11;
            this.add_combatant_btn.Text = "Add Combatant";
            this.add_combatant_btn.UseVisualStyleBackColor = true;
            this.add_combatant_btn.Click += new System.EventHandler(this.add_combatant_btn_Click);
            // 
            // combatant_window
            // 
            this.combatant_window.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.combatant_window.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combatant_window.ItemHeight = 18;
            this.combatant_window.Location = new System.Drawing.Point(342, 42);
            this.combatant_window.MinimumSize = new System.Drawing.Size(200, 200);
            this.combatant_window.Name = "combatant_window";
            this.combatant_window.Size = new System.Drawing.Size(200, 184);
            this.combatant_window.TabIndex = 12;
            // 
            // TestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 542);
            this.Controls.Add(this.combatant_window);
            this.Controls.Add(this.add_combatant_btn);
            this.Controls.Add(this.turn_timing_bar);
            this.Controls.Add(this.timeline_window);
            this.Controls.Add(this.AttackButton);
            this.Controls.Add(this.console_window);
            this.Controls.Add(this.start);
            this.Name = "TestView";
            this.Text = "TestView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ListBox console_window;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.ListBox timeline_window;
        private System.Windows.Forms.ProgressBar turn_timing_bar;
        private System.Windows.Forms.Button add_combatant_btn;
        private System.Windows.Forms.ListBox combatant_window;
    }
}

