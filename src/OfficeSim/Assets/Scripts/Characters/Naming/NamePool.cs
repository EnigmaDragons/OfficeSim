using UnityEngine;

[CreateAssetMenu]
public sealed class NamePool : ScriptableObject
{
    public string GetFemaleName() => NameData.FemaleNames.Random();
    public string GetMaleName() => NameData.MaleNames.Random();
}
