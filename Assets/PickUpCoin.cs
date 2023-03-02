using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public int coins = 0;
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Coin"))
        {
            GameObject.Instantiate(particlePrefab, collision.collider.gameObject.transform.position, Quaternion.identity);

            GameObject.Destroy(collision.collider.gameObject);

            coins = coins + 1;

            this.GetComponent<AudioSource>().Play();

            Debug.Log(coins);
        }
    }
}
