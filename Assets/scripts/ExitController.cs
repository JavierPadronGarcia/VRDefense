using UnityEngine;

public class ExitController : MonoBehaviour
{
    public void ExitScene()
    {
        Application.Quit(); 

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("gun_bullet") || collision.gameObject.CompareTag("gun_sword"))
        {
            ExitScene();
        }
    }
}
