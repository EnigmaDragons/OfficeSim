namespace UnityTemplateProjects.UltimatumGame
{
    public sealed class UltimatumRoundPairing
    {
        public UltimatumPlayer Proposer { get; }
        public UltimatumPlayer Responder { get; }

        public UltimatumRoundPairing(UltimatumPlayer proposer, UltimatumPlayer responder)
        {
            Proposer = proposer;
            Responder = responder;
        }
    }
}
