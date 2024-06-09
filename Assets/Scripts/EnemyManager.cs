using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _creationRadius;
    [SerializeField] private ChapterSettings _chapterSettings;
    private List<Enemy> _enemyList = new List<Enemy>(); // для размещения новых созданных врагов

    public void StartNewWave(int wave)
    {
        StopAllCoroutines();
         for (int i = 0; i < _chapterSettings.EnemyWavesArray.Length; i++)
         {
             if(_chapterSettings.EnemyWavesArray[i].NumberPerSecond[wave] > 0)
             {
                StartCoroutine(CreateEnemyInSeconds(_chapterSettings.EnemyWavesArray[i].Enemy, _chapterSettings.EnemyWavesArray[i].NumberPerSecond[wave]));
             }               
         }   
    }

    private IEnumerator CreateEnemyInSeconds(Enemy enemy, float enemyPerSecond)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / enemyPerSecond);
            Create(enemy);
        }
    }
    public void Create(Enemy enemy)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized; //случайная точка на окружности с радиусом 1

        Vector3 position = new Vector3(randomPoint.x, 0, randomPoint.y) * _creationRadius + _playerTransform.position;
        Enemy newEnemy = Instantiate(enemy, position, Quaternion.identity);
        newEnemy.Init(_playerTransform);
        _enemyList.Add(newEnemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(_playerTransform.position, Vector3.up, _creationRadius);
    }
#endif
}


