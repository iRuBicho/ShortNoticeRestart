using UnityEngine;
using UnityEngine.AI;

public class CompanionFollowNavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Vector3 offset = new Vector3(2f, 0f, -1.5f);
    public float updateRate = 0.25f;

    private float timer = 0f;

    void Update()
    {
        if (player == null || agent == null) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Vector3 followPosition = player.position + player.right * offset.x + player.forward * offset.z;
            agent.SetDestination(followPosition);
            timer = updateRate;
        }
    }
}

// https://www.youtube.com/watch?v=OkebNDBCCU4&t=29s
