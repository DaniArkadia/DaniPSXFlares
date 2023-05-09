using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaniPSXFlares
{
    [CreateAssetMenu(menuName = "Effects/Flare Config")]
   public class FlareConfig : ScriptableObject
   {
      public static event Action OnRefreshElements;
      [Tooltip("Adjusts the space between each lens flare element")]
      public float distanceMultiplier = 1;
      [Tooltip("A flat line is fine in most cases, but if you want the elements to kind of stick the the middle more " +
               "or be more 'springy' then you can play with the curve and see how you like it.")]
      public AnimationCurve groupingCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));

      [Tooltip("Adjusts how much the elements will move horizontally, not exactly realistic but can be useful for tweaking")]
      public float xCompression = 1;

      [Tooltip("Adjusts how much the elements will move vertically, not exactly realistic but can be useful for tweaking")]
      public float yCompression = 1;

      [Tooltip("The angle at which the flares should be visible from")]
      public float visibleAngle = 90;
      public List<LensFlareElement> lensFlareElements = new List<LensFlareElement>(1);

      public LayerMask flareBlockingLayers;

      public List<LensFlareElement> GetFlareElements()
      {
         var flares = new List<LensFlareElement>();
         for (int i = 0; i < lensFlareElements.Count; i++)
         {
            flares.Add(lensFlareElements[i].Clone());
         }
         return flares;
      }

      #if UNITY_EDITOR
      //this updates each element's visuals when you update something in playmode.
      void OnValidate()
      {
         UnityEditor.EditorApplication.delayCall += RefreshElements;
         SetDefaultValues();
      }
      void RefreshElements()
      {
         OnRefreshElements?.Invoke();
      }
      void SetDefaultValues()
      {
         foreach (var element in lensFlareElements)
         {
            element.SetDefaultValues();
         }
      }
      #endif
   }
}
