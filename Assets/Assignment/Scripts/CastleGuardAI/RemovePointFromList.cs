using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Action/Blackboard/",
            icon = "Blackboard",
            description = "Removes point from list.")]
public class RemovePointFromList : ActionNode
{
    public string listVarName = "SearchPoints";
    List<Vector3> searchPoints;

    public override void Reset()
    {
        searchPoints = blackboard.GetDynamicList(listVarName).Value.Cast<Vector3>().ToList();
    }

    public override void Start()
    {
        searchPoints = blackboard.GetDynamicList(listVarName).Value.Cast<Vector3>().ToList();
    }

    public override Status Update()
    {
        if (searchPoints == null || searchPoints.Count <= 0)
        {
            return Status.Failure;
        }
        else
        {
            searchPoints.RemoveAt(0);
            blackboard.GetDynamicList(listVarName).Value = searchPoints.Cast<object>().ToList();
            return Status.Success;
        }

    }
}