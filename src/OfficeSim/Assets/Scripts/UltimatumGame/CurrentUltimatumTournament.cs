using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public sealed class CurrentUltimatumTournament : ScriptableObject
{
    private UltimatumTournament _tourney;

    public void Init(UltimatumTournament tourney) => _tourney = tourney;

    public UltimatumPlayer Player(int id) => _tourney.Group.Players.Single(p => p.Id == id);
}
