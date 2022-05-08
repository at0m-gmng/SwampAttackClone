using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange; // отметка, за которой переходим в след состояние
    [SerializeField] private float _rangeSpread; // разброс, чтобы враги не стояли в 1 точке

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread,_rangeSpread);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransit = true;
    }
}
