using TMPro;
using UnityEngine;

public sealed class DisplayRound : OnMessage<UltimatumRoundPairingsReady>
{
    [SerializeField] private TextMeshProUGUI display;

    protected override void Execute(UltimatumRoundPairingsReady msg)
    {
        display.text = $"Round {msg.RoundNumber}";
    }
}
