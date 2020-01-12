
public sealed class UltimatumPlayer
{
    public int Id { get; }
    public string Name => Character.Name;
    public BasicCharacterTraits Character { get; }

    public UltimatumStrategy Strategy { get; }
    public UltimatumPlayerState State { get; }

    public UltimatumPlayer(int id, BasicCharacterTraits character, UltimatumStrategy strategy)
    {
        Strategy = strategy;
        Id = id;
        Character = character;
        State = new UltimatumPlayerState(Id);
    }
}
