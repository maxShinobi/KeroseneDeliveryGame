using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] int lostKeroseneValue;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    bool grounded;

    private void Start()
    {
        Player.transform.rotation = originalRotation;
        grounded = true;
    }

    private void FixedUpdate()
    {
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRotation = new Quaternion(Player.transform.rotation.w, Player.transform.rotation.y, Player.transform.rotation.x, Player.transform.rotation.z);

/*        RaycastHit hit;

        if (Physics.Raycast(Player.transform.position, Vector3.up, out hit, 10))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red, 999);
            if (hit.transform.tag == "Ground")
            {
                grounded = false;
                Debug.Log("up");
            }

        } else
        {
            grounded = true;
        }
        if (Physics.Raycast(Player.transform.position, Vector3.right, out hit, 1))
        {
            grounded = false;
            Debug.Log("right");
        }
        else
        {
            grounded = true;
        }
        if (Physics.Raycast(Player.transform.position, Vector3.left, out hit, 1))
        {
            grounded = false;
            Debug.Log("left");
        }
        else
        {
            grounded = true;
        }
        if (Physics.Raycast(Player.transform.position, Vector3.back, out hit, 1))
        {
            grounded = false;
            Debug.Log("back");
        }
        else
        {
            grounded = true;
        }
        if (Physics.Raycast(Player.transform.position, Vector3.forward, out hit, 1))
        {
            grounded = false;
            Debug.Log("fwd");
        }
        else
        {
            grounded = true;
        }*/
    }

    public void RespawnCar()
    {
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Player.transform.position = new Vector3(originalPosition.x, 10, originalPosition.z);
        
        if(!grounded)
        {
            //originalRotation = Player.transform.rotation;
            Player.transform.rotation = new Quaternion(originalRotation.x, originalRotation.y, originalRotation.z, originalRotation.w);
        }

        PlayerLosesSomeKerosene();
    }

    private void PlayerLosesSomeKerosene()
    {
        if(PlayerKerosene.instance.currentValue >= 20)
        {
            PlayerKerosene.instance.DepleteTheKeroseneBar(lostKeroseneValue);
        }
    }
}
