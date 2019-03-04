using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text tv;
    public Text tv_2;
    public GameObject AIpref;
    GameObject[] AIlist=new GameObject[20];
    public int DNA_Length = 800;

    public bool isActive;
    public int Dely = 0;

    public string[] DNA = new string[20];
    public int Point=0;

    /*
    0:아무것도 안함
    1:0번다리 들기
    2:0번다리 내리기
    3:1번다리 들기
    4:1번다리 내리기
    5:2번다리 들기
    6:2번다리 내리기
    7:3번다리 들기
    8:3번다리 내리기
    */

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 10;
        for (int i_0 = 0; i_0 < 20; i_0++)
        {
            AIlist[i_0]=Instantiate(AIpref, new Vector3(0, 0.05f, i_0 * 2f),Quaternion.identity);
            AIlist[i_0].transform.position = new Vector3(0,0.05f,i_0*2f);
            string Date = "";
            for (int i_1 = 0; i_1 < DNA_Length; i_1++)
            {
                Date += Random.Range(0, 9);
            }
            DNA[i_0] = Date.Substring(0, Date.Length - 1);
        }
    }

    public void testBtn()
    {
        CopyDna(DNA[0]);
    }

    void CopyDna(string Dna)
    {
        Point++;
        tv_2.text = Point.ToString();
        char[] RNAPri = new char[DNA_Length];
        DNA[0] = Dna;
        for (int i = 1; i < DNA_Length - 1; i++)
        {
            RNAPri[i] = Dna[i];
        }
        for (int i = 0; i < 5; i++)
        {
            string date = "";
            for (int i_2 = 0; i_2 < 20; i_2++)
            {
                RNAPri[Random.Range(0, DNA_Length)] = Random.Range(0, 9).ToString()[0];
            }
            for (int i_2 = 0; i_2 < DNA_Length; i_2++)
            {
                date += RNAPri[i_2];
            }
            DNA[i] = date;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Make", 0.12f);
    }

    void Make()
    {
        if (isActive)
        {
            Dely = (Dely + 4) % DNA_Length;
            if(Dely>DNA_Length-5)
            {
                Check();
                return;
            }
            CodeChk(Dely % (DNA_Length - 3));
            CodeChk((Dely + 1) % (DNA_Length - 3));
            CodeChk((Dely + 2) % (DNA_Length - 3));
            CodeChk((Dely + 3) % (DNA_Length - 3));
        }
    }

    void CodeChk(int code)
    {
        for (int i_0 = 0; i_0 < 20; i_0++)
        {
            GameObject Leg_0= AIlist[i_0].transform.GetChild(0).GetChild(0).gameObject;
            GameObject Leg_1= AIlist[i_0].transform.GetChild(0).GetChild(1).gameObject;
            GameObject Leg_2= AIlist[i_0].transform.GetChild(0).GetChild(2).gameObject;
            GameObject Leg_3= AIlist[i_0].transform.GetChild(0).GetChild(3).gameObject;
            if (DNA[i_0][code] == 0)
            {
                float f = Time.deltaTime;
}
            if (DNA[i_0][code] == '1')
            {
                if (Leg_0.transform.localRotation.eulerAngles.z + 5 <= 45)
                {
                    Leg_0.transform.Rotate(0, 0, Time.deltaTime* 200);
                }
                else
                    Leg_0.transform.Rotate(0, 0, -5);
            }
            if (DNA[i_0][code] == '2')
            {
                if (Leg_0.transform.localRotation.eulerAngles.z - 5 <= -45)
                {
                    Leg_0.transform.Rotate(0, 0, -Time.deltaTime* 200);
                }
                else
                    Leg_0.transform.Rotate(0, 0, 5);
            }

            if (DNA[i_0][code] == '3')
            {
                if (Leg_1.transform.localRotation.eulerAngles.z + 5 <= 45)
                {
                    Leg_1.transform.Rotate(0, 0, Time.deltaTime* 200);
                }
                else
                    Leg_1.transform.Rotate(0, 0, -5);
            }
            if (DNA[i_0][code] == '4')
            {
                if (Leg_1.transform.localRotation.eulerAngles.z - 5 <= -45)
                {
                    Leg_1.transform.Rotate(0, 0, -Time.deltaTime* 200);
                }
                else
                    Leg_1.transform.Rotate(0, 0, 5);
            }

            if (DNA[i_0][code] == '5')
            {
                if (Leg_2.transform.localRotation.eulerAngles.z + 5 <= 45)
                {
                    Leg_2.transform.Rotate(0, 0, Time.deltaTime* 200);
                }
                else
                    Leg_2.transform.Rotate(0, 0, -5);
            }
            if (DNA[i_0][code] == '6')
            {
                if (Leg_2.transform.localRotation.eulerAngles.z - 5 <= -45)
                {
                    Leg_2.transform.Rotate(0, 0, -Time.deltaTime* 200);
                }
                else
                    Leg_2.transform.Rotate(0, 0, 5);
            }

            if (DNA[i_0][code] == '7')
            {
                if (Leg_3.transform.localRotation.eulerAngles.z + 5 <= 45)
                {
                    Leg_3.transform.Rotate(0, 0, Time.deltaTime* 200);
                }
                else
                    Leg_3.transform.Rotate(0, 0, -5);
            }
            if (DNA[i_0][code] == '8')
            {
                if (Leg_3.transform.localRotation.eulerAngles.z - 5 <= -45)
                {
                    Leg_3.transform.Rotate(0, 0, -Time.deltaTime* 200);
                }
                else
                    Leg_3.transform.Rotate(0, 0, 5);
            }
            float d = Time.deltaTime;
        }
    }

    void Check()
    {
        float MaxPos = 0;
        int maxCount = 0;
        for(int i=0;i<20;i++)
        {
            if((AIlist[i].transform.position.z- i * 2f) >= MaxPos&& (AIlist[i].transform.GetChild(0).position.y)>0.04f)
            {
                MaxPos = AIlist[i].transform.position.z- i * 2f-AIlist[i].transform.GetChild(0).transform.localPosition.z;
                maxCount = i;
            }
            Destroy(AIlist[i]);
        }
        tv.text = MaxPos.ToString();
        CopyDna(DNA[maxCount]);
        for (int i_0 = 0; i_0 < 20; i_0++)
        {
            AIlist[i_0] = Instantiate(AIpref, new Vector3(0, 0.05f, i_0 * 2f), Quaternion.identity);
            AIlist[i_0].transform.position = new Vector3(0, 0.05f, i_0 * 2f);
            
        }
    }
}
