using System.Collections;
using System.Collections.Generic;
using System.IO;//Directory.Exists
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;//Type
using System.Reflection;//FieldInfo

public class TaskUI : MonoBehaviour
{
    [Header("���ʼ��")]
    public TaskDataBase m_Item;
    public Text NameUI;
    public Text DayUI;
    public Text TaskTimeUI;
    public Text XNameUI;
    public Text XDayUI;
    public Text XTaskTimeUI;
    public Text DescUI;
    public GameObject xPanel;
    public GameObject needprefab;
    public Sprite finshSprite;
    [Header("�����ʼ��")]
    public GameObject needprefabUI;
    public TaskDataBase c_Item = null;//�л���һ����������һ������
    private bool isCild = false;
    public bool isFinsh = false;    

    public List<UnityEngine.Object> objects = new List<UnityEngine.Object>();//���ڴ�ų������к�� �ļ����µ��ļ�����
    public List<TaskDataBase> items = new List<TaskDataBase>();//���ڴ�ų������к�� �ļ����µ��ļ�����

    private void Start()
    {

    }
    private void Update()
    {
        Nameshow();
        c_Item = m_Item;
        if (m_Item.taskState == 2)//��ǰ��������ɣ��л�����������һ������
        {
            if (!isFinsh)
            {
                takeInfinsh();
            }
            changeNextitem();
        }
    }

    //��������ʾ
    public void Nameshow()
    {
        NameUI.text = m_Item.taskName;
        DayUI.text = "Day" + m_Item.taskDay.ToString();
        TaskTimeUI.text = m_Item.taskTime;
    }
    //��������Ҳ�panel��ʾ���� 
    public void XpanelClidShow()
    {
        xPanel.SetActive(true);
        XNameUI.text = m_Item.taskName;
        DescUI.text = m_Item.taskDesc;//����
        XDayUI.text = DayUI.text;
        XTaskTimeUI.text = TaskTimeUI.text;
        //��needPanel�¸���Item��taskneed������������Ӧ��UI
        //string fullPath = "Assets/Resources/Prefabs/taskneedtext.prefab";
        GameObject needpan = GameObject.Find("NeedPanel");
        //�����Xpanel��need
        if (needpan.transform.childCount > 0)
        {
            GameObject[] Sons = GameObject.FindGameObjectsWithTag("taskneedtag");
            foreach (GameObject things in Sons)
            {
                Destroy(things);
            }
        }
        //taskneedtextԤ����ʵ����
        foreach (taskNeeds n in m_Item.taskNeed)
        {
            needprefabUI = (GameObject)Instantiate(needprefab);
            needprefabUI.transform.parent = needpan.transform;
            //needprefabUI = new GameObject(Path.GetFileNameWithoutExtension(fullPath));
            needprefabUI.transform.Find("Text").GetComponent<Text>().text = n.taskNeedtext;
        }
    }
    //����������Դ
    public void loadTaskItem()
    {
        //��� �����ļ���·�����Լ�Ҫ���ص�Ŀ���ļ���������ļ�·���������һ���ַ���������
        string[] arrStrAudioPath = Directory.GetFiles(Application.dataPath + "/Resources/TaskItem/", "*", SearchOption.AllDirectories);//using System.IO;
        foreach (string strAudioPath in arrStrAudioPath)
        {
            //�滻·���еķ�б��Ϊ��б��       
            string strTempPath = strAudioPath.Replace(@"\", "/");
            //��ȡ������Ҫ��·��
            strTempPath = strTempPath.Substring(strTempPath.IndexOf("Assets"));
            //����·��������Դ
            UnityEngine.Object objAudio = AssetDatabase.LoadAssetAtPath(@strTempPath, typeof(UnityEngine.Object));//using UnityEditor;
            //objAudio.GetType();
            if (objAudio != null)
            {
                objects.Add(objAudio);
            }
            if (objAudio != null && objAudio.GetType().ToString() == "TaskDataBase")
            {
                items.Add((TaskDataBase)objAudio);//ǿ������ת�������� Item�����С�
            }

        }
    }
    //�л�����������һ������
    public void changeNextitem()
    {
        loadTaskItem();
        if (!isChainEnd())
        {
            foreach (TaskDataBase item in items)
            {
                if (item.taskChainid == m_Item.taskChainid && item.taskid == m_Item.taskid + 1)
                {
                    m_Item = item;
                    break;
                }
            }
            m_Item.taskState = 1;
        }
    }
    //�ж��Ƿ�����Ƿ��к�������
    public bool isChainEnd()
    {
        if (lastTask() == m_Item)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    //�ҵ����������һ������
    public TaskDataBase lastTask()
    {
        loadTaskItem();
        TaskDataBase lastItem = m_Item;
        foreach (TaskDataBase item in items)
        {
            if (item.taskChainid == m_Item.taskChainid && item.taskid > lastItem.taskid)
            {
                lastItem = item;
            }
        }
        return lastItem;
    }
    //����ɵ�������ӵ��·�
    protected GameObject btn;
    GameObject cont;
    public void takeInfinsh()
    {
        isFinsh = true;
        cont = GameObject.Find("Content");
        btn = Instantiate(this.gameObject, cont.transform);
        Image img = btn.GetComponent<Image>();
        img.sprite = finshSprite;
        img.color = Color.grey;
        btn.GetComponent<TaskUI>().m_Item = c_Item;
        btn.GetComponent<TaskUI>().m_Item.taskState = 3;
    }
}

