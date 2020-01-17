using System.Collections.Generic;

namespace UltimatumGame.Rules
{
    public class TournamentPlacing
    {
        public int Place;
        public int NumberOfParticipants;
    }
    
    public sealed class UltimatumTournamentStats
    {
        public List<TournamentPlacing> Placings = new List<TournamentPlacing>();
    }
}
