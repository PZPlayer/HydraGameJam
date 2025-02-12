using System;
using UnityEngine;

[Serializable]
public struct PotionInInventory
{
    public string PotionName;
    public GameObject PotionPrefab;
    public int PotionCount;
    public KeyCode PotionKeyCode;
    public KeyCode PotionThrowKeyCode;
}

namespace Hydra.Player
{
    public class PotionChoose : MonoBehaviour
    {
        [SerializeField] private PotionInInventory[] _potions;
        [SerializeField] private GameObject _chousenPotion;
        [SerializeField] private Transform _hands;
        [SerializeField] private LayerMask _groundLayer;

        private Vector3 mousePosition;

        private void Update()
        {
            int index = 0;
            foreach (PotionInInventory potion in _potions)
            {
                if (Input.GetKeyDown(potion.PotionKeyCode) && _chousenPotion != potion.PotionPrefab && potion.PotionCount > 0)
                {
                    HideAllPotions();
                    _chousenPotion = Instantiate(potion.PotionPrefab);
                    potion.PotionPrefab.GetComponent<ITakeable>().Take(_hands);
                }
                else if (Input.GetKeyDown(potion.PotionKeyCode) && _chousenPotion == potion.PotionPrefab && potion.PotionCount > 0)
                {
                    HideAllPotions();
                    _chousenPotion = null;
                }

                if (Input.GetKeyDown(potion.PotionThrowKeyCode) && _chousenPotion == potion.PotionPrefab)
                {
                    _potions[index].PotionCount--;
                    potion.PotionPrefab.GetComponent<IThrowable>().Throw(GetGroundPosition().Value);
                    _chousenPotion = null;
                }
                index++;
            }
        }

        public Vector3? GetGroundPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundLayer))
            {
                print(hit.point);
                return hit.point;
            }
            return null;
        }

        private void HideAllPotions()
        {
            foreach (PotionInInventory potion in _potions)
            {
                potion.PotionPrefab.GetComponent<ITakeable>().Drop();
            }
        }
    }
}

