using System.Collections;
using UnityEngine;

public class Simple_Spawn : MonoBehaviour,ISpawner
{
    [SerializeField,Min(0)] private float _range;
    public void StartWave(WaveData wave)
    {
        StartCoroutine("Spawner_Routine",wave);
    }

    private IEnumerator Spawner_Routine(WaveData wave) 
    {
        yield return new WaitForSeconds(wave.startTime);

        for (int i = 0; i < wave.ammount; i++) 
        {
            var enemyClone = Instantiate(wave.enemyVariants[0]);
            Enemys_Manager.instance.Add(enemyClone);

            enemyClone.transform.position = new Vector3(Random.Range(-_range, _range),
                                                        Random.Range(-_range, _range),
                                                        Random.Range(-_range, _range));

            yield return new WaitForSeconds(wave.spawnCooldown);
        }

        Enemys_Manager.instance.allEnemysSpawn = true;
    }
}
