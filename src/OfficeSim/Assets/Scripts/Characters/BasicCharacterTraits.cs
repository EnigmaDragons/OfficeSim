
public class BasicCharacterTraits
{
    public string Name { get; set; } = "Jane Doe";
    public CharacterSex Sex { get; set; }
    
    public static BasicCharacterTraits Random()
    {
        var sex = Rng.Random(new[] {CharacterSex.Female, CharacterSex.Male});
        
        return new BasicCharacterTraits
        {
            Name = NameData.Any(sex),
            Sex = sex
        };
    }
}