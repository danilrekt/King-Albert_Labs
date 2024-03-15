namespace King_Albert
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ColumnsPanel = new FlowLayoutPanel();
            reserv1 = new Reserv();
            cardFinishPanel1 = new CardFinishPanel();
            SuspendLayout();
            // 
            // ColumnsPanel
            // 
            ColumnsPanel.BackColor = Color.DarkGray;
            ColumnsPanel.Location = new Point(15, 54);
            ColumnsPanel.Name = "ColumnsPanel";
            ColumnsPanel.Size = new Size(901, 592);
            ColumnsPanel.TabIndex = 1;
            ColumnsPanel.WrapContents = false;
            ColumnsPanel.MouseMove += flowLayoutPanel1_MouseMove;
            ColumnsPanel.MouseUp += ColumnsPanel_MouseUp;
            // 
            // reserv1
            // 
            reserv1.Location = new Point(922, 348);
            reserv1.Name = "reserv1";
            reserv1.Size = new Size(398, 146);
            reserv1.TabIndex = 3;
            reserv1.MouseUp += Reserv1_MouseUp;
            // 
            // cardFinishPanel1
            // 
            cardFinishPanel1.Location = new Point(922, 50);
            cardFinishPanel1.Name = "cardFinishPanel1";
            cardFinishPanel1.Size = new Size(398, 132);
            cardFinishPanel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1429, 662);
            Controls.Add(cardFinishPanel1);
            Controls.Add(reserv1);
            Controls.Add(ColumnsPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseLeave += Form1_MouseLeave;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel ColumnsPanel;
        private Reserv reserv1;
        private CardFinishPanel cardFinishPanel1;
    }
}
