using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeGo : MonoBehaviour
{
    public Text hour;
    public Text mint;
    public Text day;


    void Start()
    {

        StartCoroutine("DoSomething");

    }



    IEnumerator DoSomething()
    {

        while (true)
        {

            //需要重复执行的代码就放于在此处
            int mintt = int.Parse(mint.text);//分钟的int
            mintt = mintt + 1;//分钟加一
            int hourr = int.Parse(hour.text);//小时的int
            int dayy = int.Parse(day.text);
            if (mintt>60)//分钟达60
            {
                mintt = 0;
                mint.text = "00";//分钟清除为0
                hourr = hourr + 1;//小时加1
                if(hourr>24)//小时达24
                {
                    hourr = 0;
                    hour.text = "0";
                    dayy++;
                }
            }
            if(mintt<10)
            {
                mint.text = "0" ;
                mint.text = mint.text + mintt.ToString();
            }
            else
            {
                mint.text = mintt.ToString();
            }
            if(hourr<10)
            {
                hour.text = "0";
                hour.text = hour.text + hourr.ToString();
            }
            else
            {
                hour.text = hourr.ToString();
            }
            
            day.text = dayy.ToString();


            print("DoSomething Loop");

            //设置间隔时间为3秒

            yield return new WaitForSeconds(3);

        }

    }


}
