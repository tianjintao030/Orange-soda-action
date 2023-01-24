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
    [Header("任务链号")]
    [SerializeField]
    public int taskChainid;
    [Header("任务ID")]
    [SerializeField]
    public int taskid;
    [Header("任务名")]
    [SerializeField]
    public string taskName;
    [Header("任务时间")]
    [SerializeField]
    public int taskDay;
    public string taskTime;
    [Header("任务描述")]
    [SerializeField]
    public string taskDesc;
    [Header("任务类型")]
    [SerializeField]
    public Tasktype tasktypt;
    [Header("任务完成条件")]
    [SerializeField]
    public taskNeeds[] taskNeed;
    [Header("任务状态")]
    [SerializeField]
    public int taskState;//0未开始，1正在进行，2已完成
}
