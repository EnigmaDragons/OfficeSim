using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterDescriptors))]
public sealed class DisplayDescriptor : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private string descriptor;

    private CharacterDescriptors descriptors;

    private void Awake() => descriptors = GetComponent<CharacterDescriptors>();
    
    void Update()
    {
        text.text = descriptors[descriptor];
    }
}
