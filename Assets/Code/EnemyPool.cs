using System.Collections.Generic;
using UnityEngine;

namespace Dante {
    public class EnemyPool : MonoBehaviour {
        #region Knobs

        [SerializeField] protected GameObject enemyPrefab;
        [SerializeField] protected Transform spawnPoint;
        [SerializeField] protected Transform playerTransform;
        [SerializeField] protected int poolSize = 10;

        #endregion

        #region RuntimeVariables

        protected List<GameObject> enemyPool;
        [SerializeField] protected float spawnRate = 1f;
        protected float spawnTimer;

        #endregion

        #region UnityMethods

        private void Start() {
            enemyPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++) {
                GameObject enemy = Instantiate(enemyPrefab, gameObject.transform);
                enemy.SetActive(false);
                enemyPool.Add(enemy);
                enemy.GetComponent<EnemyBehaviour>().PlayerTransform = playerTransform;
            }
        }

        private void Update() {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate) {
                SpawnEnemy();
                spawnTimer = 0f;
                transform.GetChild(0).localPosition = new Vector3(Random.Range(-5f,5f), transform.GetChild(0).localPosition.y, Random.Range(-5f, 5f));
            }
        }

        #endregion

        #region PublicMethods



        #endregion

        #region LocalMethods

        protected void SpawnEnemy() {
            GameObject enemy = GetPooledBullet();
            if (enemy != null) {
                enemy.transform.position = spawnPoint.position;
                enemy.transform.rotation = spawnPoint.rotation;
                enemy.SetActive(true);
            }
        }

        protected GameObject GetPooledBullet() {
            foreach (GameObject enemy in enemyPool) {
                if (!enemy.activeInHierarchy) {
                    return enemy;
                }
            }
            return null;
        }

        #endregion

        #region GettersSetters



        #endregion
    }
}