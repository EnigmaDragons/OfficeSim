using System.Collections.Generic;
using System.Linq;
using UltimatumGame.Rules;

public sealed class UltimatumTournament
{
    private int _roundNumber;
    
    public UltimatumGroup Group { get; }
    public List<UltimatumRoundPairing> CurrentRoundPairings { get; private set; }

    public UltimatumTournament(UltimatumGroup g) 
        => Group = g;

    public static UltimatumTournament CreateGroup(int numPlayers) =>
        new UltimatumTournament(
            new UltimatumGroup(Enumerable.Range(0, numPlayers)
                .Select(id => new UltimatumPlayer(id, BasicCharacterTraits.Random(), UltimatumStrategyGeneration.Generate()))
                .ToList()));

    public void CompleteTournament()
    {
        var standings = Group.Standings;
        for (var i = 0; i < standings.Length; i++)
            standings[i].TournamentStats.Placings.Add(
                new TournamentPlacing { NumberOfParticipants = standings.Length, Place = i + 1 });;
    }
    
    public void PlayRounds(int numRounds) 
        => Enumerable.Range(0, numRounds).ForEach(_ => PlayRound());

    private void PlayRound()
    {
        if (CurrentRoundPairings == null)
            PrepareRound();
        
        CurrentRoundPairings.ForEach(UltimatumRound.Play);
        CurrentRoundPairings = null;
        Message.Publish(new UltimatumRoundFinished(_roundNumber));
    }

    public void PrepareRound()
    {
        if (CurrentRoundPairings != null)
            return;
        
        CurrentRoundPairings = GetRandomRoundPairings();
    }

    private List<UltimatumRoundPairing> GetRandomRoundPairings()
    {
        _roundNumber++;
        var pairings = Group.Players.All(g => g.State.LastRoundRole == UltimatumRole.None)
            ? CreateRandomPairings() 
            : CreateSplitPairings();
        Message.Publish(new UltimatumRoundPairingsReady(_roundNumber, pairings));
        return pairings;
    }

    private List<UltimatumRoundPairing> CreateSplitPairings()
    {
        var pairings = new List<UltimatumRoundPairing>();
        var nextProposers = Group.Players.Where(x => x.State.LastRoundRole == UltimatumRole.Responder).ToList().Shuffled();
        var nextResponders = Group.Players.Where(x => x.State.LastRoundRole == UltimatumRole.Proposer).ToList().Shuffled();
        for (var i = 0; i < nextProposers.Count; i++)
            pairings.Add(new UltimatumRoundPairing(i, nextProposers[i], nextResponders[i]));
        return pairings;
    }

    private List<UltimatumRoundPairing> CreateRandomPairings()
    {
        var pairings = new List<UltimatumRoundPairing>();
        var unpairedPlayers = Group.Players.ToList().Shuffled();
        for (var i = 0; i < unpairedPlayers.Count - 1; i += 2)
            pairings.Add(new UltimatumRoundPairing(i / 2, unpairedPlayers[i], unpairedPlayers[i + 1]));
        return pairings;
    }
}

