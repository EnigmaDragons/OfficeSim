using System.Collections.Generic;
using System.Linq;

namespace UnityTemplateProjects.UltimatumGame
{
    public sealed class UltimatumTournament
    {
        public UltimatumGroup Group { get; }

        private UltimatumTournament(UltimatumGroup g) 
            => Group = g;

        public static UltimatumTournament CreateGroup(int numPlayers) =>
            new UltimatumTournament(
                new UltimatumGroup(Enumerable.Range(0, numPlayers)
                    .Select(x => new UltimatumPlayer(UltimateStrategyGeneration.Generate()))));

        public void PlayRounds(int numRounds) 
            => Enumerable.Range(0, numRounds).ForEach(_ => PlayRound());

        private void PlayRound() 
            => GetRandomRoundPairings().ForEach(p => UltimatumRound.Play(p.Proposer, p.Responder));

        private List<UltimatumRoundPairing> GetRandomRoundPairings()
        {
            var pairings = new List<UltimatumRoundPairing>();
            var unpairedPlayers = Group.Players.ToList().Shuffled();
            for (var i = 0; i < unpairedPlayers.Count - 1; i += 2)
                pairings.Add(new UltimatumRoundPairing(unpairedPlayers[i], unpairedPlayers[i + 1]));
            return pairings;
        }
    }
}
