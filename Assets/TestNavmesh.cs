using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavmesh : MonoBehaviour
{
    public NavMeshAgent Agent;
    public GameObject DestObj;
    private void GoToDestination(Vector3 dest)
    {
        Agent.SetDestination(dest);
        Debug.Log(NavMesh.GetAreaFromName("Jump"));
        //Agent.set
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToDestination(DestObj.transform.position);
            
//             NavMeshPath path = new NavMeshPath();
//             if(Agent.CalculatePath(DestObj.transform.position, path))
//                 Debug.Log(path);
// 
//             path.ClearCorners();
            
//             if(NavMesh.CalculatePath(Agent.transform.position, DestObj.transform.position, NavMesh.AllAreas, path))
//             {
//                 Debug.Log(path);
//                 Debug.Log(path.status);
//             }

        }
    }
}
