namespace Memory_Allocation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.memSize = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.holeSize = new System.Windows.Forms.TextBox();
            this.holeAdd = new System.Windows.Forms.TextBox();
            this.addHole = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.nofSeg = new System.Windows.Forms.TextBox();
            this.addNofSeg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.segName = new System.Windows.Forms.TextBox();
            this.segSize = new System.Windows.Forms.TextBox();
            this.addSeg = new System.Windows.Forms.Button();
            this.listView5 = new System.Windows.Forms.ListView();
            this.firstFit = new System.Windows.Forms.Button();
            this.addProc = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fshHoles = new System.Windows.Forms.Button();
            this.btFit = new System.Windows.Forms.Button();
            this.wstFit = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.comb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dell = new System.Windows.Forms.Button();
            this.diso = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Highlight;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 128);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Mem Size";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Total Size";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // memSize
            // 
            this.memSize.Location = new System.Drawing.Point(28, 55);
            this.memSize.Name = "memSize";
            this.memSize.Size = new System.Drawing.Size(100, 20);
            this.memSize.TabIndex = 4;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.Highlight;
            this.listView2.Location = new System.Drawing.Point(256, 12);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(340, 128);
            this.listView2.TabIndex = 5;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Holes Size";
            // 
            // holeSize
            // 
            this.holeSize.Location = new System.Drawing.Point(409, 55);
            this.holeSize.Name = "holeSize";
            this.holeSize.Size = new System.Drawing.Size(100, 20);
            this.holeSize.TabIndex = 8;
            // 
            // holeAdd
            // 
            this.holeAdd.Location = new System.Drawing.Point(290, 55);
            this.holeAdd.Name = "holeAdd";
            this.holeAdd.Size = new System.Drawing.Size(100, 20);
            this.holeAdd.TabIndex = 9;
            // 
            // addHole
            // 
            this.addHole.Location = new System.Drawing.Point(301, 97);
            this.addHole.Name = "addHole";
            this.addHole.Size = new System.Drawing.Size(89, 27);
            this.addHole.TabIndex = 10;
            this.addHole.Text = "Add Hole";
            this.addHole.UseVisualStyleBackColor = true;
            this.addHole.Click += new System.EventHandler(this.addHole_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Holes Address";
            // 
            // listView4
            // 
            this.listView4.BackColor = System.Drawing.SystemColors.Highlight;
            this.listView4.Location = new System.Drawing.Point(12, 161);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(584, 162);
            this.listView4.TabIndex = 13;
            this.listView4.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "No of Segments";
            // 
            // nofSeg
            // 
            this.nofSeg.Location = new System.Drawing.Point(28, 209);
            this.nofSeg.Name = "nofSeg";
            this.nofSeg.Size = new System.Drawing.Size(100, 20);
            this.nofSeg.TabIndex = 15;
            // 
            // addNofSeg
            // 
            this.addNofSeg.Location = new System.Drawing.Point(28, 248);
            this.addNofSeg.Name = "addNofSeg";
            this.addNofSeg.Size = new System.Drawing.Size(115, 23);
            this.addNofSeg.TabIndex = 16;
            this.addNofSeg.Text = "Add No of Segments";
            this.addNofSeg.UseVisualStyleBackColor = true;
            this.addNofSeg.Click += new System.EventHandler(this.addNofSeg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Segment Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Segment Size";
            // 
            // segName
            // 
            this.segName.Location = new System.Drawing.Point(290, 209);
            this.segName.Name = "segName";
            this.segName.Size = new System.Drawing.Size(100, 20);
            this.segName.TabIndex = 19;
            // 
            // segSize
            // 
            this.segSize.Location = new System.Drawing.Point(432, 209);
            this.segSize.Name = "segSize";
            this.segSize.Size = new System.Drawing.Size(100, 20);
            this.segSize.TabIndex = 20;
            // 
            // addSeg
            // 
            this.addSeg.Location = new System.Drawing.Point(383, 248);
            this.addSeg.Name = "addSeg";
            this.addSeg.Size = new System.Drawing.Size(126, 23);
            this.addSeg.TabIndex = 21;
            this.addSeg.Text = "Add segment";
            this.addSeg.UseVisualStyleBackColor = true;
            this.addSeg.Click += new System.EventHandler(this.addSeg_Click);
            // 
            // listView5
            // 
            this.listView5.BackColor = System.Drawing.SystemColors.Highlight;
            this.listView5.Location = new System.Drawing.Point(12, 329);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(584, 169);
            this.listView5.TabIndex = 22;
            this.listView5.UseCompatibleStateImageBehavior = false;
            // 
            // firstFit
            // 
            this.firstFit.Location = new System.Drawing.Point(44, 404);
            this.firstFit.Name = "firstFit";
            this.firstFit.Size = new System.Drawing.Size(75, 23);
            this.firstFit.TabIndex = 23;
            this.firstFit.Text = "First Fit";
            this.firstFit.UseVisualStyleBackColor = true;
            this.firstFit.Click += new System.EventHandler(this.firstFit_Click);
            // 
            // addProc
            // 
            this.addProc.Enabled = false;
            this.addProc.Location = new System.Drawing.Point(186, 248);
            this.addProc.Name = "addProc";
            this.addProc.Size = new System.Drawing.Size(146, 45);
            this.addProc.TabIndex = 26;
            this.addProc.Text = "Add process";
            this.addProc.UseVisualStyleBackColor = true;
            this.addProc.Click += new System.EventHandler(this.addProc_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(634, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(371, 352);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // fshHoles
            // 
            this.fshHoles.Location = new System.Drawing.Point(409, 93);
            this.fshHoles.Name = "fshHoles";
            this.fshHoles.Size = new System.Drawing.Size(92, 31);
            this.fshHoles.TabIndex = 29;
            this.fshHoles.Text = "Finish Holes";
            this.fshHoles.UseVisualStyleBackColor = true;
            this.fshHoles.Click += new System.EventHandler(this.fshHoles_Click);
            // 
            // btFit
            // 
            this.btFit.Location = new System.Drawing.Point(409, 404);
            this.btFit.Name = "btFit";
            this.btFit.Size = new System.Drawing.Size(75, 23);
            this.btFit.TabIndex = 30;
            this.btFit.Text = "BestFit";
            this.btFit.UseVisualStyleBackColor = true;
            this.btFit.Click += new System.EventHandler(this.btFit_Click);
            // 
            // wstFit
            // 
            this.wstFit.Location = new System.Drawing.Point(225, 444);
            this.wstFit.Name = "wstFit";
            this.wstFit.Size = new System.Drawing.Size(75, 23);
            this.wstFit.TabIndex = 31;
            this.wstFit.Text = "WorstFit";
            this.wstFit.UseVisualStyleBackColor = true;
            this.wstFit.Click += new System.EventHandler(this.wstFit_Click);
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.SystemColors.Highlight;
            this.listView3.Location = new System.Drawing.Point(634, 370);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(386, 127);
            this.listView3.TabIndex = 32;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // comb
            // 
            this.comb.FormattingEnabled = true;
            this.comb.Location = new System.Drawing.Point(643, 406);
            this.comb.Name = "comb";
            this.comb.Size = new System.Drawing.Size(121, 21);
            this.comb.TabIndex = 33;
            this.comb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Highlight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(639, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Delallocated process";
            // 
            // dell
            // 
            this.dell.Location = new System.Drawing.Point(808, 404);
            this.dell.Name = "dell";
            this.dell.Size = new System.Drawing.Size(125, 23);
            this.dell.TabIndex = 35;
            this.dell.Text = "Deallocate";
            this.dell.UseVisualStyleBackColor = true;
            this.dell.Click += new System.EventHandler(this.dell_Click);
            // 
            // diso
            // 
            this.diso.Location = new System.Drawing.Point(808, 464);
            this.diso.Name = "diso";
            this.diso.Size = new System.Drawing.Size(125, 23);
            this.diso.TabIndex = 38;
            this.diso.Text = "Display";
            this.diso.UseVisualStyleBackColor = true;
            this.diso.Click += new System.EventHandler(this.diso_Click);
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(643, 444);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(121, 43);
            this.restart.TabIndex = 39;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1065, 529);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.diso);
            this.Controls.Add(this.dell);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comb);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.wstFit);
            this.Controls.Add(this.btFit);
            this.Controls.Add(this.fshHoles);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.addProc);
            this.Controls.Add(this.firstFit);
            this.Controls.Add(this.listView5);
            this.Controls.Add(this.addSeg);
            this.Controls.Add(this.segSize);
            this.Controls.Add(this.segName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addNofSeg);
            this.Controls.Add(this.nofSeg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addHole);
            this.Controls.Add(this.holeAdd);
            this.Controls.Add(this.holeSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.memSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox memSize;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox holeSize;
        private System.Windows.Forms.TextBox holeAdd;
        private System.Windows.Forms.Button addHole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nofSeg;
        private System.Windows.Forms.Button addNofSeg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox segName;
        private System.Windows.Forms.TextBox segSize;
        private System.Windows.Forms.Button addSeg;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.Button firstFit;
        private System.Windows.Forms.Button addProc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button fshHoles;
        private System.Windows.Forms.Button btFit;
        private System.Windows.Forms.Button wstFit;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ComboBox comb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button dell;
        private System.Windows.Forms.Button diso;
        private System.Windows.Forms.Button restart;
    }
}

