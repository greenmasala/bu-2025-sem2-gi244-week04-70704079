using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AnimalPrefabs;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            float x = Random.Range(-10, 11);
            //var animalSpawned = AnimalPrefabs[Random.Range(0, AnimalPrefabs.Length)];
            //Instantiate(animalSpawned, new Vector3(x, 0, 20), Quaternion.Euler(0, 180, 0));

            int animalIndex = Random.Range(0, AnimalPrefabs.Length);

            if (AnimalPrefabs[animalIndex] != null)
            {
                Instantiate(AnimalPrefabs[animalIndex], new Vector3(x, 0, 20), Quaternion.Euler(0, 180, 0));
            }
            else
            {
                Debug.Log("Null prefab at index: " + animalIndex);
            }
        }
    }
}
