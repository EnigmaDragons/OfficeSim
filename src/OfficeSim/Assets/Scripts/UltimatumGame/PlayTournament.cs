using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayTournament : OnMessage<UltimatumPlayerReady, UltimatumPlayerFinished, UltimatumRoomSetup>
{
    [SerializeField] private int numberOfPlayers;
    [SerializeField] private PlayerPool pool;
    [SerializeField] private int numberOfRounds;

    private UltimatumTournament _tourney;
    private HashSet<int> _rooms;
    private HashSet<int> _readyPlayers;
    private HashSet<int> _finishedPlayers;
    private int NumPlayersExpected;
    private int _currentRound = 0;
    private bool _started;
    
    void Start()
    {
        _tourney = UltimatumTournament.CreateGroup(numberOfPlayers);
        _tourney.Group.Players.ForEach(p => pool.Init(p.Id));
        _rooms = new HashSet<int>();
        _readyPlayers = new HashSet<int>();
        _finishedPlayers = new HashSet<int>();
        Debug.Log("Tournament Setup");
    }

    void Update()
    {
        if (!_started && _rooms.Any())
        {
            _started = true;
            _tourney.PrepareRound();
            Debug.Log("Tournament Started");
        }
        
        if (_readyPlayers.Count == NumPlayersExpected)
        {
            _tourney.PlayRounds(1);
            _currentRound++;
            _readyPlayers.Clear();
        }

        if (_finishedPlayers.Count == NumPlayersExpected)
        {
            _finishedPlayers.Clear();
            if (_currentRound < numberOfRounds)
                _tourney.PrepareRound();
            else
                Message.Publish(new UltimatumTournamentFinished(_tourney));
        }
    }

    protected override void Execute(UltimatumPlayerReady msg) => _readyPlayers.Add(msg.Id);
    protected override void Execute(UltimatumPlayerFinished msg) => _finishedPlayers.Add(msg.Id);
    protected override void Execute(UltimatumRoomSetup msg)
    {
        _rooms.Add(msg.RoomNumber);
        UpdateNumPlayersExpected();
    }

    private void UpdateNumPlayersExpected()
    {
        NumPlayersExpected = Math.Min(_rooms.Count() * 2, _tourney.Group.Players.Count());
    }
}
