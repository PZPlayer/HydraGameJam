using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void Newstart()
    {
        //������������ ������� �����        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
