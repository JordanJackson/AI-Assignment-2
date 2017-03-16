using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Action/Blackboard/",
            icon = "Blackboard",
            description = "Adds ScreenToRay hit location to list and sorts list in place.")]
public class AddPointToList : ActionNode
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
        Vector3? point = ScreenPointToRayClick.GetClickLocation();
        if (point != null)
        {
            // add point and sort list
            Vector3 castPoint = (Vector3)point;
            Vector3 modifiedPoint = new Vector3(castPoint.x, owner.root.transform.position.y, castPoint.z);
            searchPoints.Add(modifiedPoint);
            searchPoints.Sort((x, y) => Vector3.Distance(owner.root.transform.position, x).CompareTo(Vector3.Distance(owner.root.transform.position, y)));
            blackboard.GetDynamicList(listVarName).Value = searchPoints.Cast<object>().ToList();
            return Status.Success;
        }
        else
        {
            return Status.Failure;
        }
    }
}
