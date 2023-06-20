using UnityEngine;

public class ItemFound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            GameManager.instance.ItemFound();
            collision.gameObject.SetActive(false);
        }
    }
}
