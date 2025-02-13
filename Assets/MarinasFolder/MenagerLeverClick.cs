using UnityEngine;

public class MenagerLeverClick : MenagerButtonsDown
{    
    public override void AllTrue()
    {        
        count = 0;
        for (int i = 0; i < activatedObgects.Length; i++)
        {
            if (activatedObgects[i].GetComponent<TriggerLever>().GetBoolLever())
            {
                count++;
            }
            else
            {
                count--;
            }
        }
    }
}
