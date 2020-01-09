using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    [SerializeField] private CharacterId[] prototypes;
    [SerializeField] private Transform nowhere;
    
    private Dictionary<int, GameObject> characters = new Dictionary<int, GameObject>();

    public void Init(int id)
    {
        var character = Instantiate(prototypes.Random().gameObject, nowhere.position, Quaternion.identity);
        character.SetActive(false);
        character.GetComponent<CharacterId>().Id = id;
        characters[id] = character;
    }
    
    public GameObject SpawnAt(int id, Vector3 position)
    {
        if (!characters.ContainsKey(id))
            Init(id);

        var character = characters[id];
        character.transform.position = position;
        character.SetActive(true);
        return character;
    }
}
