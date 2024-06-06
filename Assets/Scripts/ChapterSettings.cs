using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyWaves
{
    public Enemy Enemy;
    public float[] NumberPerSecond;
}

[CreateAssetMenu]
public class ChapterSettings : ScriptableObject
{
    public EnemyWaves[] EnemyWavesArray;
}
