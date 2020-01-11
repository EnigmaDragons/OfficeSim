
public sealed class UltimatumTournamentFinished
{
    public UltimatumGroup Group { get; }

    public UltimatumTournamentFinished(UltimatumTournament tourney) : this(tourney.Group) {}
    public UltimatumTournamentFinished(UltimatumGroup group) => Group = group;
}
