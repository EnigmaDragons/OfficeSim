using System.Linq;
using UnityEngine;

public class OnKeyPressToggle : MonoBehaviour
{
    [SerializeField] private KeyCode[] keys;
    [SerializeField] private GameObject[] targets;

    private void Update()
    {
        if (keys.Any(Input.GetKeyDown))
            targets.ForEach(t => t.SetActive(!t.activeSelf));
    }
}