using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    public Text timerText;
    public static float timeLeft=20f;
    // Start is called before the first frame update
    void Start() 
    {
        timerText=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft-= Time.deltaTime;
        if(timeLeft<0)
        {
            timeLeft=0; 
        }
        timerText.text="Tiempo: "+Mathf.Round(timeLeft);
        /*float t=Time.time-timeLeft;
        string minutes=((int)t/60).ToString();
        string seconds=(t%60).ToString("f2");

        timerText.text=minutes+":"+seconds;*/
    }
}
