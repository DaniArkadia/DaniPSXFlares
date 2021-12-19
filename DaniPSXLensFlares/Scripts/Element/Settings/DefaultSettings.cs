using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultSettings
{
   [HideInInspector] public bool isInitialized;
   public abstract void SetDefaultValues();
}
