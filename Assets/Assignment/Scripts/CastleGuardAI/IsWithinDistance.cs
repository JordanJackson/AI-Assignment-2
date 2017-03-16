using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Condition/Blackboard/",
            icon = "Blackboard",
            description = "Return success is Transform is within distance from target.")]
public class IsWithinDistance : ConditionNode
{
    public string listVarName = "SearchPoints";
    public string indexVarName = "SearchIndex";
    public float distanceThreshold;
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
        int index = 0;
        IntVar indexVar = blackboard.GetIntVar(indexVarName);
        if (indexVar == null || indexVarName == "")
        {
            index = 0;
        }
        else
        {
            index = indexVar.Value;
        }

        if (Vector3.Distance(owner.root.transform.position, searchPoints[index]) <= distanceThreshold)
        {
            return Status.Success;
        }

        return Status.Failure;
    }
}
