using UltimatumGame.Events;
using UnityEngine;

public static class UltimatumRound
{
    public static void Play(UltimatumRoundPairing pairing)
    {
        var proposer = pairing.Proposer;
        var responder = pairing.Responder;

        var amount = 100;
        var proposal = proposer.Strategy.Proposal.ProposeSplit(responder.State);
        var proposerAmount = Mathf.CeilToInt(proposal.ProposerRatio * amount);
        var responderAmount = amount - proposerAmount;
        Message.Publish(new ProposalPresented
        {
            Pairing = pairing,
            ProposerAmount = proposerAmount,
            ResponderAmount = responderAmount
        });
        
        var response = responder.Strategy.Response.Evaluate(proposer.State, proposal);
        Message.Publish(new ProposalResponseGiven
        {
            Pairing = pairing,
            Response = response
        });
        var proposerWinnings = response ? proposerAmount : 0;
        var responderWinnings = response ? responderAmount : 0;
        
        proposer.State.MarkGameComplete(UltimatumRole.Proposer, proposerWinnings);
        responder.State.MarkGameComplete(UltimatumRole.Responder, responderWinnings);
        Message.Publish(new UltimatumRoundPairingResult
        {
            Pairing = pairing,
            ProposerAmount = proposerAmount,
            ResponderAmount = responderAmount,
            WasAccepted = response
        });
    }
}
