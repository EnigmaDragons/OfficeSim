using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class GoToNavigationTarget : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float epsilon = 0.2f;

    private Vector3 _target;
    private Action _onArrival;
    private NavMeshAgent _agent;
    private Animator _animator;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void WalkTo(Vector3 target) => WalkTo(target, () => { });
    public void WalkTo(Vector3 target, Action onArrival)
    {
        _target = target;
        _onArrival = onArrival;
        _agent.destination = target;
        _animator.SetBool("isWalking", true);
        enabled = true;
    }

    void Start()
    {
        if (destination)
            WalkTo(destination.position);
    }

    void Update()
    {
        var flatPos = new Vector3(transform.position.x, 0, transform.position.z);
        var flatDestPos = new Vector3(_target.x, 0, _target.z);
        if (Vector3.Distance(flatPos, flatDestPos) < epsilon)
        {
            _animator.SetBool("isWalking", false);
            _onArrival();
            enabled = false;
        }
    }
}
