using UnityEngine;

public class ItemFound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "collectable")
        {
            GameManager.instance.ItemFound();
            collision.gameObject.SetActive(false);
        }
    }
}
