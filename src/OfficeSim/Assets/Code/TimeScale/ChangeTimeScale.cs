using UnityEngine;

public sealed class ChangeTimeScale : MonoBehaviour
{
    public void SetTimeScale(float newValue) => Time.timeScale = newValue;
}
