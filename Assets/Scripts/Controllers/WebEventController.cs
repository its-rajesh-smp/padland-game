using Newtonsoft.Json;
using UnityEngine;

public class WebEventController : MonoBehaviour
{
    /// LISTENERS ///

    /// <summary>
    /// Function to be called when a player joins
    /// </summary>
    public void PlayerJoinListener(object playerDetails)
    {
        PlayerDetails player = JsonConvert.DeserializeObject<PlayerDetails>(playerDetails.ToString());

    }


    /// <summary>
    /// Function to be called when the current user joined
    /// </summary>
    public void CurrentUserJoinListener(object playerDetails)
    {

    }


    /// <summary>
    /// Function to be called when a player leaves
    /// </summary>
    public void PlayerLeftListener(object playerDetails)
    {

    }


    /// <summary>
    /// Function to be called when a player moves
    /// </summary>
    public void PlayerMovementListener(object playerDetails)
    {

    }

    /// <summary>
    /// Function to be called when a player interacts
    /// </summary>
    public void PlayerInteractListener(object playerDetails)
    {

    }


    /// EMITTERS ///

    /// <summary>
    /// Function to be call a JS function when a player moves
    /// </summary>
    public void PlayerMoveEmitter()
    {

    }



    /// <summary>
    /// Function to be call a JS function when a player interacts with another player
    /// </summary>
    public void PlayerInteractEmitter()
    {

    }
}
