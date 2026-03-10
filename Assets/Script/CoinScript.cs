using UnityEngine;


public class CoinScript : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {

        RocketMovement rocketRM = other.GetComponent<RocketMovement>();

        if(rocketRM != null) {
            rocketRM.coins++;
            Debug.Log("Coins collected : " + rocketRM.coins);
            Destroy(gameObject);
        }
    }
}
