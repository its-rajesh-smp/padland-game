using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class WebEventController : MonoBehaviour
{
    /// LISTENERS ///

    /// <summary>
    /// Function to be called when a player joins
    /// </summary>
    public void PlayerJoinListener(object playerDetails)
    {
        PlayerDetails player = JsonConvert.DeserializeObject<PlayerDetails>(playerDetails.ToString());
        Debug.Log(player);
        GamePlayController.instance.SpawnAPlayer(player, false);
    }


    /// <summary>
    /// Function to be called when the current user joined
    /// </summary>
    public void CurrentUserJoinListener(object playerDetails)
    {
        PlayerDetails player = JsonConvert.DeserializeObject<PlayerDetails>(playerDetails.ToString());
        Debug.Log(player);
        GamePlayController.instance.SpawnAPlayer(player, true);
    }


    /// <summary>
    /// Function to be called when a player leaves
    /// </summary>
    public void PlayerLeftListener(object playerDetails)
    {
        PlayerDetails player = JsonConvert.DeserializeObject<PlayerDetails>(playerDetails.ToString());
        Debug.Log(player);
        GamePlayController.instance.RemoveAPlayer(player);
    }


    /// <summary>
    /// Function to be called when a player moves
    /// </summary>
    public void PlayerMovementListener(object playerDetails)
    {
        PlayerDetails player = JsonConvert.DeserializeObject<PlayerDetails>(playerDetails.ToString());
        Debug.Log(player);
        GamePlayController.instance.MoveAPlayer(player);

    }

    /// <summary>
    /// Function to be called when a player interacts
    /// </summary>
    public void PlayerInteractListener(object playerDetails)
    {
        PlayerDetails player = JsonConvert.DeserializeObject<PlayerDetails>(playerDetails.ToString());
        Debug.Log(player);
    }


    /// EMITTERS ///

    /// <summary>
    /// Function to be call a JS function when a player moves
    /// </summary>
    public void PlayerMoveEmitter(PlayerDetails playerDetails)
    {
        Application.ExternalCall("playerMoveListener", JsonConvert.SerializeObject(playerDetails));
    }



    /// <summary>
    /// Function to be call a JS function when a player interacts with another player
    /// </summary>
    public void PlayerInteractEmitter(List<PlayerDetails> playerDetailsList)
    {
        Application.ExternalCall("playerInteractListener", JsonConvert.SerializeObject(playerDetailsList));
    }
}
