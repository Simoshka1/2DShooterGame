using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bat;
    [SerializeField] private GameObject _skull;
    [SerializeField] private float _batInterval = 2.0f;
    [SerializeField] private float _skullInterval;

    private void Start()
    {
        StartCoroutine(spawnEnemy(_batInterval, _bat));
        StartCoroutine(spawnEnemy(_skullInterval, _skull));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-14.5f, 18.5f), Random.Range(0.5f, 21.5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
