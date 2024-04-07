using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterCollection;

    [SerializeField]
    private Transform leftPos,rightPos;

    private GameObject spawnedMonster;
    private int randomMonster;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnMonster(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));
            randomMonster = Random.Range(0,monsterCollection.Length);
            randomSide = Random.Range(0,2);
            spawnedMonster = Instantiate(monsterCollection[randomMonster]);

            if(randomSide == 0){
            spawnedMonster.transform.position = leftPos.position;
            spawnedMonster.GetComponent<EnemyMovement>().speed = Random.Range(4,10);
            }
            else{
            spawnedMonster.transform.position = rightPos.position;
            spawnedMonster.GetComponent<EnemyMovement>().speed = -Random.Range(4,10);
            spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f);
            }

            
        }
    }
}
