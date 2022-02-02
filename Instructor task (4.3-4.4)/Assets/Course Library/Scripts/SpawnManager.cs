using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    private float x,z;
    public int enemyCount;
    private int waveNumber=1;
    void Start()
    {
        SpawnWave(waveNumber);
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0){
            waveNumber++;
            SpawnWave(waveNumber);
        }
    }
    private void SpawnWave(int noOfEnemy){
        for(int i=0; i<noOfEnemy; i++){
          Instantiate(prefab,funcPos(),prefab.transform.rotation);
        }
    }
    private Vector3 funcPos(){
         x= Random.Range(-9,9);
         z= Random.Range(-9,9);
        Vector3 pos= new Vector3(x,0,z);
        return pos;
    }
}
