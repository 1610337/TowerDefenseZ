using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;

    public Transform UFOsmall;
    public Transform UFOmediocre;
    public Transform UFOboss;
    public Transform UFOtank;
    public Transform UFOfasterstronger;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountDownText;
  //  public Text waveCounter;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountDownText.text = string.Format("{0:00.00}", countdown); //Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
      //  waveCounter.text = waveIndex.ToString();
        PlayerStats.Rounds++;

        
        //for(int i =0; i< waveIndex; i++)
        //    
        //{
        //    SpawnEnemy(enemyPrefab);
        //    yield return new WaitForSeconds(0.5f);
        //   
        //}

        if (waveIndex == 1){
            SpawnEnemy(UFOsmall);
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy(UFOsmall);
            yield return new WaitForSeconds(0.5f);
        }
        else if (waveIndex == 2)
        {
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOsmall);
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
        }
        else if (waveIndex == 3)
        {
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOsmall);
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
        }
        else if (waveIndex == 4)
        {
            SpawnEnemy(UFOboss);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOsmall);
            yield return new WaitForSeconds(0.5f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOfasterstronger);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);

            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOmediocre);
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(UFOboss);
            yield return new WaitForSeconds(0.3f);
        }
        else
        {
            for(int i =0; i< waveIndex; i++)
                
            {
                SpawnEnemy(UFOsmall);
                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(UFOmediocre);
                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(UFOboss);
                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(UFOtank);
                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(UFOfasterstronger);
                yield return new WaitForSeconds(0.5f);

            }
        }

        yield return new WaitForSeconds(0.5f);
    }
    void SpawnEnemy(Transform enemyTypePrefab)
    {
        Instantiate(enemyTypePrefab, spawnPoint.position, spawnPoint.rotation);
    }

}