using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Sceduller
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> input_process = new List<int>();
        //list for arrival time
        List<int> input_burst = new List<int>();
        //list for burst time 
        List<int> input_priority = new List<int>();
        //list of priority 
        // each one has index of the process
        int zezo = 0;
        
        List<int> id = new List<int>();
        void jop_first(List<int> input_process, List<int> input_burst)
        {
            int begin = 0, end = 0, cnt; float wat = 0, tar=0;
            cnt = input_process.Count;
            List<int> no_process = new List<int>();
            for (int ii = 0; ii < cnt; ii++)
            {
                no_process.Add(ii);
            }
            int index = 0, i = 0; int nob=input_process.Count;
            while (input_process.Count != 0)
            {

                int j = 0;
                index = 0; int min = index;
                if (input_process.Count != 1)
                {
                    while (input_process[j] <= begin && input_process[j + 1] <= begin)
                    {
                        if (input_burst[j + 1] < input_burst[j])
                        {
                            min = (j + 1) % input_process.Count;
                            if (j == 0)
                                index = min;
                            if (input_burst[min] < input_burst[index])
                                index = min;
                        }
                        j++;
                        if (j + 1 >= input_process.Count)
                            break;
                    }
                }
                if (begin >= input_process[index])
                {
                    wat += (begin - input_process[index]);
                    end += input_burst[index];
                    chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                    begin = end;
                    tar += (end - input_process[index]);
                    input_process.RemoveAt(index);
                    input_burst.RemoveAt(index);
                    no_process.RemoveAt(index);

                    i++;
                }
                else
                {
                    begin = input_process[index];
                    wat += (begin - input_process[index]);
                    end =begin+ input_burst[index];
                    chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                    begin = end;
                    tar += (end - input_process[index]);
                    input_process.RemoveAt(index);
                    input_burst.RemoveAt(index);
                    no_process.RemoveAt(index);

                    i++;
                }
            }
            if(nob!=0)
            {
                wat = wat / (float)nob;
                tar = tar / (float)nob;
                wait.Text = Convert.ToString(wat);
                turn.Text = Convert.ToString(tar);

            }
        }
        void preemptive_job(List<int> input_process, List<int> input_burst, List<int> copy_input)
        {
            int begin = 0, end = 0, cnt; float wat = 0, tar = 0;
            cnt = input_process.Count;

            List<int> no_process = new List<int>();
            for (int ii = 0; ii < cnt; ii++)
            {
                no_process.Add(ii);
            }
            int index = 0, i = 0; int nob = input_process.Count; int exp = input_process[input_process.Count - 1];
            int z = 0;
            while (input_process.Count != 0)
            {

                int j = 0;
                index = 0;int min=index;
                if (input_process.Count != 1)
                {
                    while (input_process[j] <= begin && input_process[j + 1] <= begin)
                    {
                        if (input_burst[j + 1] < input_burst[j])
                        {
                            min=(j+1)%input_process.Count;
                            if (j == 0)
                                index = min;
                            if (input_burst[min] < input_burst[index])
                                index = min;
                        }
                        j++;
                        if (j + 1 >= input_process.Count)
                            break;
                    }
                }
                if (begin >= input_process[index])
                {
                    wat += (begin - input_process[index]);
                    if (begin < exp)
                    {
                        if ((input_burst[index] + begin) > input_process[z + 1])
                        {
                            end = input_process[z + 1];
                            input_burst[index] -= (end - begin);
                        }
                        else
                        {
                            end +=input_burst[index];
                            input_burst[index] -= (end - begin);
                            z--;
                        }
                    }
                    else
                    {
                        end += input_burst[index];
                        input_burst[index] -= (end - begin);
                    }
                    chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                    begin = end;
                    tar += (end - copy_input[index]);
                    if (input_burst[index] == 0)
                    {
                        input_process.RemoveAt(index);
                        input_burst.RemoveAt(index);
                        no_process.RemoveAt(index);
                        copy_input.RemoveAt(index);
                        z--;
                    }
                    else 
                    {
                        input_process[index] = end;
                    }
                    i++;
                }
                else
                {
                    begin = input_process[index];
                    wat += (begin - input_process[index]);
                    end = begin + input_burst[index];
                    chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                    begin = end;
                    tar += (end - copy_input[index]);
                    input_process.RemoveAt(index);
                    input_burst.RemoveAt(index);
                    no_process.RemoveAt(index);
                    copy_input.RemoveAt(index);
                    i++;
                }
                z++;
            }
            if (nob != 0)
            {
                wat = wat / (float)nob;
                tar = tar / (float)nob;
                wait.Text = Convert.ToString(wat);
                turn.Text = Convert.ToString(tar);

            }
        }
        void preemptive_Priority(List<int> input_process, List<int> input_burst, List<int> priority, List<int> copy_input)
        {
            int begin = 0, end = 0, cnt; float wat = 0, tar = 0;
            cnt = input_process.Count;
            List<int> no_process = new List<int>();
            for (int ii = 0; ii < cnt; ii++)
            {
                no_process.Add(ii);
            }
            int index = 0, i = 0; int nob = input_process.Count; int exp = input_process[input_process.Count - 1];
            int z = 0;
            while (input_process.Count != 0)
            {

                int j = 0;
                index = 0; int min = index;
                if (input_process.Count != 1)
                {
                    while (input_process[j] <= begin && input_process[j + 1] <= begin)
                    {
                        if (priority[j + 1] < priority[j])
                        {
                            index = (j + 1) % input_process.Count;
                            if (j == 0)
                                min = index;
                            if (priority[min] > priority[index])
                                min = index;
                        }
                        j++;
                        if (j + 1 >= input_process.Count)
                            break;
                    }
                }
                if (begin >= input_process[min])
                {
                    wat += (begin - input_process[min]);
                    if (begin < exp)
                    {
                        if ((input_burst[min] + begin) >= input_process[z + 1])
                        {
                            end = input_process[z + 1];
                            input_burst[min] -= (end - begin);
                        }
                        else
                        {
                            end += input_burst[min];
                            input_burst[min] -= (end - begin);
                            z--;
                        }
                    }
                    else
                    {
                        end += input_burst[min];
                        input_burst[min] -= (end - begin);
                    }
                    chart1.Series[0].Points.AddXY(no_process[min], begin, end);
                    begin = end;
                    tar += (end - copy_input[min]);
                    if (input_burst[min] == 0)
                    {
                        input_process.RemoveAt(min);
                        input_burst.RemoveAt(min);
                        no_process.RemoveAt(min);
                        priority.RemoveAt(min);
                        copy_input.RemoveAt(min);
                        z--;
                    }
                    else
                    {
                        input_process[min] = end;
                    }
                    i++;
                }
                else
                {
                    begin = input_process[min];
                    wat += (begin - input_process[min]);
                    end = begin + input_burst[min];
                    chart1.Series[0].Points.AddXY(no_process[min], begin, end);
                    begin = end;
                    tar += (end - copy_input[min]);
                    input_process.RemoveAt(min);
                    input_burst.RemoveAt(min);
                    no_process.RemoveAt(min);
                    priority.RemoveAt(min);
                    copy_input.RemoveAt(min);
                    i++;
                }
                z++;
            }
            if (nob != 0)
            {
                wat = wat / (float)nob;
                tar = tar / (float)nob;
                wait.Text = Convert.ToString(wat);
                turn.Text = Convert.ToString(tar);

            }
        }
        void round_robin(List<int> input_process, List<int> input_burst, int qm)
        {

            qm = Convert.ToInt32(quam.Text);

            List<int> rem_bt = new List<int>(input_burst);
            /////hast5dmha 3lshan a7sb el waiting time

            List<int> arrival_time = new List<int>(input_process);
            /////hast5dmha 3lshan a7sb el waiting time

            List<int> no_process = new List<int>();
            for (int ii = 0; ii < input_process.Count; ii++)
            {
                no_process.Add(ii);
            }
            float n = input_process.Count;
            int time = arrival_time[0];// hanbd2 mn awel process gatlna
            int end = 0;
            int remaining_burst = 0;
            int arrival_t = 0;
            float waiting_time = 0;
            float avg_waiting = 0;

            for (int i = 0; arrival_time.Count != 0; i++)
            {
                int begin = time; // hanbd2 mn el time el 2a5er elly we2fna 3ndo
                int min = arrival_time[0];
                int t = 0;

                for (int j = 1; j < arrival_time.Count; j++)
                {
                    if (arrival_time[j] < min)
                    {
                        min = arrival_time[j];
                        t = j;
                    }

                    else if (arrival_time[j] == min)
                    {
                        if (input_process[j] > input_process[t])
                        {
                            min = input_process[j];
                            t = j;
                        }

                        else
                            min = input_process[t];
                    }

                }// for loop least quantum time

                ///////////////////////////////////////////////////
                if (rem_bt[t] > 0)
                {
                    if (rem_bt[t] > qm)
                    {
                        // Increase the value of t i.e. 

                        time += qm;

                        // Decrease the burst_time of  current process by quantum 
                        remaining_burst = rem_bt[t] - qm;
                        rem_bt[t] = remaining_burst;


                        arrival_time[t] = time;

                        end = time;

                        chart1.Series[0].Points.AddXY(no_process[t], begin, end);
                    } //bta3et smaller if

                    else  // If burst time is smaller than or equal to quantum for this process 
                    {
                        time = time + rem_bt[t];  // Increase the value of t

                        waiting_time = waiting_time + (time - input_burst[t] - input_process[t]);

                        // As the process gets fully executed make its remaining burst time = 0  

                        rem_bt[t] = 0;
                        end = time;
                        chart1.Series[0].Points.AddXY(no_process[t], begin, end);
                        ///// hanshelha mn kol el lists elly 3mlnaha
                        rem_bt.RemoveAt(t);
                        input_burst.RemoveAt(t);

                        arrival_time.RemoveAt(t);
                        input_process.RemoveAt(t);

                        no_process.RemoveAt(t);

                    } // bta3et el else burst time is smaller than or equal to quantum for this process

                }// bta3et larger if remaining_burst >0


                ///////////////////////////////////////////////////////
            }// bta3et el for loop of i
            avg_waiting = waiting_time / n;
            wait.Text = Convert.ToString(avg_waiting);
        }/// bta3t el void fn
        void priority_first(List<int> input_process, List<int> input_burst, List<int>priority)
        {
            int begin = 0, end = 0, cnt; float wat = 0, tar = 0;
            cnt = input_process.Count;
            List<int> no_process = new List<int>();
            for (int ii = 0; ii < cnt; ii++)
            {
                no_process.Add(ii);
            }
            int index = 0, i = 0; int nob = input_process.Count;
            while (input_process.Count != 0)
            {

                int j = 0;
                index = 0; int min = index;
                if (input_process.Count != 1)
                {
                    while (input_process[j] <= begin && input_process[j + 1] <= begin)
                    {
                        if (priority[j + 1] < priority[j])
                        {
                            min = (j + 1) % input_process.Count;
                            if (j == 0)
                                index = min;
                            if (priority[min] < priority[index])
                                index = min;
                        }
                        j++;
                        if (j + 1 >= input_process.Count)
                            break;
                    }
                }
                if (begin >= input_process[index])
                {
                    wat += (begin - input_process[index]);
                    end += input_burst[index];
                    chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                    begin = end;
                    tar += (end - input_process[index]);
                    input_process.RemoveAt(index);
                    input_burst.RemoveAt(index);
                    no_process.RemoveAt(index);
                    priority.RemoveAt(index);
                    i++;
                }
                else
                {
                    begin = input_process[index];
                    wat += (begin - input_process[index]);
                    end = begin + input_burst[index];
                    chart1.Series[0].Points.AddXY(no_process[index], begin, end);
                    begin = end;
                    tar += (end - input_process[index]);
                    input_process.RemoveAt(index);
                    input_burst.RemoveAt(index);
                    no_process.RemoveAt(index);
                    priority.RemoveAt(index);
                    i++;
                }
            }
            if (nob != 0)
            {
                wat = wat / (float)nob;
                tar = tar / (float)nob;
                wait.Text = Convert.ToString(wat);
                turn.Text = Convert.ToString(tar);

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void add_process_Click(object sender, EventArgs e)
        {
            
            if (arriv.Text == "")
            {
                MessageBox.Show("Please enter arrival time.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (burst.Text == "")
            {
                MessageBox.Show("Please enter burst time.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (priority.Text == "")
            {
                MessageBox.Show("Please enter priority time.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int x = Convert.ToInt32(arriv.Text);
                int y = Convert.ToInt32(burst.Text);
                int w = Convert.ToInt32(priority.Text);
                if (x < 0)
                {
                    MessageBox.Show("There is no time in -ve value ,please enter valid time .", "Fetal Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (y < 0)
                {
                    MessageBox.Show("There is no time in -ve value ,please enter valid time .", "Fetal Error",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (w < 0)
                {
                    MessageBox.Show("There is no priority in -ve value ,please enter valid periority .", "Fetal Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (input_process.Count == 0 || x >= input_process[input_process.Count - 1])
                    {
                        input_process.Add(Convert.ToInt32(arriv.Text));
                        input_burst.Add(Convert.ToInt32(burst.Text));
                        input_priority.Add(Convert.ToInt32(priority.Text));
                        zezo++;
                        proc.Text = Convert.ToString(zezo);
                    }
                    else
                    {
                        MessageBox.Show("Please enter arrival time higher than the pervious one.", "User Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            arriv.Clear();
            burst.Clear();
            priority.Clear();
            id.Clear();
        }

        private void FCFS_Click(object sender, EventArgs e)
        {
            float wat = 0, tar = 0;
            chart1.Series[0].Points.Clear();
            if (input_process.Count != 0)
            {
                int begin = 0, end = 0;
                for (int i = 0; i < input_process.Count; i++)
                {
                    if (begin >= input_process[i])
                    {
                        wat += (begin - input_process[i]);
                        end += input_burst[i];
                        chart1.Series[0].Points.AddXY(i, begin, end);
                        begin = end;
                        tar += (end - input_process[i]);
                    }
                    else 
                    {
                        begin = input_process[i];
                        wat += (begin - input_process[i]);
                        end =begin+ input_burst[i];
                        chart1.Series[0].Points.AddXY(i, begin, end);
                        begin = end;
                        tar += (end - input_process[i]);

                    }
                }
                wat = wat/(float)input_process.Count;
                tar = tar / (float)input_process.Count;
                wait.Text = Convert.ToString(wat);
                turn.Text = Convert.ToString(tar);
            }
            else 
            {
                MessageBox.Show("There are no processes to be scheduled please enter some processes.", "User Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SJF_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            if (input_process.Count != 0)
            {
                List<int> copy_process = new List<int>(input_process);
                List<int> copy_burst = new List<int>(input_burst);
                jop_first(copy_process, copy_burst);
            }
            else
            {
                MessageBox.Show("There are no processes to be scheduled please enter some processes.", "User Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void CLR_Click(object sender, EventArgs e)
        {
            if (input_process.Count != 0)
            {
                input_process.Clear();
                input_burst.Clear();
                input_priority.Clear();
                id.Clear();
                chart1.Series[0].Points.Clear();
                wait.Text = "";
                turn.Text = "";
                proc.Text = "0";
                quam.Text = "";
                zezo = 0;
            }
            else
            {
                MessageBox.Show("what are you doing ? there are no processes to be cleared.", "User Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RR_Click(object sender, EventArgs e)
        {
            if (quam.Text != "")
            {
                chart1.Series[0].Points.Clear();
                int qm = Convert.ToInt32(quam.Text);
                if (qm < 0)
                {
                    MessageBox.Show("There is no Quantum in -ve value. please enter valid Quantum.", "Round Robin Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<int> copy_process = new List<int>(input_process);
                    List<int> copy_burst = new List<int>(input_burst);
                    round_robin(copy_process, copy_burst, qm);
                }
            }

            else
            {
                MessageBox.Show("please enter valid Quantum.", "Round Robin Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            if (input_process.Count != 0)
            {
                List<int> copy_process = new List<int>(input_process);
                List<int> copy = new List<int>(input_process);
                List<int> copy_burst = new List<int>(input_burst);
                preemptive_job(copy_process, copy_burst, copy);
            }
            else
            {
                MessageBox.Show("There are no processes to be scheduled please enter some processes.", "User Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Prio_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            if (input_process.Count != 0)
            {
                List<int> copy_process = new List<int>(input_process);
                List<int> copy_burst = new List<int>(input_burst);
                List<int> copy_prio = new List<int>(input_priority);
                priority_first(copy_process, copy_burst, copy_prio);
            }
            else
            {
                MessageBox.Show("There are no processes to be scheduled please enter some processes.", "User Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            if (input_process.Count != 0)
            {
                List<int> copy_process = new List<int>(input_process);
                List<int> copy_burst = new List<int>(input_burst);
                List<int> copy_priorirty = new List<int>(input_priority);
                List<int> copy = new List<int>(input_process);
                preemptive_Priority(copy_process, copy_burst, copy_priorirty, copy);
            }
            else
            {
                MessageBox.Show("There are no processes to be scheduled please enter some processes.", "User Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       

        

    }
}
