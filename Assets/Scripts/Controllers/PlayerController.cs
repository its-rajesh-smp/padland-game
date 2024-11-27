using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerDetails
{
    public string playerId = "-1";
    public string playerName = "John Doe";

    public PlayerDetails(string playerId, string playerName)
    {
        this.playerId = playerId;
        this.playerName = playerName;
    }
}


public class PlayerController : MonoBehaviour
{
    private const int _PLAYER_SPEED = 3;
    private Animator animator;
    private PlayerDetails _playerDetails;

    [Header("UI References")]
    public TextMeshProUGUI playerNameText;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = _PLAYER_SPEED * dir;
    }

    public void SetPlayerDetails(PlayerDetails playerDetails)
    {
        _playerDetails = playerDetails;
        playerNameText.text = _playerDetails.playerName;
    }
}