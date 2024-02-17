using System.Collections;
using UnityEngine;

public class BookMaterialManager : MonoBehaviour
{
    public Material defaultMaterial;
    public Material wrongMaterial;

    // Class to change the material of a specific book to indicate a wrong answer
    public void SetBookMaterialWrong(GameObject book)
    {
        var renderer = book.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = wrongMaterial;
            StartCoroutine(RevertMaterial(book));
        }
    }

    // Coroutine to revert the book's material back to default after a delay
    private IEnumerator RevertMaterial(GameObject book)
    {
        yield return new WaitForSeconds(2); // Delay before reverting the material
        var renderer = book.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = defaultMaterial;
        }
    }
}
