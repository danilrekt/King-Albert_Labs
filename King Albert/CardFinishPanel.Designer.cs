namespace King_Albert
{
    partial class CardFinishPanel
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            cardFinishStack1 = new CardFinishStack();
            cardFinishStack2 = new CardFinishStack();
            cardFinishStack3 = new CardFinishStack();
            cardFinishStack4 = new CardFinishStack();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cardFinishStack1);
            flowLayoutPanel1.Controls.Add(cardFinishStack2);
            flowLayoutPanel1.Controls.Add(cardFinishStack3);
            flowLayoutPanel1.Controls.Add(cardFinishStack4);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(396, 127);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // cardFinishStack1
            // 
            cardFinishStack1.BorderStyle = BorderStyle.FixedSingle;
            cardFinishStack1.Location = new Point(5, 3);
            cardFinishStack1.Margin = new Padding(5, 3, 3, 3);
            cardFinishStack1.Name = "cardFinishStack1";
            cardFinishStack1.Size = new Size(90, 120);
            cardFinishStack1.TabIndex = 0;
            cardFinishStack1.MouseMove += cardFinishStack_MouseMove;
            cardFinishStack1.MouseUp += cardFinishStack_MouseUp;
            // 
            // cardFinishStack2
            // 
            cardFinishStack2.BorderStyle = BorderStyle.FixedSingle;
            cardFinishStack2.Location = new Point(103, 3);
            cardFinishStack2.Margin = new Padding(5, 3, 3, 3);
            cardFinishStack2.Name = "cardFinishStack2";
            cardFinishStack2.Size = new Size(90, 120);
            cardFinishStack2.TabIndex = 1;
            cardFinishStack2.MouseMove += cardFinishStack_MouseMove;
            cardFinishStack2.MouseUp += cardFinishStack_MouseUp;
            // 
            // cardFinishStack3
            // 
            cardFinishStack3.BorderStyle = BorderStyle.FixedSingle;
            cardFinishStack3.Location = new Point(201, 3);
            cardFinishStack3.Margin = new Padding(5, 3, 3, 3);
            cardFinishStack3.Name = "cardFinishStack3";
            cardFinishStack3.Size = new Size(90, 120);
            cardFinishStack3.TabIndex = 2;
            cardFinishStack3.MouseMove += cardFinishStack_MouseMove;
            cardFinishStack3.MouseUp += cardFinishStack_MouseUp;
            // 
            // cardFinishStack4
            // 
            cardFinishStack4.BorderStyle = BorderStyle.FixedSingle;
            cardFinishStack4.Location = new Point(299, 3);
            cardFinishStack4.Margin = new Padding(5, 3, 3, 3);
            cardFinishStack4.Name = "cardFinishStack4";
            cardFinishStack4.Size = new Size(90, 120);
            cardFinishStack4.TabIndex = 3;
            cardFinishStack4.MouseMove += cardFinishStack_MouseMove;
            cardFinishStack4.MouseUp += cardFinishStack_MouseUp;
            // 
            // CardFinishPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "CardFinishPanel";
            Size = new Size(396, 127);
            Load += CardFinishPanel_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private CardFinishStack cardFinishStack1;
        private CardFinishStack cardFinishStack2;
        private CardFinishStack cardFinishStack3;
        private CardFinishStack cardFinishStack4;
    }
}
