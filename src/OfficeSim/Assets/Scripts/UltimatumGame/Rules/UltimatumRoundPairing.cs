public sealed class UltimatumRoundPairing
{
    public int RoomNumber { get; }
    public UltimatumPlayer Proposer { get; }
    public UltimatumPlayer Responder { get; }

    public UltimatumRoundPairing(int room, UltimatumPlayer proposer, UltimatumPlayer responder)
    {
        RoomNumber = room;
        Proposer = proposer;
        Responder = responder;
    }
}
