using Hexxle.CoordinateSystem;
using Hexxle.Interfaces;
using Hexxle.TileSystem;
using Hexxle.Unity.Util;
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
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            UnityMap map = GameObjectFinder.UnityMap;
            tile = map.TileOnPoint(transform.position);
            
            SetComponents();

            tile.TileChangedEvent += TileChanged;
        }

        public void TileChanged()
        {
            SetComponents();
        }

        public void SetComponents()
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
