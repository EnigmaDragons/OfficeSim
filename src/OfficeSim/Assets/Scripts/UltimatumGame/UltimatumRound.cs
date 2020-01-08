using UnityEngine;

public static class UltimatumRound
{
    public static void Play(UltimatumPlayer player1, UltimatumPlayer player2)
    {
        var proposer = player1;
        var responder = player2;

        var amount = 100;
        var proposal = proposer.Strategy.Proposal.ProposeSplit();
        var response = responder.Strategy.Response.Evaluate(proposal);
        var proposerWinnings = Mathf.CeilToInt(response ? proposal * amount : 0);
        var responderWinnings = Mathf.CeilToInt(response ? amount - proposerWinnings : 0);
        
        proposer.State.MarkGameComplete(proposerWinnings);
        responder.State.MarkGameComplete(responderWinnings);
    }
}
