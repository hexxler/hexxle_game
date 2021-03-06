﻿using Hexxle.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Hexxle.TileSystem
{
    public class RandomTileGenerator
    {

        List<ITileBehaviour> weightedBehaviours;
        List<ITileNature> weightedNatures;
        List<ITileType> weightedTypes;
        Random random;

        public RandomTileGenerator(int seed)
        {
            random = new Random(seed);
            InitializeLists();
        }

        public RandomTileGenerator()
        {
            random = new Random();
            InitializeLists();
        }

        private void InitializeLists()
        {

            weightedBehaviours = new List<ITileBehaviour>();
            weightedNatures = new List<ITileNature>();
            weightedTypes = new List<ITileType>();
            FillWeightedLists();
        }

        private void FillWeightedLists()
        {
            FillWeightedBehaviours();
            FillWeightedNatures();
            FillWeightedTypes();
        }

        public Tile GenerateRandomTile()
        {
            ITileBehaviour behaviour = weightedBehaviours[RandomNumber(weightedBehaviours.Count)];
            ITileNature nature = weightedNatures[RandomNumber(weightedNatures.Count)];
            ITileType type = weightedTypes[RandomNumber(weightedTypes.Count)];
            return Tile.CreateInstance(EState.OnField, type, nature, behaviour);
        }

        public ITileType GetRandomTileType()
        {
            return weightedTypes[RandomNumber(weightedTypes.Count)];
        }

        private int RandomNumber(int max)
        {
            return random.Next(max);
        }


        private void FillWeightedBehaviours()
        {

            int maxWeight = Enum.GetValues(typeof(EBehaviour)).Cast<EBehaviour>().ToList()
                .ConvertAll(x => Tile.CreateBehaviour(x) is ITileBehaviour t ? t.CalculateWeight() : 0)
                .Max() + 5;

            foreach (EBehaviour behaviour in Enum.GetValues(typeof(EBehaviour)))
            {
                if(Tile.CreateBehaviour(behaviour) is ITileBehaviour behaviourToAdd && !behaviour.Equals(EBehaviour.None))
                {
                    for (int x = maxWeight; x > behaviourToAdd.CalculateWeight(); x--)
                    {
                        weightedBehaviours.Add(behaviourToAdd);
                    }
                }
            }
        }

        private void FillWeightedNatures()
        {

            int maxWeight = Enum.GetValues(typeof(ENature)).Cast<ENature>().ToList()
                .ConvertAll(x => Tile.CreateNature(x) is ITileNature t ? t.CalculateWeight() : 0)
                .Max() + 5;

            foreach (ENature nature in Enum.GetValues(typeof(ENature)))
            {
                if(Tile.CreateNature(nature) is ITileNature natureToAdd)
                {
                    for (int x = maxWeight; x > natureToAdd.CalculateWeight(); x--)
                    {
                        weightedNatures.Add(natureToAdd);
                    }
                }
            }
        }

        private void FillWeightedTypes()
        {
            int maxWeight = Enum.GetValues(typeof(EType)).Cast<EType>().ToList()
                .ConvertAll(x => Tile.CreateType(x) is ITileType t ? t.CalculateWeight() : 0)
                .Max() + 5;

            foreach (EType type in Enum.GetValues(typeof(EType)))
            {
                if (Tile.CreateType(type) is ITileType typeToAdd && !type.Equals(EType.None) && !type.Equals(EType.Void))
                {
                    for (int x = maxWeight; x > typeToAdd.CalculateWeight(); x--)
                    {
                        weightedTypes.Add(typeToAdd);
                    }
                }
            }
        }

    }
}
