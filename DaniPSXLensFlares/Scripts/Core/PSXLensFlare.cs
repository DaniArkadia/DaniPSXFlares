using System.Collections.Generic;
using UnityEngine;

namespace DaniPSXFlares
{
   public class PSXLensFlare : MonoBehaviour
   {
      /*the camera that the lens flares should be positioned relative too, by default this will be set to Camera.main, to keep things simple
      but you might what to set up your own solution for updating this as camera switching occurs.*/
      [HideInInspector] public Camera activeCamera;
      [Tooltip("This is the asset that stores all the information for a specific lens flare effect. To create one go to the project window, Right-Click > Effects > Flare Config")]
      public FlareConfig flareConfig;
      public BoxCollider lineOfSightBox;
      GameObject flareContainer;
      List<LensFlareElement> lensFlareElements;
      bool isInitialized;
      void Awake()
      {
         if (activeCamera == null)
         {
            activeCamera = Camera.main;
         }
         SpawnContainer();
         SpawnElements();
      }
      void SpawnContainer()
      {
         if (flareContainer == null)
         {
            flareContainer = new GameObject("FlareContainer");
            flareContainer.transform.parent = transform;
         }
      }
      void SpawnElements()
      {
         lensFlareElements = new List<LensFlareElement>();
         for (int i = 0; i < flareConfig.lensFlareElements.Count; i++)
         {
            var instance = new GameObject("LensFlare");
            instance.transform.parent = flareContainer.transform;
            lensFlareElements.Add(flareConfig.lensFlareElements[i]);
            lensFlareElements[i].Initialize(this, instance);
            isInitialized = true;
         }
      }
      void DespawnElements()
      {
         for (int i = 0; i < lensFlareElements.Count; i++)
         {
            lensFlareElements[i].DespawnElement();
         }
         lensFlareElements = null;
         isInitialized = false;
      }
      void Update()
      {
         //we rely on the _activeCamera to actually have a camera assigned to it, so if it turns up null, we bail out here to avoid exeptions.
         if (activeCamera == null || isInitialized == false) return;
         flareContainer.transform.position = transform.position;
         flareContainer.transform.LookAt(activeCamera.transform, Vector3.up);

         for (int i = 0; i < lensFlareElements.Count; i++)
         {
            lensFlareElements[i].UpdateElement();
         }
      }
      //these methods allow you to update the visual aspects of the lens flare immediatly in the inspector while in playmode.
#if UNITY_EDITOR
      void OnEnable()
      {
         FlareConfig.OnRefreshElements += RefreshElements;
      }
      void OnDisable()
      {
         FlareConfig.OnRefreshElements -= RefreshElements;
      }
      public void RefreshElements()
      {
         if (lensFlareElements.Count != flareConfig.lensFlareElements.Count)
         {
            DespawnElements();
            SpawnElements();
            return;
         }
         for (int i = 0; i < lensFlareElements.Count; i++)
         {
            lensFlareElements[i].RefreshElement();
         }
      }
#endif
   }
}
