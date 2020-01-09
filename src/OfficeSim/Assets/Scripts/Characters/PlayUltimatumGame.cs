using System.Collections;
using UnityEngine;

public sealed class PlayUltimatumGame : MonoBehaviour
{
    [SerializeField] private GoToNavigationTarget walking;
    [SerializeField] private Vector3 gameSpot;
    [SerializeField] private float timeToWait;

    private Vector3 homeSpot;

    private void Awake()
    {
        homeSpot = transform.position;
    }
    
    private void Start()
    {
        walking.WalkTo(gameSpot, () => StartCoroutine(Play()));
    }
    
    private IEnumerator Play()
    {
        yield return new WaitForSeconds(timeToWait);
        walking.WalkTo(homeSpot, () => { });
    }
}
