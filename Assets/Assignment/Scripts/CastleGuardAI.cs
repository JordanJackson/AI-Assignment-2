using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CastleGuardAI : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator;

    public AnimationClip[] idleClips;

    public Path path;
    private int waypointIndex = 0;

    public List<Vector3> searchPoints;

    public float deadZone = 10f;
    public float angularSpeedDampTime = 5f;

    public float distanceThreshold = .5f;

    int waypointsVisited = 0;
    bool idling = false;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        deadZone *= Mathf.Deg2Rad;

    }

    void Update()
    {
        ProcessPath();
    }

    

    void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
    }

    public void IdleStart()
    {
        idling = true;
    }

    public void IdleEnd()
    {
        idling = false;
    }

    void UpdateCurrentWaypoint()
    {
        if (Vector3.Distance(transform.position, path.waypoints[waypointIndex].position) <= distanceThreshold)
        {
            waypointsVisited++;
            if (waypointsVisited >= 5)
            {
                int index = Random.Range(0, idleClips.Length);
                animator.Play(idleClips[index].name);
                idling = true;
                waypointsVisited = 0;
            }
            waypointIndex += 1;
            waypointIndex = waypointIndex % path.waypoints.Count;
        }
    }

    void ProcessPath()
    {
        float speed = Vector3.Project(agent.desiredVelocity, transform.forward).magnitude * agent.speed;

        animator.SetFloat("Speed", speed);

        float angleDelta = FindAngle(this.transform.forward, agent.desiredVelocity, Vector3.up);

        if (Mathf.Abs(angleDelta) < deadZone)
        {
            this.transform.LookAt(this.transform.position + agent.desiredVelocity);
        }

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(agent.desiredVelocity, transform.up), Time.deltaTime * angularSpeedDampTime);
    }

    float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
    {
        if (toVector == Vector3.zero)
        {
            return 0f;
        }

        float angle = Vector3.Angle(fromVector, toVector);

        Vector3 normal = Vector3.Cross(fromVector, toVector);

        angle *= Mathf.Deg2Rad;

        return angle;
    }
}
