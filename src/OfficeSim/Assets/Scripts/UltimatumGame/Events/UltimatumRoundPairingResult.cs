namespace UltimatumGame.Events
{
    public sealed class UltimatumRoundPairingResult
    {
        public UltimatumRoundPairing Pairing { get; set; }
        public int ProposerAmount { get; set; }
        public int ResponderAmount { get; set; }
        public bool WasAccepted { get; set; }
    }
}
