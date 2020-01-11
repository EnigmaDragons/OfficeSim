using System.Collections.Generic;
using UnityEngine;

public sealed class CharacterDescriptors : MonoBehaviour
{
    [SerializeField] private List<string> keys;
    [SerializeField] private List<string> values;

    public string this[string key]
    {
        get
        {
            var index = keys.IndexOf(key.ToLowerInvariant());
            return index >= 0 ? values[index] : "Unknown";
        }
    }

    public void Set(string key, string value)
    {
        var index = keys.IndexOf(key.ToLowerInvariant());
        if (index >= 0)
            values[index] = value;
        else
        {
            keys.Add(key.ToLowerInvariant());
            values.Add(value);
        }
    }
}
