using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class DisplayStandings : OnMessage<UltimatumRoundFinished, UltimatumTournamentFinished>
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private CurrentUltimatumTournament _tourney;
    [SerializeField] private FloatReference delay = new FloatReference(1.5f);

    void Awake() => display.text = "";
    
    protected override void Execute(UltimatumRoundFinished msg)  => UpdateStandings();
    protected override void Execute(UltimatumTournamentFinished msg) => UpdateStandings();

    private void UpdateStandings()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Standings");
        sb.AppendLine("----------");
        _tourney.Group.Standings
            .ForEach(p => sb.AppendLine($"{p.Name} - ${p.State.Winnings} - {p.Strategy.Description}"));
        StartCoroutine(DisplayAfterDelay(sb.ToString()));
    }

    private IEnumerator DisplayAfterDelay(string s)
    {
        yield return new WaitForSeconds(delay);
        display.text = s;
    }
}
