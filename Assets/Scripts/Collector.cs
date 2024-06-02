using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private float _distanceToCollect = 2f; // дистанци€ сбора
    [SerializeField] private LayerMask _layerMask;

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distanceToCollect, _layerMask, QueryTriggerInteraction.Ignore); // QueryTriggerInteraction.Ignore - чтобы взаимодействовал только с коллайдерами, игнориру€ триггеры
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<Loot>() is Loot loot)
            {
                loot.Collect(this);
            }
        }
    }
}
