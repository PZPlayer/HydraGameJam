using UnityEngine;


namespace Hydra.Potions
{
    public class PotionDestroyer : PotionBase
    {
        [SerializeField] private float _radius;


        public override void CastEffect()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            for(int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].CompareTag("Magic"))
                {
                    Destroy(colliders[i].gameObject);
                }
            }

            base.CastEffect();
        }
    }
}