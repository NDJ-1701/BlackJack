namespace NBlackJack
{
    partial class Game
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
            this.PlayerCards_label = new System.Windows.Forms.Label();
            this.DealerCards_label = new System.Windows.Forms.Label();
            this.Result_label = new System.Windows.Forms.Label();
            this.Stand_button = new System.Windows.Forms.Button();
            this.PlayerTotal_label = new System.Windows.Forms.Label();
            this.DealerTotal_label = new System.Windows.Forms.Label();
            this.DealHand_button = new System.Windows.Forms.Button();
            this.Hit_button = new System.Windows.Forms.Button();
            this.LastDealtCard_label = new System.Windows.Forms.Label();
            this.Shuffle_button = new System.Windows.Forms.Button();
            this.Bank_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayerCards_label
            // 
            this.PlayerCards_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerCards_label.AutoSize = true;
            this.PlayerCards_label.Location = new System.Drawing.Point(10, 234);
            this.PlayerCards_label.Name = "PlayerCards_label";
            this.PlayerCards_label.Size = new System.Drawing.Size(76, 13);
            this.PlayerCards_label.TabIndex = 33;
            this.PlayerCards_label.Text = "Player\'s Cards:";
            // 
            // DealerCards_label
            // 
            this.DealerCards_label.AutoSize = true;
            this.DealerCards_label.Location = new System.Drawing.Point(10, 177);
            this.DealerCards_label.Name = "DealerCards_label";
            this.DealerCards_label.Size = new System.Drawing.Size(78, 13);
            this.DealerCards_label.TabIndex = 32;
            this.DealerCards_label.Text = "Dealer\'s Cards:";
            // 
            // Result_label
            // 
            this.Result_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Result_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_label.ForeColor = System.Drawing.Color.Black;
            this.Result_label.Location = new System.Drawing.Point(13, 147);
            this.Result_label.Name = "Result_label";
            this.Result_label.Size = new System.Drawing.Size(475, 120);
            this.Result_label.TabIndex = 37;
            this.Result_label.Text = "Result";
            this.Result_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Stand_button
            // 
            this.Stand_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Stand_button.Enabled = false;
            this.Stand_button.Location = new System.Drawing.Point(412, 324);
            this.Stand_button.Name = "Stand_button";
            this.Stand_button.Size = new System.Drawing.Size(75, 40);
            this.Stand_button.TabIndex = 36;
            this.Stand_button.Text = "Stand";
            this.Stand_button.UseVisualStyleBackColor = true;
            this.Stand_button.Click += new System.EventHandler(this.Stand_button_Click);
            // 
            // PlayerTotal_label
            // 
            this.PlayerTotal_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerTotal_label.AutoSize = true;
            this.PlayerTotal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTotal_label.Location = new System.Drawing.Point(29, 297);
            this.PlayerTotal_label.Name = "PlayerTotal_label";
            this.PlayerTotal_label.Size = new System.Drawing.Size(36, 37);
            this.PlayerTotal_label.TabIndex = 35;
            this.PlayerTotal_label.Text = "0";
            // 
            // DealerTotal_label
            // 
            this.DealerTotal_label.AutoSize = true;
            this.DealerTotal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DealerTotal_label.Location = new System.Drawing.Point(29, 89);
            this.DealerTotal_label.Name = "DealerTotal_label";
            this.DealerTotal_label.Size = new System.Drawing.Size(36, 37);
            this.DealerTotal_label.TabIndex = 34;
            this.DealerTotal_label.Text = "0";
            // 
            // DealHand_button
            // 
            this.DealHand_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DealHand_button.Location = new System.Drawing.Point(331, 324);
            this.DealHand_button.Name = "DealHand_button";
            this.DealHand_button.Size = new System.Drawing.Size(75, 40);
            this.DealHand_button.TabIndex = 31;
            this.DealHand_button.Text = "Deal Hand";
            this.DealHand_button.UseVisualStyleBackColor = true;
            this.DealHand_button.Click += new System.EventHandler(this.DealHand_button_Click);
            // 
            // Hit_button
            // 
            this.Hit_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Hit_button.Enabled = false;
            this.Hit_button.Location = new System.Drawing.Point(412, 278);
            this.Hit_button.Name = "Hit_button";
            this.Hit_button.Size = new System.Drawing.Size(75, 40);
            this.Hit_button.TabIndex = 29;
            this.Hit_button.Text = "Hit";
            this.Hit_button.UseVisualStyleBackColor = true;
            this.Hit_button.Click += new System.EventHandler(this.Hit_button_Click);
            // 
            // LastDealtCard_label
            // 
            this.LastDealtCard_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastDealtCard_label.AutoSize = true;
            this.LastDealtCard_label.Location = new System.Drawing.Point(10, 206);
            this.LastDealtCard_label.Name = "LastDealtCard_label";
            this.LastDealtCard_label.Size = new System.Drawing.Size(68, 13);
            this.LastDealtCard_label.TabIndex = 28;
            this.LastDealtCard_label.Text = "lastdealtCard";
            this.LastDealtCard_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Shuffle_button
            // 
            this.Shuffle_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Shuffle_button.Location = new System.Drawing.Point(412, 12);
            this.Shuffle_button.Name = "Shuffle_button";
            this.Shuffle_button.Size = new System.Drawing.Size(75, 40);
            this.Shuffle_button.TabIndex = 27;
            this.Shuffle_button.Text = "Shuffle";
            this.Shuffle_button.UseVisualStyleBackColor = true;
            this.Shuffle_button.Click += new System.EventHandler(this.Shuffle_button_Click);
            // 
            // Bank_label
            // 
            this.Bank_label.AutoSize = true;
            this.Bank_label.Location = new System.Drawing.Point(424, 67);
            this.Bank_label.Margin = new System.Windows.Forms.Padding(0);
            this.Bank_label.Name = "Bank_label";
            this.Bank_label.Size = new System.Drawing.Size(46, 13);
            this.Bank_label.TabIndex = 39;
            this.Bank_label.Text = "$100.00";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(499, 376);
            this.Controls.Add(this.Bank_label);
            this.Controls.Add(this.PlayerCards_label);
            this.Controls.Add(this.DealerCards_label);
            this.Controls.Add(this.Stand_button);
            this.Controls.Add(this.PlayerTotal_label);
            this.Controls.Add(this.DealerTotal_label);
            this.Controls.Add(this.DealHand_button);
            this.Controls.Add(this.Hit_button);
            this.Controls.Add(this.LastDealtCard_label);
            this.Controls.Add(this.Shuffle_button);
            this.Controls.Add(this.Result_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.Text = "NBlackJack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button Shuffle_button;
        public System.Windows.Forms.Label PlayerCards_label;
        public System.Windows.Forms.Label DealerCards_label;
        public System.Windows.Forms.Label Result_label;
        public System.Windows.Forms.Button Stand_button;
        public System.Windows.Forms.Label PlayerTotal_label;
        public System.Windows.Forms.Label DealerTotal_label;
        public System.Windows.Forms.Button DealHand_button;
        public System.Windows.Forms.Button Hit_button;        
        public System.Windows.Forms.Label LastDealtCard_label;
        private System.Windows.Forms.Label Bank_label;
    }
}

