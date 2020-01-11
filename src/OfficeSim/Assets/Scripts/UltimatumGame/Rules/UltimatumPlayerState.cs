using System;

[Serializable]
public sealed class UltimatumPlayerState
{
    public int NumRoundsPlayed;
    public int Winnings;
    
    public void MarkGameComplete(int winnings)
    {
        NumRoundsPlayed++;
        Winnings += winnings;
    }
}
