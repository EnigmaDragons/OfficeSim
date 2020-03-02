using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayTournament : OnMessage<UltimatumPlayerReady, UltimatumPlayerFinished, UltimatumRoomSetup>
{
    [SerializeField] private int numberOfPlayers;
    [SerializeField] private PlayerPool pool;
    [SerializeField] private int numberOfRounds;
    [SerializeField] private CurrentUltimatumTournament current;

    private UltimatumTournament _tourney;
    private HashSet<int> _rooms;
    private HashSet<int> _readyPlayers;
    private HashSet<int> _finishedPlayers;
    private int NumPlayersExpected;
    private int _currentRound = 0;
    private bool _started;

    void Awake()
    {
        _rooms = new HashSet<int>();
        _readyPlayers = new HashSet<int>();
        _finishedPlayers = new HashSet<int>();
        _tourney = UltimatumTournament.CreateGroup(numberOfPlayers);
    }
    
    void Start()
    {
        Debug.Log("Started Tournament Setup");
        _tourney.Group.Players.ForEach(p => pool.Init(p.Id, p.Character));
        current.Init(_tourney);
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
                CompleteTournament();
        }
    }

    private void CompleteTournament()
    {
        _tourney.CompleteTournament();
        Message.Publish(new UltimatumTournamentFinished(_tourney));
    }

    protected override void Execute(UltimatumPlayerReady msg) => _readyPlayers.Add(msg.Id);
    protected override void Execute(UltimatumPlayerFinished msg) => _finishedPlayers.Add(msg.Id);
    protected override void Execute(UltimatumRoomSetup msg)
    {
        if (_rooms == null)
            throw new Exception("Room Setup is occurring before Tournament is Setup");
        _rooms.Add(msg.RoomNumber);
        UpdateNumPlayersExpected();
    }

    private void UpdateNumPlayersExpected()
    {
        NumPlayersExpected = Math.Min(_rooms.Count() * 2, _tourney.Group.Players.Count());
    }
}
