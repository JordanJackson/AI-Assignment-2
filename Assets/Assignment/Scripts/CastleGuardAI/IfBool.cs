using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

[NodeInfo(category = "Condition/Blackboard/",
            icon = "Blackboard",
            description = "Returns success if given bool is true.")]
public class IfBool : ConditionNode
{
    public BoolVar boolean;

    public override Status Update()
    {
        if (boolean.Value)
        {
            return Status.Success;
        }
        else
        {
            return Status.Failure;
        }
    }
}
