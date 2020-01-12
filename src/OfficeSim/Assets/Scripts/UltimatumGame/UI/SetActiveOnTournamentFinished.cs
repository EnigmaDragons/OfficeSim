using UnityEngine;

public class SetActiveOnTournamentFinished : OnMessage<UltimatumTournamentFinished>
{
    [SerializeField] private GameObject[] enableTargets;
    [SerializeField] private GameObject[] disableTargets;
    
    protected override void Execute(UltimatumTournamentFinished msg)
    {
        enableTargets.ForEach(t => t.SetActive(true));
        disableTargets.ForEach(t => t.SetActive(false));
    }
}