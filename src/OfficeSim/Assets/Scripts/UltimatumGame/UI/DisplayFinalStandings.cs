using System;
using System.Collections;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public sealed class DisplayFinalStandings : OnMessage<UltimatumTournamentFinished>
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private float delay = 1.0f;

    private void Awake() => display.text = "";
    
    protected override void Execute(UltimatumTournamentFinished msg)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Final Results");
        sb.AppendLine("-----------------------------------");
        msg.Group.Standings.Take(5)
            .ForEach(p => sb.AppendLine($"{p.Id} - ${p.State.Winnings} - {p.Strategy.Description}"));
        StartCoroutine(DisplayAfterDelay(sb.ToString()));
    }

    private IEnumerator DisplayAfterDelay(string s)
    {
        yield return new WaitForSeconds(delay);
        display.text = s;
    }
}
