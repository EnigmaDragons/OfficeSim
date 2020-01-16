using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public static class Rng
{
    private static readonly Random Instance = new Random(Guid.NewGuid().GetHashCode());

    public static bool Bool() => Int(2) == 1;
    public static int Int() => Int(int.MaxValue);
    public static int Int(int max) => Instance.Next(max);
    public static int Int(int min, int max) => Instance.Next(min, max);
    public static float Float() => (float) Instance.NextDouble();
    public static float Float(float min, float max) => (float) Dbl(min, max);
    public static double Dbl() => Instance.NextDouble();
    public static double Dbl(double min, double max) => min + (max - min) * Dbl();
    public static KeyValuePair<T, T2> Random<T, T2>(this Dictionary<T, T2> dictionary) => dictionary.ElementAt(Int(dictionary.Count));
    public static T Random<T>(this T[] array) => array[Int(array.Length)];
    public static T Random<T>(this List<T> list) => list[Int(list.Count)];
    public static List<T> Weighted<T>(this List<Weighted<T>> items) => items.SelectMany(i => Enumerable.Range(0, i.Weight).Select(_ => i.Item)).ToList();

    public static T[] Shuffled<T>(this T[] arr)
    {
        var shuffled = arr.ToArray();
        for (var n = shuffled.Length - 1; n > 1; n--)
        {
            var k = Instance.Next(n + 1);
            var value = shuffled[k];
            shuffled[k] = shuffled[n];
            shuffled[n] = value;
        }
        return shuffled;
    }
    
    public static List<T> Shuffled<T>(this List<T> list)
    {
        var shuffled = list.ToList();
        for (var n = shuffled.Count - 1; n > 1; n--)
        {
            var k = Instance.Next(n + 1);
            var value = shuffled[k];
            shuffled[k] = shuffled[n];
            shuffled[n] = value;
        }
        return shuffled;
    }
}
