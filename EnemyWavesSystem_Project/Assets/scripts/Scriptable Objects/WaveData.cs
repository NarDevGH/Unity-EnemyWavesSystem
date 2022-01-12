using UnityEngine;


[CreateAssetMenu(fileName = "New Wave Data", menuName = "Wave")]
public class WaveData : ScriptableObject
{
    public int ammount;
    public float startTime;
    public float spawnCooldown;

    [Tooltip("start when arent any enemy in game")]
    public bool emptyStart;

    public GameObject[] enemyVariants;
    public float[] variantsProbability;
}
