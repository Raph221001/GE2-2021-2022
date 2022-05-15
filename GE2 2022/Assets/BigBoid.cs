using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoid : MonoBehaviour
{
    
    public Vector3 velocity;
    public float speed;
    public Vector3 acceleration;
    public Vector3 force;
    public float maxSpeed = 5;
    public float maxForce = 10;

    public float mass = 1;

    public bool seekEnabled = true;
    public Transform seekTargetTransform;
    public Vector3 seekTarget;

    public bool arriveEnabled = false;
    public Transform arriveTargetTransform;
    public Vector3 arriveTarget;
    public float slowingDistance = 80;

    public Path path;
    public bool pathFollowingEnabled = false;
    public float waypointDistance = 3;

    // Banking
    public float banking = 0.1f; 

    public float damping = 0.1f;

    public bool playerSteeringEnabled = false;
    public float steeringForce = 100;

    public bool pursueEnabled = false;
    public BigBoid pursueTarget;

    public Vector3 pursueTargetPos; 

    public bool offsetPursueEnabled = false;
    public BigBoid leader;
    public Vector3 offset;
    private Vector3 worldTarget;
    private Vector3 targetPos;

    public bool offsetPursueEnabled = false;
    public BigBoid leader;

    public Vector3 offset;

    private Vector3 worldTarget;
    private Vector3 targetPos;

    public Vector3 Pursue(BigBoid pursueTarget)
    {
<<<<<<< Updated upstream:GE2 2022/Assets/BigBoid.cs
        float dist = Vector3.Distance(pursueTarget.transform.position, transform.position);
        float time = dist / maxSpeed;
        pursueTargetPos = pursueTarget.transform.position 
                    + pursueTarget.velocity * time;
=======
        float dist = Vector3.Distance(pursueTarget.transform.position, transform.position);//Calculate the distance between the two objects
        float time = dist / maxSpeed;//Calculate the time it will take to get there
        pursueTargetPos = pursueTarget.transform.position 
                    + pursueTarget.velocity * time;//Find the future position of the target and project forward
>>>>>>> Stashed changes:GE2 2021/Assets/BigBoid.cs
        return Seek(pursueTargetPos);
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + acceleration);

        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + force * 10);

        if (arriveEnabled)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(arriveTargetTransform.position, slowingDistance);
        }

        if (pursueEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, pursueTargetPos);//Draw a line from the current position to the future position
        }

    }

    public Vector3 OffsetPursue(BigBoid leader)
    {
        // This is a bug!!
<<<<<<< Updated upstream:GE2 2022/Assets/BigBoid.cs
        //worldTarget = leader.transform.TransformPoint(offset);
        worldTarget = (leader.transform.rotation * offset) 
                + leader.transform.position;


        float dist = Vector3.Distance(transform.position, worldTarget);
        float time = dist / maxSpeed;

        targetPos = worldTarget + (leader.velocity * time);
        return Arrive(targetPos);
    }

    // Start is called before the first frame update
=======
        worldTarget = leader.transform.TransformPoint(offset);//Calculating the world target
        //Calculate new position to arrive at relative to leaders current position and rotation
        worldTarget = (leader.transform.rotation * offset)//Rotate the offset by the leaders current rotation
                    + leader.transform.position;//Add the leaders current position to the offset
                + leader.transform.position;


        float dist = Vector3.Distance(transform.position, worldTarget);//Calculate distance to world target
        float time = dist / maxSpeed;//Calculate time to get there

        targetPos = worldTarget + (leader.velocity * time);//Calculate the future position of the target
        return Arrive(targetPos);
    }

>>>>>>> Stashed changes:GE2 2021/Assets/BigBoid.cs
    void Start()
    {
        if (offsetPursueEnabled)
        {
<<<<<<< Updated upstream:GE2 2022/Assets/BigBoid.cs
            offset = transform.position - leader.transform.position;
            offset = Quaternion.Inverse(leader.transform.rotation) * offset;
=======
            offset = transform.position - leader.transform.position;//Vector from leader to this boid
            offset = Quaternion.Inverse(leader.transform.rotation) * offset;//
>>>>>>> Stashed changes:GE2 2021/Assets/BigBoid.cs
        }
    }

    public Vector3 PlayerSteering()
    {
        Vector3 force = Vector3.zero;
        force += Input.GetAxis("Vertical") * transform.forward * steeringForce;

<<<<<<< Updated upstream:GE2 2022/Assets/BigBoid.cs
        Vector3 projected = transform.right;
        projected.y = 0;
        projected.Normalize();
=======
        //Projecting the right vector onto the XZ plane
        Vector3 projected = transform.right;
        projected.y = 0;//Assign y value to zero 
        projected.Normalize();//Normalize the vector
>>>>>>> Stashed changes:GE2 2021/Assets/BigBoid.cs

        force += Input.GetAxis("Horizontal") * projected * steeringForce;

        // Put your code here!
        return force;
    }


    public Vector3 PathFollow()
    {
        Vector3 nextWaypoint = path.Next();
        if (!path.isLooped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
            }
            return Seek(nextWaypoint);
        }
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return (desired - velocity);
    } 

    public Vector3 Arrive(Vector3 target)
    {
<<<<<<< Updated upstream:GE2 2022/Assets/BigBoid.cs
       Vector3 toTarget = target - transform.position;
       float dist = toTarget.magnitude;
=======
       Vector3 toTarget = target - transform.position;//Calculates the two target vectors
       float dist = toTarget.magnitude;//Get the distance between the two vectors
>>>>>>> Stashed changes:GE2 2021/Assets/BigBoid.cs
       if (dist == 0.0f)
       {
           return Vector3.zero;
       }
<<<<<<< Updated upstream:GE2 2022/Assets/BigBoid.cs
       float ramped = (dist / slowingDistance) * maxSpeed;
       float clamped = Mathf.Min(ramped, maxSpeed);
       Vector3 desired = clamped * (toTarget / dist);
       return desired - velocity;
=======
       float ramped = (dist / slowingDistance) * maxSpeed;//Calculate the ramped speed
       float clamped = Mathf.Min(ramped, maxSpeed);//Calculate the clamped speed
       Vector3 desired = clamped * (toTarget / dist);//Calculate the desired vector
       return desired - velocity;//Return the desired vector
>>>>>>> Stashed changes:GE2 2021/Assets/BigBoid.cs
    }

    public Vector3 CalculateForce()
    {
        Vector3 f = Vector3.zero;
        if (seekEnabled)
        {
            if (seekTargetTransform != null)
            {
                seekTarget = seekTargetTransform.position;
            }
            f += Seek(seekTarget);
        }

        if (arriveEnabled)
        {
            if (arriveTargetTransform != null)
            {
                arriveTarget = arriveTargetTransform.position;                
            }
            f += Arrive(arriveTarget);
        }

        if (pathFollowingEnabled)
        {
            f += PathFollow();
        }

        if (playerSteeringEnabled)
        {
            f += PlayerSteering();
        }

        if (pursueEnabled)
        {
            f += Pursue(pursueTarget);
        }

        if (offsetPursueEnabled)
        {
            f += OffsetPursue(leader);
        }

        return f;
    }

    // Update is called once per frame
    void Update()
    {
        force = CalculateForce();
        acceleration = force / mass;
        velocity = velocity + acceleration * Time.deltaTime;
        transform.position = transform.position + velocity * Time.deltaTime;
        speed = velocity.magnitude;
        if (speed > 0)
        {
            //transform.forward = velocity;
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            //velocity *= 0.9f;

            // Remove 10% of the velocity every second
            velocity -= (damping * velocity * Time.deltaTime);
        }        
    }
}
