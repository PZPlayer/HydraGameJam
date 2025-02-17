using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void Newstart()
    {
        //Перезагрузка текущей сцены        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
