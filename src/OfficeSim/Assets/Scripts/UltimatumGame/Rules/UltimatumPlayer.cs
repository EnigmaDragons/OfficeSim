
public sealed class UltimatumPlayer
{
    public int Id { get; }
    public string Name { get; }

    public UltimatumStrategy Strategy { get; }
    public UltimatumPlayerState State { get; }

    public UltimatumPlayer(int id, string name, UltimatumStrategy strategy)
    {
        Strategy = strategy;
        Id = id;
        Name = name;
        State = new UltimatumPlayerState(Id);
    }
}
