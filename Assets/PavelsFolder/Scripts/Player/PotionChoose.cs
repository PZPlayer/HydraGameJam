using Hydra.Potions;
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
        [SerializeField] private GameObject _chosenPotion;
        [SerializeField] private Transform _hands;
        [SerializeField] private LayerMask _groundLayer;
        private GameObject oldPotion;
        private int iindex;

        private void Update()
        {
            for (int index = 0; index < _potions.Length; index++)
            {
                PotionInInventory potion = _potions[index];

                if (Input.GetKeyDown(potion.PotionKeyCode))
                {
                    HandlePotionSelection(potion);
                }

                if (Input.GetKeyDown(potion.PotionThrowKeyCode) && oldPotion == potion.PotionPrefab)
                {
                    iindex = index;
                    ThrowPotion(potion);
                }
            }
        }

        private void HandlePotionSelection(PotionInInventory potion)
        {
            if (potion.PotionCount > 0)
            {
                if (oldPotion != potion.PotionPrefab || oldPotion == null)
                {
                    //HideAllPotions();
                    if (_chosenPotion != null) _chosenPotion.GetComponent<ITakeable>().Drop(_chosenPotion);
                    _chosenPotion = Instantiate(potion.PotionPrefab);
                    oldPotion = potion.PotionPrefab;
                    TakePotion(potion);
                }
                else
                {
                    //HideAllPotions();
                    _chosenPotion.GetComponent<ITakeable>().Drop(_chosenPotion);
                    _chosenPotion = null;
                    oldPotion = null;
                }
            }
        }

        private void TakePotion(PotionInInventory potion)
        {
            ITakeable takeable = _chosenPotion.GetComponent<ITakeable>();
            if (takeable != null)
            {
                takeable.Take(_hands.gameObject);
            }
        }

        private void ThrowPotion(PotionInInventory potion)
        {
            _potions[iindex].PotionCount--;
            IThrowable throwable = _chosenPotion.GetComponent<IThrowable>();
            if (throwable != null)
            {
                Vector3? groundPosition = GetGroundPosition();
                if (groundPosition.HasValue)
                {
                    throwable.Throw(groundPosition.Value);
                }
            }
            _chosenPotion = null;
            oldPotion = null;
        }

        //private void HideAllPotions()
        //{
        //    foreach (var potion in _potions)
        //    {
        //        if (potion.PotionPrefab != null)
        //        {
        //            potion.PotionPrefab.GetComponent<ITakeable>().Drop(potion.PotionPrefab);
        //        }
        //    }
        //}

        private Vector3? GetGroundPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
            {
                return hit.point;
            }
            return null;
        }
    }
}