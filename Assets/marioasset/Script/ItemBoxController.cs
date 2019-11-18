using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour
{
    public GameObject content;

    private Vector2 movepoint;
    private bool IsOpend;
    private bool IsActive;

    private SpriteRenderer sr;
    private BoxCollider2D[] m_colliders;
    private BoxCollider2D playerCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerCollider = player.GetComponent<BoxCollider2D>();
        }

        sr = GetComponent<SpriteRenderer>();
        m_colliders=GetComponentsInChildren<BoxCollider2D>();

        content = Instantiate(content);
        content.transform.position = transform.position;
        content.transform.SetParent(gameObject.transform);
        content.gameObject.SetActive(false);

        IsOpend = false;
        IsActive = true;

        movepoint = (Vector2)transform.position + new Vector2(0.0f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpend == true && IsActive == true)
        {
            content.transform.position = Vector2.Lerp(content.transform.position, movepoint, 0.35f);
            sr.color = Color.Lerp(sr.color, Color.grey, 0.4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_colliders[1].IsTouching(playerCollider) && collision.gameObject.CompareTag("Player"))
        {
            content.gameObject.SetActive(true);
            IsOpend = true;
            StartCoroutine(WaitSwitchOff());
           // Debug.Log("ok");
        }
    }

    private IEnumerator WaitSwitchOff()
    {
        yield return new WaitForSeconds(1.0f);
        IsActive = false;
    }
}
