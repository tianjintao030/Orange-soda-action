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

            //��Ҫ�ظ�ִ�еĴ���ͷ����ڴ˴�
            int mintt = int.Parse(mint.text);//���ӵ�int
            mintt = mintt + 1;//���Ӽ�һ
            int hourr = int.Parse(hour.text);//Сʱ��int
            int dayy = int.Parse(day.text);
            if (mintt>60)//���Ӵ�60
            {
                mintt = 0;
                mint.text = "00";//�������Ϊ0
                hourr = hourr + 1;//Сʱ��1
                if(hourr>24)//Сʱ��24
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

            //���ü��ʱ��Ϊ3��

            yield return new WaitForSeconds(3);

        }

    }


}
