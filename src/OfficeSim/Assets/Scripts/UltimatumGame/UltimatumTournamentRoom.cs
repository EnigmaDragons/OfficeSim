using UnityEngine;

public class UltimatumTournamentRoom : OnMessage<UltimatumRoundPairingsReady>
{
    [SerializeField] private int roomNumber;
    [SerializeField] private Transform proposerSpawn;
    [SerializeField] private Transform responderSpawn;
    [SerializeField] private Transform proposerPlay;
    [SerializeField] private Transform responderPlay;
    [SerializeField] private PlayerPool pool;

    private void Start() => Message.Publish(new UltimatumRoomSetup(roomNumber));

    protected override void Execute(UltimatumRoundPairingsReady msg)
    {
        var pairing = msg.Pairings.Find(r => r.RoomNumber == roomNumber);
        if (pairing == null)
            return;
        
        var proposer = pool.SpawnAt(pairing.Proposer.Id, proposerSpawn.position);
        proposer.GetComponent<PlayUltimatumGame>().SetPath(UltimatumRole.Proposer, proposerSpawn.position, proposerPlay.position);
        
        var responder = pool.SpawnAt(pairing.Responder.Id, responderSpawn.position);
        responder.GetComponent<PlayUltimatumGame>().SetPath(UltimatumRole.Responder, responderSpawn.position, responderPlay.position);
    }
}