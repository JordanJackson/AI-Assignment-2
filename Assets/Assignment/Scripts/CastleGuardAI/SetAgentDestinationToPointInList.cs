using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using BehaviourMachine;
using System;

[NodeInfo(category = "Action/ArtificialIntelligence/",
            icon = "NavMeshAgent",
            description = "Sets NavMeshAgent destination to point in list.")]
public class SetAgentDestinationToPointInList : ActionNode
{

    public string listVarName = "SearchPoints";
    public string indexVarName = "SearchIndex";

    NavMeshAgent agent;
    List<Vector3> searchPoints;

    public override void Reset()
    {
        agent = owner.root.GetComponent<NavMeshAgent>();
        if (listVarName != "")
        {
            searchPoints = blackboard.GetDynamicList(listVarName).Value.Cast<Vector3>().ToList();
        }
    }

    public override void Start()
    {
        if (listVarName != "")
        {
            searchPoints = blackboard.GetDynamicList(listVarName).Value.Cast<Vector3>().ToList();
        }
    }

    public override Status Update()
    {
        if (searchPoints != null)
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

            agent.SetDestination(searchPoints[0]);
        }
        return Status.Failure;
    }
}
