 void round_robin (List<int> input_process, List<int> input_burst,int qm)
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
             float n= input_process.Count;
             int time= arrival_time[0];// hanbd2 mn awel process gatlna
             int end = 0;
             int remaining_burst = 0;
             int arrival_t = 0;
             float waiting_time=0;
             float avg_waiting = 0;
            
       for (int i = 0; arrival_time.Count != 0; i++)
       {
          int  begin = time; // hanbd2 mn el time el 2a5er elly we2fna 3ndo
          int min=arrival_time[0];
          int t=0;

            for (int j = 1; j < arrival_time.Count; j++)
            {
               if (arrival_time[j] < min)
                {
                 min = arrival_time[j];
                  t=j;
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

                  
                   arrival_time[t]=time;

                    end = time;

                    chart1.Series[0].Points.AddXY(no_process[t], begin, end);
                    } //bta3et smaller if

                   else  // If burst time is smaller than or equal to quantum for this process 
                    {
                    time = time + rem_bt[t];  // Increase the value of t

                     waiting_time =  waiting_time +( time - input_burst[t] - input_process[t]);

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