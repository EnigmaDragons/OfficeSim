using System;

[Serializable]
public sealed class UltimatumPlayerState
{
    public int NumRoundsPlayed { get; set; }
    public int Winnings { get; set; }

    public void MarkGameComplete(int winnings)
    {
        NumRoundsPlayed++;
        Winnings += winnings;
    }
}
