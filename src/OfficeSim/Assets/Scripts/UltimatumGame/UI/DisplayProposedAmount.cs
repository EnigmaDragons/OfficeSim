using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayProposedAmount : OnMessage<ProposalPresented>
{
    [SerializeField] private TextMeshPro display;
    [SerializeField] private float duration = 1.5f;
    [SerializeField] private UltimatumRole role;
    [SerializeField] private int roomNumber;

    private void Awake() => display.text = "";
    
    protected override void Execute(ProposalPresented msg)
    {
        if (msg.Pairing.RoomNumber != roomNumber) return;
        
        var amount = role == UltimatumRole.Proposer ? msg.ProposerAmount : msg.ResponderAmount;
        display.text = amount.ToString();
        StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(duration);
        display.text = "";
    }
}