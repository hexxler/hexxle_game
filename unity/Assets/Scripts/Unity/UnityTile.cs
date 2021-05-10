using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Hexxle.Unity.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexxle.Unity
{
    public class UnityTile : MonoBehaviour
    {
        #region Backend
        private ITile tile;
        #endregion

        #region Unity
        public Material[] materials;
        public GameObject[] natures;
        public GameObject[] behaviour;
        #endregion

        public event Action TileChangedEvent;

        // Start is called before the first frame update
        void Start()
        {
            UnityMap map = GameObjectFinder.UnityMap;
            tile = map.TileOnPoint(transform.position);
            
            SetComponents();
            SetNature();
            SetBehaviour();

            tile.TileChangedEvent += TileChanged;
        }

        public void TileChanged()
        {
            SetComponents();

            TileChangedEvent?.Invoke();
        }

        private void SetBehaviour()
        {
            // Add Consumption Sprite
            if (tile != null && tile.Behaviour != null && tile.Behaviour.Behaviour == EBehaviour.Consumption)
            {
                var consumptionBehaviourSprite = Instantiate(behaviour[(int)EBehaviour.Consumption]);
                consumptionBehaviourSprite.transform.SetParent(this.transform, false);
                consumptionBehaviourSprite.transform.localPosition = new Vector3(0f, 0f, 0.00057f);
            }

            // Add Conversion Sprite
            if (tile != null && tile.Behaviour != null && tile.Behaviour.Behaviour == EBehaviour.Conversion)
            {
                var conversionBehaviourSprite = Instantiate(behaviour[(int)EBehaviour.Conversion]);
                conversionBehaviourSprite.transform.SetParent(this.transform, false);
                conversionBehaviourSprite.transform.localPosition = new Vector3(0f, 0f, 0.00057f);
            }
        }

        private void SetNature()
        {
            // Add Star Sprite
            if (tile != null && tile.Nature != null && tile.Nature.Nature == ENature.Star)
            {
                var starNatureSprite = Instantiate(natures[(int)ENature.Star]);
                starNatureSprite.transform.SetParent(this.transform, false);
                starNatureSprite.transform.localPosition = new Vector3(0f, 0f, 0.00056f);
            }
        }

        public void SetComponents()
        {
            if (tile != null)
            {
                bool isVoid = tile.Type.Type.Equals(EType.Void);
                // Enable/disable collision
                MeshCollider collider = GetComponent<MeshCollider>();
                collider.enabled = isVoid ? true : false;

                // Assign tag
                if (!isVoid) tag = "Tile";

                // Assign material
                MeshRenderer renderer = GetComponent<MeshRenderer>();
                Material material = materials[(int)tile.Type.Type - 1];
                renderer.material = material;
            }
        }
    }
}
