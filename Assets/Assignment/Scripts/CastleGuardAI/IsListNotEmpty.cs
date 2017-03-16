using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Condition/Blackboard/",
            icon = "Blackboard",
            description = "Returns success if list is not empty.")]

public class IsListNotEmpty : ConditionNode
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


        if (searchPoints.Count <= 0)
        {
            return Status.Failure;
        }
        else
        {
            return Status.Success;
        }
    }
}
