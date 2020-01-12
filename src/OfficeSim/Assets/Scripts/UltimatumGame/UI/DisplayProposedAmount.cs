using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayProposedAmount : OnMessage<ProposalPresented, ProposalResponseGiven>
{
    [SerializeField] private TextMeshPro display;
    [SerializeField] private FloatReference duration = new FloatReference(1.5f);
    [SerializeField] private FloatReference delayBeforeColorChange = new FloatReference(2f);
    [SerializeField] private ColorReference acceptedColor;
    [SerializeField] private ColorReference rejectedColor;
    [SerializeField] private UltimatumRole role;
    [SerializeField] private int roomNumber;

    private Color _originalColor; 
    private void Awake()
    {
        display.text = "";
        _originalColor = display.color;
    }

    protected override void Execute(ProposalPresented msg)
    {
        if (msg.Pairing.RoomNumber != roomNumber) return;
        
        var amount = role == UltimatumRole.Proposer ? msg.ProposerAmount : msg.ResponderAmount;
        display.text = amount.ToString();
        display.color = _originalColor;
        StartCoroutine(HideText());
    }

    protected override void Execute(ProposalResponseGiven msg)
    {
        if (msg.Pairing.RoomNumber != roomNumber) return;
        
        StartCoroutine(ColorText(msg.Response ? acceptedColor : rejectedColor));
    }

    private IEnumerator ColorText(Color c)
    {
        yield return new WaitForSeconds(delayBeforeColorChange);
        display.color = c;
    }
    
    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(duration);
        display.text = "";
    }
}