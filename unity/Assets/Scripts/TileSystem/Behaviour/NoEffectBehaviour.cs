using Assets.Scripts.Interfaces;
using Assets.Scripts.TileSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEffectBehaviour : ITileBehaviour
{
    public EBehaviour Behaviour => EBehaviour.NoEffect;

    public void ApplyBehaviour(ITile otherTile)
    {
        // Do nothing
    }
}
