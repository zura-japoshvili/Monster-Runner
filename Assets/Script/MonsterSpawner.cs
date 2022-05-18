using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject spawnedMonsters;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0,2);

            spawnedMonsters = Instantiate(monsterReference[randomIndex]);

            // leftside
            if(randomSide == 0){
                spawnedMonsters.transform.position = leftPos.position;
                spawnedMonsters.GetComponent<Monster>().speed = Random.Range(4, 10);
            }else{
                // rightside
                spawnedMonsters.transform.position = rightPos.position;
                spawnedMonsters.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonsters.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        }
    }
}
