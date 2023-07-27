using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public interface ITimeModel
{
    IObservable<int> GameTime { get; }
}

