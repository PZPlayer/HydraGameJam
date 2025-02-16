using Hydra.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hydra.UI
{
    public class DeathScript : MonoBehaviour
    {
        public void GoToDeathScene()
        {
            Settings.Setting.LoadScene();
        }
    }

}