using System.Collections.Generic;
using System.Linq;

namespace UnityTemplateProjects.UltimatumGame
{
    public sealed class UltimatumTournament
    {
        public UltimatumGroup Group { get; }
        public List<UltimatumRoundPairing> CurrentRoundPairings { get; private set; }

        private UltimatumTournament(UltimatumGroup g) 
            => Group = g;

        public static UltimatumTournament CreateGroup(int numPlayers) =>
            new UltimatumTournament(
                new UltimatumGroup(Enumerable.Range(0, numPlayers)
                    .Select(x => new UltimatumPlayer(UltimateStrategyGeneration.Generate()))));

        public void PlayRounds(int numRounds) 
            => Enumerable.Range(0, numRounds).ForEach(_ => PlayRound());

        private void PlayRound()
        {
            if (CurrentRoundPairings == null)
                PrepareRound();
            
            CurrentRoundPairings.ForEach(UltimatumRound.Play);
            CurrentRoundPairings = null;
        }

        public void PrepareRound()
        {
            if (CurrentRoundPairings != null)
                return;
            
            CurrentRoundPairings = GetRandomRoundPairings();
        }
        
        private List<UltimatumRoundPairing> GetRandomRoundPairings()
        {
            var pairings = new List<UltimatumRoundPairing>();
            var unpairedPlayers = Group.Players.ToList().Shuffled();
            for (var i = 0; i < unpairedPlayers.Count - 1; i += 2)
                pairings.Add(new UltimatumRoundPairing(i / 2, unpairedPlayers[i], unpairedPlayers[i + 1]));
            Message.Publish(new UltimatumRoundPairingsReady(pairings));
            return pairings;
        }
    }
}
