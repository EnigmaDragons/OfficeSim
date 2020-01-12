using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    [SerializeField] private CharacterId[] prototypes;
    [SerializeField] private Transform nowhere;
    [SerializeField] private Mesh[] females;
    [SerializeField] private Mesh[] males;
    
    private readonly Dictionary<int, GameObject> characters = new Dictionary<int, GameObject>();

    public void Init(int id, BasicCharacterTraits ch)
    {
        var character = Instantiate(prototypes.Random().gameObject, nowhere.position, Quaternion.identity);
        character.SetActive(false);
        character.GetComponent<CharacterId>().Id = id;
        character.GetComponent<CharacterDescriptors>().Set("Name", ch.Name);
        character.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh =
            ch.Sex == CharacterSex.Female 
                ? females.Random() 
                : males.Random();
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
