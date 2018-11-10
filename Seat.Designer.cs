namespace NBlackJack
{
    partial class Seat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player_label = new System.Windows.Forms.Label();
            this.PlayerTotal_label = new System.Windows.Forms.Label();
            this.Hand_panel = new System.Windows.Forms.Panel();
            this.PlayerCards_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player_label
            // 
            this.Player_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player_label.Location = new System.Drawing.Point(99, 127);
            this.Player_label.Name = "Player_label";
            this.Player_label.Size = new System.Drawing.Size(96, 13);
            this.Player_label.TabIndex = 36;
            this.Player_label.Text = "Player\'s Cards:";
            this.Player_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlayerTotal_label
            // 
            this.PlayerTotal_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerTotal_label.AutoSize = true;
            this.PlayerTotal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTotal_label.Location = new System.Drawing.Point(41, 127);
            this.PlayerTotal_label.Name = "PlayerTotal_label";
            this.PlayerTotal_label.Size = new System.Drawing.Size(36, 37);
            this.PlayerTotal_label.TabIndex = 37;
            this.PlayerTotal_label.Text = "0";
            // 
            // Hand_panel
            // 
            this.Hand_panel.Location = new System.Drawing.Point(3, 3);
            this.Hand_panel.Name = "Hand_panel";
            this.Hand_panel.Size = new System.Drawing.Size(359, 98);
            this.Hand_panel.TabIndex = 38;
            // 
            // PlayerCards_label
            // 
            this.PlayerCards_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerCards_label.AutoSize = true;
            this.PlayerCards_label.Location = new System.Drawing.Point(201, 127);
            this.PlayerCards_label.Name = "PlayerCards_label";
            this.PlayerCards_label.Size = new System.Drawing.Size(19, 13);
            this.PlayerCards_label.TabIndex = 39;
            this.PlayerCards_label.Text = "As";
            // 
            // Seat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PlayerCards_label);
            this.Controls.Add(this.Hand_panel);
            this.Controls.Add(this.Player_label);
            this.Controls.Add(this.PlayerTotal_label);
            this.Name = "Seat";
            this.Size = new System.Drawing.Size(363, 173);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label Player_label;
        public System.Windows.Forms.Label PlayerTotal_label;
        private System.Windows.Forms.Panel Hand_panel;
        public System.Windows.Forms.Label PlayerCards_label;
    }
}
