using System;

[Serializable]
public sealed class UltimatumStrategy
{
    public UltimatumProposalStrategy Proposal { get; }
    public UltimatumResponseStrategy Response { get; }

    public UltimatumStrategy(UltimatumStaticProposalStrategy proposal, UltimatumStaticResponderStrategy response)
    {
        Proposal = proposal;
        Response = response;
    }
}
