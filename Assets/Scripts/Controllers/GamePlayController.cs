using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    private  Vector3 _DEFAULT_SPAWNPOINT = new Vector3(0.02f, 0.99f, 0);
    private List<PlayerController> spawnedPlayers = new();


    [Header("Prefab References")]
    public GameObject playerPrefab;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerDetails playerDetails = new PlayerDetails("1", "John Doe");

        SpawnAPlayer(playerDetails);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Function to spawn a player
    /// </summary>
    public void SpawnAPlayer(PlayerDetails playerDetails)
    {
       GameObject spawnedPlayer = Instantiate(playerPrefab, _DEFAULT_SPAWNPOINT, Quaternion.identity); 
       spawnedPlayer.GetComponent<PlayerController>().SetPlayerDetails(playerDetails);
       spawnedPlayers.Add(spawnedPlayer.GetComponent<PlayerController>());
    }
}
