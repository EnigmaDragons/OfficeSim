using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityTemplateProjects.UltimatumGame;

public class PlayTournament : OnMessage<UltimatumPlayerReady>
{
    [SerializeField] private int numberOfPlayers;
    [SerializeField] private PlayerPool pool;
    [SerializeField] private int numberOfRounds;
    
    private UltimatumTournament _tourney;
    private HashSet<int> _readyPlayers;
    
    void Start()
    {
        _tourney = UltimatumTournament.CreateGroup(numberOfPlayers);
        _tourney.Group.Players.ForEach(p => pool.Init(p.Id));
        _readyPlayers = new HashSet<int>();
        _tourney.PrepareRound();
    }

    void Update()
    {
        if (_readyPlayers.Count == _tourney.Group.Players.Count())
        {
            _tourney.PlayRounds(1);
            _readyPlayers.Clear();
        }
    }

    protected override void Execute(UltimatumPlayerReady msg)
    {
        _readyPlayers.Add(msg.Id);
    }
}