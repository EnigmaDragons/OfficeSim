using System.Collections;
using UnityEngine;

public sealed class DisplayUltimatumResponse : OnMessage<ProposalResponseGiven>
{
    [SerializeField] private int roomNumber;
    [SerializeField] private GameObject accept;
    [SerializeField] private GameObject reject;
    [SerializeField] private FloatReference delay = new FloatReference(1.5f);
    [SerializeField] private FloatReference displayDuration =  new FloatReference(2f);

    private void Awake() => Hide();
    
    protected override void Execute(ProposalResponseGiven msg)
    {
        if (msg.Pairing.RoomNumber != roomNumber)
            return;
        
        StartCoroutine(ShowForDuration(msg));
    }

    private IEnumerator ShowForDuration(ProposalResponseGiven msg)
    {
        yield return new WaitForSeconds(delay);
        accept.SetActive(msg.Response);
        reject.SetActive(!msg.Response);
        yield return new WaitForSeconds(displayDuration);
        Hide();
    }

    private void Hide()
    {
        accept.SetActive(false);
        reject.SetActive(false);
    }
}
