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
    [Header("需初始化")]
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
    [Header("无需初始化")]
    public GameObject needprefabUI;
    public TaskDataBase c_Item = null;//切换下一个任务后存上一个任务
    private bool isCild = false;
    public bool isFinsh = false;    

    public List<UnityEngine.Object> objects = new List<UnityEngine.Object>();//用于存放场景运行后的 文件夹下的文件物体
    public List<TaskDataBase> items = new List<TaskDataBase>();//用于存放场景运行后的 文件夹下的文件物体

    private void Start()
    {

    }
    private void Update()
    {
        Nameshow();
        c_Item = m_Item;
        if (m_Item.taskState == 2)//当前任务已完成，切换到该链上下一个任务
        {
            if (!isFinsh)
            {
                takeInfinsh();
            }
            changeNextitem();
        }
    }

    //任务名显示
    public void Nameshow()
    {
        NameUI.text = m_Item.taskName;
        DayUI.text = "Day" + m_Item.taskDay.ToString();
        TaskTimeUI.text = m_Item.taskTime;
    }
    //鼠标点击，右侧panel显示详情 
    public void XpanelClidShow()
    {
        xPanel.SetActive(true);
        XNameUI.text = m_Item.taskName;
        DescUI.text = m_Item.taskDesc;//描述
        XDayUI.text = DayUI.text;
        XTaskTimeUI.text = TaskTimeUI.text;
        //在needPanel下根据Item中taskneed的数量生成相应的UI
        //string fullPath = "Assets/Resources/Prefabs/taskneedtext.prefab";
        GameObject needpan = GameObject.Find("NeedPanel");
        //先清空Xpanel上need
        if (needpan.transform.childCount > 0)
        {
            GameObject[] Sons = GameObject.FindGameObjectsWithTag("taskneedtag");
            foreach (GameObject things in Sons)
            {
                Destroy(things);
            }
        }
        //taskneedtext预制体实例化
        foreach (taskNeeds n in m_Item.taskNeed)
        {
            needprefabUI = (GameObject)Instantiate(needprefab);
            needprefabUI.transform.parent = needpan.transform;
            //needprefabUI = new GameObject(Path.GetFileNameWithoutExtension(fullPath));
            needprefabUI.transform.Find("Text").GetComponent<Text>().text = n.taskNeedtext;
        }
    }
    //加载任务资源
    public void loadTaskItem()
    {
        //获得 工程文件的路径，以及要加载的目标文件夹下面的文件路径，存放在一个字符串数组中
        string[] arrStrAudioPath = Directory.GetFiles(Application.dataPath + "/Resources/TaskItem/", "*", SearchOption.AllDirectories);//using System.IO;
        foreach (string strAudioPath in arrStrAudioPath)
        {
            //替换路径中的反斜杠为正斜杠       
            string strTempPath = strAudioPath.Replace(@"\", "/");
            //截取我们需要的路径
            strTempPath = strTempPath.Substring(strTempPath.IndexOf("Assets"));
            //根据路径加载资源
            UnityEngine.Object objAudio = AssetDatabase.LoadAssetAtPath(@strTempPath, typeof(UnityEngine.Object));//using UnityEditor;
            //objAudio.GetType();
            if (objAudio != null)
            {
                objects.Add(objAudio);
            }
            if (objAudio != null && objAudio.GetType().ToString() == "TaskDataBase")
            {
                items.Add((TaskDataBase)objAudio);//强制类型转换，放入 Item数组中。
            }

        }
    }
    //切换到此链的下一个任务
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
    //判断是否此链是否还有后续任务
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
    //找到此链上最后一个任务
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
    //已完成的任务添加到下方
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

