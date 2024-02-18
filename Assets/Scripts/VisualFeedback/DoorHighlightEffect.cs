using UnityEngine;

public class KeyHighlightEffect : MonoBehaviour
{
    public Renderer doorRenderer;
    public Material highlightMaterial;
    private Material originalMaterial;

    // Class to highlight the CellDoor when the corresponding key is held
    private void Start()
    {
        // Store the original material of the door
        if (doorRenderer != null)
        {
            originalMaterial = doorRenderer.material;
        }
    }

    public void StartHighlighting()
    {
        // Change the door material to the highlight material
        if (doorRenderer != null)
        {
            doorRenderer.material = highlightMaterial;
        }
    }

    public void StopHighlighting()
    {
        // Revert the door material to its original state
        if (doorRenderer != null)
        {
            doorRenderer.material = originalMaterial;
        }
    }
}
