using System.Collections;
using TMPro;
using UltimatumGame.Events;
using UnityEngine;

[RequireComponent(typeof(CharacterId))]
public sealed class DisplayWinnings : OnMessage<UltimatumRoundPairingResult>
{
    [SerializeField] private TextMeshPro display;
    [SerializeField] private float delay = 1.5f;
    [SerializeField] private CurrentUltimatumTournament state;
    
    private int _characterId;

    private void Awake() => display.text = "0";
    
    private void Start()
    {
        _characterId = GetComponent<CharacterId>().Id;
        display.text = state.Player(_characterId).State.Winnings.ToString();
    }
    
    protected override void Execute(UltimatumRoundPairingResult msg)
    {
        if (msg.Pairing.Proposer.Id == _characterId)
            StartCoroutine(UpdateAfterDelay(msg.Pairing.Proposer.State.Winnings.ToString()));
        if (msg.Pairing.Responder.Id == _characterId)
            StartCoroutine(UpdateAfterDelay(msg.Pairing.Responder.State.Winnings.ToString()));
    }

    private IEnumerator UpdateAfterDelay(string val)
    {
        yield return new WaitForSeconds(delay);
        display.text = val;
    }
}
