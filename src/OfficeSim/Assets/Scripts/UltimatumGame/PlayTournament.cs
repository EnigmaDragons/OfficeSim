using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayTournament : OnMessage<UltimatumPlayerReady, UltimatumPlayerFinished>
{
    [SerializeField] private int numberOfPlayers;
    [SerializeField] private PlayerPool pool;
    [SerializeField] private int numberOfRounds;
    
    private UltimatumTournament _tourney;
    private HashSet<int> _readyPlayers;
    private HashSet<int> _finishedPlayers;
    private int _currentRound = 0;
    
    void Start()
    {
        _tourney = UltimatumTournament.CreateGroup(numberOfPlayers);
        _tourney.Group.Players.ForEach(p => pool.Init(p.Id));
        _readyPlayers = new HashSet<int>();
        _finishedPlayers = new HashSet<int>();
        _tourney.PrepareRound();
    }

    void Update()
    {
        if (_readyPlayers.Count == _tourney.Group.Players.Count())
        {
            _tourney.PlayRounds(1);
            _currentRound++;
            _readyPlayers.Clear();
        }

        if (_finishedPlayers.Count == _tourney.Group.Players.Count())
        {
            _finishedPlayers.Clear();
            if (_currentRound < numberOfRounds)
                _tourney.PrepareRound();
            else
                Message.Publish(new UltimatumTournamentFinished(_tourney));
        }
    }

    protected override void Execute(UltimatumPlayerReady msg)
    {
        _readyPlayers.Add(msg.Id);
    }

    protected override void Execute(UltimatumPlayerFinished msg)
    {
        _finishedPlayers.Add(msg.Id);
    }
}
