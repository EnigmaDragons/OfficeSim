public static class UltimatumPlayerStateExtensions
{
    public static void MarkGameComplete(this UltimatumPlayerState s, UltimatumRole role, int winnings)
    {
        s.LastRoundRole = role;
        s.NumRoundsPlayed++;
        s.Winnings += winnings;
    }
}
