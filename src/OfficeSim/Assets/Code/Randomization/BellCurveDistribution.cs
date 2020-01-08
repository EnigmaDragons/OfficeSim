using System.Collections.Generic;
using UnityEngine;

public sealed class BellCurveDistribution
{
    public static IEnumerable<float> Generate(float mean, float stdDev, int n)
    {
        for (var i = 0; i < n; i++)
        {
            var u1 = Random.Range(0.0f, 1.0f);
            var u2 = Random.Range(0.0f, 1.0f);
            var randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
            yield return mean + stdDev * randStdNormal;
        }
    }
}
