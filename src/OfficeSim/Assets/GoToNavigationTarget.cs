using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoToNavigationTarget : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private Animator animator;
    [SerializeField] private float epsilon = 0.2f;

    private NavMeshAgent _agent;

    void Awake() => _agent = GetComponent<NavMeshAgent>();
    
    void Start()
    {
        _agent.destination = destination.position;
        animator.SetBool("isWalking", true);
    }

    void Update()
    {
        var flatPos = new Vector3(transform.position.x, 0, transform.position.z);
        var flatDestPos = new Vector3(destination.position.x, 0, destination.position.z);
        if (Vector3.Distance(flatPos, flatDestPos) < epsilon)
        {
            animator.SetBool("isWalking", false);
            enabled = false;
        }
    }
}
