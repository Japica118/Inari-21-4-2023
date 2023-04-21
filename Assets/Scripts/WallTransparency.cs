using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using Cinemachine;

public class WallTransparency : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public CinemachineVirtualCameraBase[] cameras;
    public Material wallMaterial;
    public float transparency = 0.2f;
    public Material opaqueMaterial;
    public Material transparentMaterial;
    private Renderer wallRenderer;
    private Material[] originalMaterials;
    private int currentCameraIndex = 0;

    private void Start()
    {
        // Set the initial transparency of the wallMaterial
        Color color = wallMaterial.color;
        color.a = 1f;
        wallMaterial.color = color;
        wallMaterial.SetFloat("_BaseColorAlpha", 1f);

        wallRenderer = GetComponent<Renderer>();
        originalMaterials = wallRenderer.materials;
        Material[] materials = new Material[originalMaterials.Length];

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = opaqueMaterial;
        }

        wallRenderer.materials = materials;
    }

    private void Update()
    {
        // Get the current camera
        CinemachineVirtualCameraBase playerCamera = cameras[currentCameraIndex];

        CinemachineVirtualCameraBase player2Camera = cameras[currentCameraIndex];

        CinemachineVirtualCameraBase player3Camera = cameras[currentCameraIndex];

        CinemachineVirtualCameraBase player4Camera = cameras[currentCameraIndex];

        // Cast a ray from the camera to the player
        Vector3 direction = player.transform.position - playerCamera.transform.position;
        Vector3 direction2 = player2.transform.position - player2Camera.transform.position;
        Vector3 direction3 = player3.transform.position - player3Camera.transform.position;
        Vector3 direction4 = player4.transform.position - player4Camera.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, direction, out hit))
        {
            // Check if the ray hit the wall
            if (hit.transform == gameObject.transform)
            {
                // Set the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = transparency;
                wallMaterial.color = color;

                // Blend the base map texture with the transparency
                wallMaterial.SetFloat("_BaseColorAlpha", transparency);

                Material[] materials = new Material[originalMaterials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = transparentMaterial;
                }
                wallRenderer.materials = materials;
            }
            else
            {
                // Reset the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = 1f;
                wallMaterial.color = color;

                // Reset the base map blending
                wallMaterial.SetFloat("_BaseColorAlpha", 1f);

                wallRenderer.materials = originalMaterials;
            }
        }

        if (Physics.Raycast(player2Camera.transform.position, direction2, out hit))
        {
            // Check if the ray hit the wall
            if (hit.transform == gameObject.transform)
            {
                // Set the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = transparency;
                wallMaterial.color = color;

                // Blend the base map texture with the transparency
                wallMaterial.SetFloat("_BaseColorAlpha", transparency);

                Material[] materials = new Material[originalMaterials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = transparentMaterial;
                }
                wallRenderer.materials = materials;
            }
            else
            {
                // Reset the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = 1f;
                wallMaterial.color = color;

                // Reset the base map blending
                wallMaterial.SetFloat("_BaseColorAlpha", 1f);

                wallRenderer.materials = originalMaterials;
            }
        }

        if (Physics.Raycast(player3Camera.transform.position, direction3, out hit))
        {
            // Check if the ray hit the wall
            if (hit.transform == gameObject.transform)
            {
                // Set the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = transparency;
                wallMaterial.color = color;

                // Blend the base map texture with the transparency
                wallMaterial.SetFloat("_BaseColorAlpha", transparency);

                Material[] materials = new Material[originalMaterials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = transparentMaterial;
                }
                wallRenderer.materials = materials;
            }
            else
            {
                // Reset the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = 1f;
                wallMaterial.color = color;

                // Reset the base map blending
                wallMaterial.SetFloat("_BaseColorAlpha", 1f);

                wallRenderer.materials = originalMaterials;
            }
        }

        if (Physics.Raycast(player4Camera.transform.position, direction4, out hit))
        {
            // Check if the ray hit the wall
            if (hit.transform == gameObject.transform)
            {
                // Set the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = transparency;
                wallMaterial.color = color;

                // Blend the base map texture with the transparency
                wallMaterial.SetFloat("_BaseColorAlpha", transparency);

                Material[] materials = new Material[originalMaterials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = transparentMaterial;
                }
                wallRenderer.materials = materials;
            }
            else
            {
                // Reset the transparency of the wallMaterial
                Color color = wallMaterial.color;
                color.a = 1f;
                wallMaterial.color = color;

                // Reset the base map blending
                wallMaterial.SetFloat("_BaseColorAlpha", 1f);

                wallRenderer.materials = originalMaterials;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Material[] materials = new Material[originalMaterials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = transparentMaterial;
            }
            wallRenderer.materials = materials;
        }

        if (other.gameObject == player2)
        {
            Material[] materials = new Material[originalMaterials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = transparentMaterial;
            }
            wallRenderer.materials = materials;
        }

        if (other.gameObject == player3)
        {
            Material[] materials = new Material[originalMaterials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = transparentMaterial;
            }
            wallRenderer.materials = materials;
        }

        if (other.gameObject == player4)
        {
            Material[] materials = new Material[originalMaterials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = transparentMaterial;
            }
            wallRenderer.materials = materials;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            wallRenderer.materials = originalMaterials;
        }

         if (other.gameObject == player2)
        {
            wallRenderer.materials = originalMaterials;
        }

         if (other.gameObject == player3)
        {
            wallRenderer.materials = originalMaterials;
        }

         if (other.gameObject == player4)
        {
            wallRenderer.materials = originalMaterials;
        }
    }

    public void SwitchCamera()
    {
        // Increment the current camera index and wrap around if necessary
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
    }
}





























