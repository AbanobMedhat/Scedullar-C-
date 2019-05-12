using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Allocation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*int[][] process; */int mSize; int countHole=0;
        int nSeg; int countProc=0; int countSeg = 0;
        /*string[][] names;*/ 
        List<int> sizeOfproc=new List<int>();
        List<int>holesAddress=new List<int>();
        List<int>holesSize=new List<int>();
        int x; string y; int totalHole = 0; int cntold = 0; int last_pos = 0; bool chk = false;
        bool chk2 = false; int last_old; int last_old2; bool chk3 = false; int cntholes = 0;
        List <List< Tuple<string ,int >>> t=new List<List<Tuple<string , int>>>();
        List<List<string>> names = new List<List<string>>();
        List<List<int>> segments = new List<List<int>>();
        List<Tuple<string ,int>>memory=new List<Tuple<string,int>>();
        List<Tuple<string, int>> played_memory = new List<Tuple<string, int>>();
        List<Tuple<int, string>> holoName = new List<Tuple<int, string>>();
        List<Tuple<string, int>> tempProc = new List<Tuple<string, int>>();
        List<List<int>> delloc = new List<List<int>>();
        List<List<int>> delold = new List<List<int>>();
        List<List<int>> delold2 = new List<List<int>>();
        //Tuple<int ,int> ho=new Tuple<int,int>();
         void display(List<Tuple<string, int>> additional_mem)
        {
            for (int i = 0; i < delloc.Count; i++)
            {
                delloc[i].Clear();
      
            }
            for (int i = 0; i < delold.Count; i++)
            {
                delold[i].Clear();

            }
            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
           
            for (int i = 0; i < additional_mem.Count; i++)
            {
                if (additional_mem[i].Item1.Substring(0, 1) == "p")
                {
                    int ay7aga = Convert.ToInt32(additional_mem[i].Item1.Substring(1, 1));
                    delloc[ay7aga].Add(i);
 
                }
                if (additional_mem[i].Item1.Substring(0, 1) == "o")
                {
                    int ay2 = Convert.ToInt32(additional_mem[i].Item1.Substring(8, 1));
                    delold[ay2].Add(i);
                }
                chart1.Series.Add(additional_mem[i].Item1);
                chart1.Series[additional_mem[i].Item1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                chart1.Series[additional_mem[i].Item1].Points.AddXY("my mem", additional_mem[i].Item2);
                chart1.Series[additional_mem[i].Item1].IsValueShownAsLabel = true;
                  
            }
            
        }
         void fstFit(List<int> holAdd, List<int> holSize, List<List<Tuple<string, int>>> t, List<int> sizeOfproc, List<Tuple<string, int>> actMemory)
         {
             int total = totalHole;
             for (int i = 0; i < countProc; i++)
             {
                 
                         for (int j = 0; j < t[i].Count; j++)
                         {


                             for (int k = 0; k < actMemory.Count; k++)
                             {
                                 if (actMemory[k].Item1.Length > 3)
                                 {
                                     string s = actMemory[k].Item1.Substring(0, 3);
                                     if (s == "hol")
                                     {
                                         if (t[i][j].Item2 <= actMemory[k].Item2)
                                         {
                                             int remHole = actMemory[k].Item2 - t[i][j].Item2;
                                             total -= t[i][j].Item2;

                                             string nimo = actMemory[k].Item1;
                                             actMemory.RemoveAt(k);
                                             Tuple<string, int> soso = new Tuple<string, int>(t[i][j].Item1, t[i][j].Item2);
                                             actMemory.Insert(k, soso);
                                             
                                             if (remHole > 0)
                                             {
                                                 Tuple<string, int> zezo = new Tuple<string, int>(nimo, remHole);
                                                 actMemory.Insert(k + 1, zezo);
                                             }
                                             break;
                                         }


                                     }
                                 
                             }
                         }
                     }
                    
                 }

             played_memory.Clear();
             played_memory = actMemory.ToList();
             display(actMemory);
         }
         void bestFit(List<int> holAdd, List<Tuple<int,string>>holoName, List<List<Tuple<string, int>>> t, List<int> sizeOfproc, List<Tuple<string, int>> actMemory)
        {
            int total = totalHole;
           //sort list here
            holoName.Sort();

            for (int i = 0; i < countProc; i++)
            {
                if (sizeOfproc[i] <= total)
                {
                    for (int j = 0; j < t[i].Count; j++)
                    {
                        for (int k = 0; k < countHole; k++)
                        {
                            if (t[i][j].Item2 <= holoName[k].Item1)
                            {
                                Tuple<string, int> tot = new Tuple<string, int>(holoName[k].Item2,holoName[k].Item1 );
                                int q = actMemory.IndexOf(tot);
                                int remHole = actMemory[q].Item2 - t[i][j].Item2;
                                string nimo = actMemory[q].Item1;
                                actMemory.RemoveAt(q);
                                holoName.RemoveAt(k);

                                Tuple<string, int> soso = new Tuple<string, int>(t[i][j].Item1, t[i][j].Item2);
                                actMemory.Insert(q, soso);
                                if (remHole > 0)
                                {
                                    Tuple<string, int> zezo = new Tuple<string, int>(nimo, remHole);
                                    Tuple<int, string> ziko = new Tuple<int, string>(remHole, nimo);
                                    actMemory.Insert(q + 1, zezo);
                                    holoName.Insert(k,ziko);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            played_memory.Clear();
            played_memory = actMemory.ToList();
            display(actMemory);
        }
         void worstFit(List<int> holAdd, List<Tuple<int, string>> holoName, List<List<Tuple<string, int>>> t, List<int> sizeOfproc, List<Tuple<string, int>> actMemory)
        {
            int total = totalHole;
            //sort list here
            holoName.Sort();

            for (int i = 0; i < countProc; i++)
            {
                if (sizeOfproc[i] <= total)
                {
                    for (int j = 0; j < t[i].Count; j++)
                    {
                        for (int k = countHole-1; k >= 0; k--)
                        {
                            if (t[i][j].Item2 <= holoName[k].Item1)
                            {
                                Tuple<string, int> tot = new Tuple<string, int>(holoName[k].Item2, holoName[k].Item1);
                                int q = actMemory.IndexOf(tot);
                                int remHole = actMemory[q].Item2 - t[i][j].Item2;
                                string nimo = actMemory[q].Item1;
                                actMemory.RemoveAt(q);
                                holoName.RemoveAt(k);

                                Tuple<string, int> soso = new Tuple<string, int>(t[i][j].Item1, t[i][j].Item2);
                                actMemory.Insert(q, soso);
                                if (remHole > 0)
                                {
                                    Tuple<string, int> zezo = new Tuple<string, int>(nimo, remHole);
                                    Tuple<int, string> ziko = new Tuple<int, string>(remHole, nimo);
                                    actMemory.Insert(q + 1, zezo);
                                    holoName.Insert(k, ziko);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            played_memory.Clear();
            played_memory = actMemory.ToList();
            display(actMemory);
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(memSize.Text) == "")
            {
                MessageBox.Show("please enter memory size ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(memSize.Text)<=0)
            {
                MessageBox.Show("Neg or zero values are not allowed here ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mSize = Convert.ToInt32(memSize.Text);
                memSize.Text = "";
                button1.Enabled = false;
                addHole.Enabled = true;
                
            }
        }

        private void addHole_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToString(holeAdd.Text) == "")
            {
                MessageBox.Show("please enter hole Address ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToString(holeSize.Text) == "")
            {
                MessageBox.Show("please enter hole size ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                int te1 = (Convert.ToInt32(holeAdd.Text));
                int te2 = (Convert.ToInt32(holeSize.Text));
                 if(te1<=0||te2<=0)
                {
                    MessageBox.Show("Neg or zero values are  not allowed here ", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                 else if (te1 + te2 <= mSize)
                {
                    fshHoles.Enabled = true;
                    holesAddress.Add(Convert.ToInt32(holeAdd.Text));
                    holesSize.Add(Convert.ToInt32(holeSize.Text));
                    totalHole += Convert.ToInt32(holeSize.Text);
                    countHole++;
                    holeAdd.Text = "";
                    holeSize.Text = "";
                }
                
                else if(te1>=mSize)
                {
                    MessageBox.Show("your address out of range ", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    MessageBox.Show("hole is out of range ", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
 
                }
            }
        }

        private void addNofSeg_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(nofSeg.Text) == "")
            {
                MessageBox.Show("please enter No of Segments ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if((Convert.ToInt32(nofSeg.Text))<=0)
            {
                MessageBox.Show("Neg or zero values are not allowed here ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            else
            {
                nSeg = Convert.ToInt32(nofSeg.Text);
                nofSeg.Text = "";
                nofSeg.Enabled = false;
                addNofSeg.Enabled = false;
                addSeg.Enabled = true;

            }
        }

        private void addSeg_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(segName.Text) == "")
            {
                MessageBox.Show("please enter Segment Name ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToString(segSize.Text) == "")
            {
                MessageBox.Show("please enter Segment Size ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Convert.ToInt32(segSize.Text))<=0)
            {
                MessageBox.Show("Neg or zero values are not allowed here ", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<int> temp_holes = new List<int>(holesSize);

                if (countSeg < nSeg)
                {

                    tempProc.Add(new Tuple<string, int>("p" + Convert.ToString(countProc) + ":" + Convert.ToString(segName.Text), Convert.ToInt32(segSize.Text)));
                    countSeg++;
                }
                segName.Text = "";
                segSize.Text = "";
                if (countSeg == nSeg)
                {
                    addProc.Enabled = true;
                    addSeg.Enabled = false;
                }
            }
        }
        private void addProc_Click(object sender, EventArgs e)
        {
            firstFit.Enabled = true;
            wstFit.Enabled = true;
            btFit.Enabled = true;
            addProc.Enabled = false;
            int sProc = 0; bool x = false;
            for (int i = 0; i < tempProc.Count; i++)
            {
                sProc += tempProc[i].Item2;
            }

            if (sProc <= totalHole)
            {
                List<int> copyHole = new List<int>(holesSize);
                for (int i = 0; i < tempProc.Count; i++)
                {
                   
                     x = false;
                    for (int y = 0; y < copyHole.Count; y++)
                    {

                        //string s1 = actMemory[y].Item1.Substring(0, 3);

                        if (tempProc[i].Item2 <= copyHole[y])
                        {
                            int remHole = copyHole[y] - tempProc[i].Item2;
                            copyHole.RemoveAt(y);
                            if (remHole > 0)
                                copyHole.Insert(y, remHole);
                            x = true;
                            break;
                        }
                    }
                    if (!x)
                        break;
                }
            }
            if (x)
            {
                sizeOfproc.Add(0);
                for (int i = 0; i < countSeg; i++)
                {
                    sizeOfproc[countProc] += tempProc[i].Item2;
                }
                List<Tuple<string, int>> tempProc2 = new List<Tuple<string, int>>(tempProc);
                t.Add(tempProc2);
                countSeg = 0;
                List<int> teetetet = new List<int>();
                comb.Items.Add("p" + Convert.ToString(countProc));
                delloc.Add(teetetet);
                tempProc.Clear();
                countProc++;
                nofSeg.Enabled = true;
                addNofSeg.Enabled = true;
            }
            else
            {
                MessageBox.Show("there is no space for segment ", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                tempProc.Clear();
                countSeg = 0;
                nofSeg.Enabled = true;
                addNofSeg.Enabled = true;
 
            }
        }
        private void firstFit_Click(object sender, EventArgs e)
        {
            List<Tuple<string, int>> add_memo = new List<Tuple<string, int>>(memory);
            fstFit(holesAddress, holesSize, t, sizeOfproc, add_memo);

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = mSize;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            for(int i=0;i<countHole;i++)
            {
                chart1.Series.Add("hole" + Convert.ToString(i));
                chart1.Series["hole" + Convert.ToString(i)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                chart1.Series["hole" + Convert.ToString(i)].Points.AddXY("my mem", holesSize[i]);
                chart1.Series["hole" + Convert.ToString(i)].IsValueShownAsLabel = true;

            }
            
        }

        private void fshHoles_Click(object sender, EventArgs e)
        {
            addHole.Enabled = false;
            fshHoles.Enabled = false;
            addNofSeg.Enabled = true;
            dell.Enabled = true;
            diso.Enabled = true;
            int start = 0; int i = 0; int k = 0;
            chart1.ChartAreas[0].AxisY.Maximum = mSize;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            
            delold2.Clear();
 
            
            for (i = 0; i < countHole; i++)
            {
                if (holesAddress[i] > start)
                {
                    chart1.Series.Add("old_proc" + Convert.ToString(k));
                    chart1.Series["old_proc" + Convert.ToString(k)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    chart1.Series["old_proc" + Convert.ToString(k)].Points.AddXY("my mem", holesAddress[i] - start);
                    chart1.Series["old_proc" + Convert.ToString(k)].IsValueShownAsLabel = true;
                    memory.Add(new Tuple<string, int>("old_proc" + Convert.ToString(k), holesAddress[i] - start));
                    start = holesAddress[i]+holesSize[i];
                    List<int> totototo = new List<int>();
                    delold2.Add(totototo);
                    delold2[delold2.Count - 1].Add(memory.Count - 1);
                    comb.Items.Add("old_proc" + Convert.ToString(k));
                    List<int> kano = new List<int>();
                    delold.Add(kano);
                    cntold++;
                    chart1.Series.Add("hole" + Convert.ToString(i));
                    chart1.Series["hole" + Convert.ToString(i)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    chart1.Series["hole" + Convert.ToString(i)].Points.AddXY("my mem", holesSize[i]);
                    chart1.Series["hole" + Convert.ToString(i)].IsValueShownAsLabel = true;
                    memory.Add(new Tuple<string, int>("hole" + Convert.ToString(i), holesSize[i]));
                    holoName.Add(new Tuple<int, string>(holesSize[i], "hole" + Convert.ToString(i)));
                    k++;
                }
                else
                {
                    chart1.Series.Add("hole" + Convert.ToString(i));
                    chart1.Series["hole" + Convert.ToString(i)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                    chart1.Series["hole" + Convert.ToString(i)].Points.AddXY("my mem", holesSize[i]);
                    chart1.Series["hole" + Convert.ToString(i)].IsValueShownAsLabel = true;
                    memory.Add(new Tuple<string, int>("hole" + Convert.ToString(i), holesSize[i]));
                    holoName.Add(new Tuple<int, string>(holesSize[i], "hole" + Convert.ToString(i)));
                }
            }
            
            if ((holesAddress[countHole-1]+holesSize[countHole-1]) < mSize)
            {
                chart1.Series.Add("old_proc" + Convert.ToString(k));
                chart1.Series["old_proc" + Convert.ToString(k)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                chart1.Series["old_proc" + Convert.ToString(k)].Points.AddXY("my mem", mSize - (holesAddress[countHole - 1] + holesSize[countHole - 1]));
                chart1.Series["old_proc" + Convert.ToString(k)].IsValueShownAsLabel = true;
                List<int> kano = new List<int>();
                delold.Add(kano);
                cntold++;
                memory.Add(new Tuple<string, int>("old_proc" + Convert.ToString(k), mSize - (holesAddress[countHole - 1] + holesSize[countHole - 1])));
                List<int> totototo = new List<int>();
                delold2.Add(totototo);
                delold2[delold2.Count - 1].Add(memory.Count - 1);
            }
            played_memory.Clear();
            played_memory = memory.ToList();
            cntholes = countHole;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

       

        private void btFit_Click(object sender, EventArgs e)
        {
            List<Tuple<string, int>> add_memo = new List<Tuple<string, int>>(memory);
            List<Tuple<int, string>> copyholo = new List<Tuple<int, string>>(holoName);
            bestFit(holesAddress, copyholo, t, sizeOfproc, add_memo);
        }

        private void wstFit_Click(object sender, EventArgs e)
        {
            List<Tuple<string, int>> add_memo = new List<Tuple<string, int>>(memory);
            List<Tuple<int, string>> copyholo = new List<Tuple<int, string>>(holoName);
            worstFit(holesAddress, copyholo, t, sizeOfproc, add_memo);
        }

        private void dell_Click(object sender, EventArgs e)
        {

            int index = comb.SelectedIndex; int exactind; int exactmem;
            string sosos = comb.Text;
            if (sosos == "")
            {
                MessageBox.Show("please enter Process Name ", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int addo = 0;
                if (sosos.Substring(0, 1) == "p")
                {
                    int pos = Convert.ToInt32(sosos.Substring(1, 1));
                    for (int j = 0; j < delloc[pos].Count; j++)
                    {
                        addo = 0;
                        exactind = delloc[pos][j];
                        for (int i = 0; i < exactind; i++)
                        {
                            addo += played_memory[i].Item2;
                        }
                        int sizo = played_memory[exactind].Item2;
                        cntholes++;
                        Tuple<string, int> tempo = new Tuple<string, int>("hole" + Convert.ToString(cntholes), sizo);
                        played_memory.RemoveAt(delloc[pos][j]);
                        played_memory.Insert(exactind, tempo);


                    }
                    if (chk)
                    {
                        if (last_pos < pos)
                            pos--;
                    }
                    t.RemoveAt(pos);
                    countProc--;
                    chk = true;
                    last_pos = pos;
                    comb.Items.Remove(comb.SelectedItem);
                }
                else
                {
                    int pos = Convert.ToInt32(sosos.Substring(8, 1));

                    for (int j = 0; j < delold[pos].Count; j++)
                    {
                        addo = 0;
                        exactind = delold[pos][j];
                        exactmem = delold2[pos][j];
                        for (int i = 0; i < exactind; i++)
                        {
                            addo += played_memory[i].Item2;
                        }
                        int sizo = played_memory[exactind].Item2;
                        cntholes++;
                        countHole++;
                        Tuple<string, int> tempo = new Tuple<string, int>("hole" + Convert.ToString(cntholes), sizo);
                        holesAddress.Add(addo);
                        holesSize.Add(sizo);
                        holoName.Add(new Tuple<int, string>(sizo, "hole" + Convert.ToString(cntholes)));
                        /*  if (chk2)
                          {
                              if (last_old < exactind)
                                  exactind--;
                              if (last_old2 < exactmem)
                                  exactmem--;
                          }*/
                        memory.RemoveAt(exactmem);
                        memory.Insert(exactmem, tempo);
                        played_memory.RemoveAt(exactind);
                        played_memory.Insert(exactind, tempo);

                        cntold--;
                        last_old = exactind;
                        chk2 = true;
                        last_old2 = exactmem;
                        chk3 = true;
                        comb.Items.Remove(comb.SelectedItem);
                    }
                }
                /*  for(int i=0;i<index;i++)
                  {
                      addo+=memory[i].Item2;
                  }
                  int sizo= memory[index].Item2;
                  countHole++;
                  Tuple<string,int>tempo=new Tuple<string,int>("hole"+Convert.ToString(countHole),sizo);
                  holesAddress.Add(addo);
                  holesSize.Add(sizo);
                  memory.RemoveAt(index);
                  memory.Insert(index, tempo);   
                 */
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void diso_Click(object sender, EventArgs e)
        {
            display(played_memory);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            addHole.Enabled = false;
            fshHoles.Enabled = false;
            addNofSeg.Enabled = false;
            addProc.Enabled = false;
            addSeg.Enabled = false;
            firstFit.Enabled = false;
            wstFit.Enabled = false;
            btFit.Enabled = false;
            dell.Enabled = false;
            diso.Enabled = false;
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void memSize_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       



    }
}
