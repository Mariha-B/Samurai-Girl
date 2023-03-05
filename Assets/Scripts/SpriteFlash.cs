using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    
   

    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    [SerializeField] private string ObTag;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
   

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        originalMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //if(collisionFlash.tag =="Enemy")
        //{

       //     Flash();
       // }
    }

    private IEnumerator FlashRoutine()
    {
        //Changes to new material
        spriteRenderer.material = flashMaterial;
        //after duration in s
        yield return new WaitForSeconds(duration);
        //swaps to Original Material
        spriteRenderer.material = originalMaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originalMaterial;
        //Finishes
        flashRoutine = null;
    }

    public void Flash()
    {
        if (flashRoutine !=null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ObTag)
        {
            Flash();
        }
    }

    

}
