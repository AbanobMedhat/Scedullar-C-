 void periorityNP(List<int> input_process, List<int> input_burst, List<int> input_priority)
   {

    List<int> no_process = new List<int>();
    for (int ii = 0; ii < input_process.Count; ii++)
      no_process.Add(ii);

    float n = input_process.Count;
    int time = input_process[0];// hanbd2 mn awel process gatlna
    int end = 0;
    float waiting_time = 0;
    float avg_waiting = 0;
    float turn_around = 0;
    float avg_turn = 0;
 
    for (int i = 0; input_process.Count != 0; i++)
    {  
        
        int min = input_priority[0];
        int t = 0;
        for (int j = 1; j < input_process.Count; j++)
        {
           
                if (input_priority[j] < min)
                {
                    min = input_priority[j];
                    t = j;
                }
              
                
           
        }
       
        int begin = time;
        time = time + input_burst[t];
        end = time;
        chart1.Series[0].Points.AddXY(no_process[t], begin, end);

        waiting_time = waiting_time + (time - input_burst[t] - input_process[t]);
        turn_around = turn_around + ( time - input_process[t]);

        input_process.RemoveAt(t);
        input_burst.RemoveAt(t);
        input_priority.RemoveAt(t);
        no_process.RemoveAt(t);
       

    }
    avg_waiting = waiting_time / n;
    wait.Text = Convert.ToString(avg_waiting);
    avg_turn = turn_around / n;
    turn.Text = Convert.ToString(avg_turn);

   
  }// bta3t el fn 