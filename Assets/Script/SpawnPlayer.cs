/*READ ME
 * This script spawns a player prefab in a networked multiplayer game using Photon.
 * If no players are present, the prefab is instantiated at the object's position;
 * otherwise, it's placed offset from the original position based on the number of players.
 */
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    public GameObject playePrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.CountOfPlayers == 0)
        {
            // Spawn the player prefab at the current position if no other players exist
            PhotonNetwork.Instantiate(playePrefab.name, this.transform.position, this.transform.rotation);
        }
        else
        {
            // Calculate a position offset based on the number of players
            Vector3 spawnPos = this.transform.position + new Vector3(25 * PhotonNetwork.CountOfPlayers, 0, 0);
            PhotonNetwork.Instantiate(playePrefab.name, spawnPos, this.transform.rotation);
        }
    }
}

