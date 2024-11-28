using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public WebEventController webEventController;

    private Vector3 _DEFAULT_SPAWN_POINT = new Vector3(0.02f, 0.99f, 0);
    private List<PlayerController> spawnedPlayers = new();



    [Header("Prefab References")]
    public GameObject playerPrefab;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    public GameObject currentPlayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerDetails playerDetails = new PlayerDetails("1", "John Doe", 0, 0);
        SpawnAPlayer(playerDetails, true);
    }


    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Function to spawn a player
    /// </summary>
    public void SpawnAPlayer(PlayerDetails playerDetails, bool currentUser = false)
    {
        GameObject spawnedPlayer = Instantiate(playerPrefab, _DEFAULT_SPAWN_POINT, Quaternion.identity);
        spawnedPlayer.GetComponent<PlayerController>().SetPlayerDetails(playerDetails);
        spawnedPlayers.Add(spawnedPlayer.GetComponent<PlayerController>());

        // if camera follow is enabled then follow that player        
        if (currentUser)
        {
            cinemachineVirtualCamera.Follow = spawnedPlayer.transform;
            cinemachineVirtualCamera.LookAt = spawnedPlayer.transform;
            currentPlayer = spawnedPlayer;
        }
    }

    /// <summary>
    /// Function to remove a player
    /// </summary>
    /// <param name="playerDetails"></param>
    public void RemoveAPlayer(PlayerDetails playerDetails)
    {
        for (int i = 0; i < spawnedPlayers.Count; i++)
        {
            if (spawnedPlayers[i].playerDetails.playerId == playerDetails.playerId)
            {
                Destroy(spawnedPlayers[i].gameObject);
                spawnedPlayers.RemoveAt(i);
            }
        }
    }



    public void MoveAPlayer(PlayerDetails playerDetails)
    {
        for (int i = 0; i < spawnedPlayers.Count; i++)
        {
            if (spawnedPlayers[i].playerDetails.playerId == playerDetails.playerId)
            {
                spawnedPlayers[i].transform.position = new Vector3(playerDetails.posX, playerDetails.posY, 0);
            }
        }
    }
}
