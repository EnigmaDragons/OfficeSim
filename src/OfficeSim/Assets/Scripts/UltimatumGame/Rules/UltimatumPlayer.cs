
using UnityEngine;

public sealed class UltimatumPlayer
{
    public int Id { get; }

    public UltimatumStrategy Strategy { get; }
    public UltimatumPlayerState State { get; } = new UltimatumPlayerState();

    public UltimatumPlayer(int id, UltimatumStrategy strategy)
    {
        Debug.Log($"Player {id}");
        Strategy = strategy;
        Id = id;
    }
}
