using System;
using UnityEngine;

namespace DaniPSXFlares.flareSettings
{
   [System.Serializable]
   public class PositionSettings : DefaultSettings
   {
      [Header("Position")]
      [Tooltip("Where the element should be along the line of elements")]
      public float position;
      [Tooltip("This allows you to position the element a bit more precisely, just for convienience. Adjust this range in the code to change the effect size.")]
      [Range(-0.1f, 0.1f)]
      public float positionFineAdjustment = 0;
      public Vector2 offset;

      [Header("Scale")]
      public float size = 1f;
      [Tooltip("This allows you to scale the element a bit more precisely, just for convienience. Adjust this range in the code to change the effect size.")]
      [Range(-0.1f, 0.1f)]
      public float sizeFineAdjustment = 0;

      [Header("Rotation")]
      [Tooltip("Changes how much the element will rotate depending on distance to center of screen. I don't really like this, just here in case you want it.")]
      public float rotation;

      [Header("Camera Scale Adjustment")]
      public bool constantPhysicalSize;
      [Tooltip("Leave this at 1 in most cases, this changes how much the scale of the element changes depending on camera distance IF constant physical size is switched OFF")]
      [Min(1)]
      public float resizeAdjuster = 1;

      public float GetAdjustedPos()
      {
         return position + positionFineAdjustment;
      }

      public float GetAdjustedScale()
      {
         return size + sizeFineAdjustment;
      }
      public override void SetDefaultValues()
      {
         if (isInitialized == false)
         {
            size = 1;
            resizeAdjuster = 1;
         }
         isInitialized = true;
      }
   }
}
