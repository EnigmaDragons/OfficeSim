using UnityEngine;

public sealed class UltimatumStrategy
{
    public string Description => $"{Proposal.Description()} {Response.Description()}";
    public UltimatumProposalStrategy Proposal { get; }
    public UltimatumResponseStrategy Response { get; }

    public UltimatumStrategy(UltimatumProposalStrategy proposal, UltimatumResponseStrategy response)
    {
        Proposal = proposal;
        Response = response;
    }
}

public interface UltimatumProposalStrategy
{
    string Description();
    UltimatumOffer ProposeSplit(UltimatumPlayerState responder);
}

public interface UltimatumResponseStrategy
{
    string Description();
    bool Evaluate(UltimatumPlayerState proposer, UltimatumOffer split);
}

public sealed class UltimatumOffer
{
    public float ProposerRatio { get; } // 0.0f - 1.0f
    public float ResponderRatio => 1f - ProposerRatio;

    public UltimatumOffer(float proposerRatio) => ProposerRatio = Mathf.Clamp(proposerRatio, 0f, 1f);
}

public enum UltimatumRole
{
    None,
    Proposer,
    Responder
}

public sealed class UltimatumPlayerState
{
    public readonly int PlayerId;
    
    public UltimatumRole LastRoundRole;
    public int NumRoundsPlayed;
    public int Winnings;

    public UltimatumPlayerState(int id) => PlayerId = id;
}
