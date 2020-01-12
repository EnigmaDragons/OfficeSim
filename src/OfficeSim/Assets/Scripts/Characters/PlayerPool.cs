using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    [SerializeField] private CharacterId[] prototypes;
    [SerializeField] private Transform nowhere;
    
    private readonly Dictionary<int, GameObject> characters = new Dictionary<int, GameObject>();

    public void Init(int id, string playerName)
    {
        var character = Instantiate(prototypes.Random().gameObject, nowhere.position, Quaternion.identity);
        character.SetActive(false);
        character.GetComponent<CharacterId>().Id = id;
        character.GetComponent<CharacterDescriptors>().Set("Name", playerName);
        characters[id] = character;
    }
    
    public GameObject SpawnAt(int id, Vector3 position)
    {
        if (!characters.ContainsKey(id))
            throw new InvalidOperationException($"No Player {id} initialized");

        var character = characters[id];
        character.transform.position = position;
        character.SetActive(true);
        return character;
    }
}
