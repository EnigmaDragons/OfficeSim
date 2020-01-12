using System.Collections;
using UnityEngine;

public sealed class PlayUltimatumGame : MonoBehaviour
{
    [SerializeField] private GoToNavigationTarget walking;
    [SerializeField] private float timeToWait;
    [SerializeField] private CharacterId characterId;
    [SerializeField, ReadOnly] private UltimatumRole role; 

    private Vector3 homeSpot;
    private Vector3 gameSpot;
    
    public void SetPath(UltimatumRole roundRole, Vector3 start, Vector3 play)
    {
        role = roundRole;
        homeSpot = start;
        gameSpot = play;
        walking.WalkTo(gameSpot, () => StartCoroutine(Play()));
    }
    
    private IEnumerator Play()
    {
        Message.Publish(new UltimatumPlayerReady { Id = characterId.Id });
        yield return new WaitForSeconds(timeToWait);
        walking.WalkTo(homeSpot, () =>
        {
            Message.Publish(new UltimatumPlayerFinished(characterId.Id));
            gameObject.SetActive(false);
        });
    }
}
