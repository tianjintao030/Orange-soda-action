using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tasktype
{
    zhuxian,
    tezhi
}
[System.Serializable]
public struct taskNeeds
{
    public bool isFinsh;
    public string taskNeedtext;
}
[System.Serializable]
[CreateAssetMenu(fileName = "NewtaskDatabase", menuName = "taskDataitem")]
public class TaskDataBase : ScriptableObject
{
    [Header("��������")]
    [SerializeField]
    public int taskChainid;
    [Header("����ID")]
    [SerializeField]
    public int taskid;
    [Header("������")]
    [SerializeField]
    public string taskName;
    [Header("����ʱ��")]
    [SerializeField]
    public int taskDay;
    public string taskTime;
    [Header("��������")]
    [SerializeField]
    public string taskDesc;
    [Header("��������")]
    [SerializeField]
    public Tasktype tasktypt;
    [Header("�����������")]
    [SerializeField]
    public taskNeeds[] taskNeed;
    [Header("����״̬")]
    [SerializeField]
    public int taskState;//0δ��ʼ��1���ڽ��У�2�����
}
