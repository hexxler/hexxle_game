using Hexxle.TileSystem;
using Hexxle.Interfaces;
using NUnit.Framework;
using System;
using System.Linq;

namespace Hexxle.Tests.Logic
{
    public class FunctionalValuesTests
    {

        [Test]
        public void AllTypesShouldReturnAtleastAZero()
        {
            Enum.GetValues(typeof(EType)).OfType<EType>().ToList()
                .ConvertAll(x => Tile.CreateType(x) is ITileType t ? t.CalculateWeight() : 0)
                .ForEach(x => Assert.IsTrue(x >= 0));
        }

        [Test]
        public void AllBehavioursShouldReturnAtleastAZero()
        {
            Enum.GetValues(typeof(EBehaviour)).OfType<EBehaviour>().ToList()
                .ConvertAll(x => Tile.CreateBehaviour(x) is ITileBehaviour t ? t.CalculateWeight() : 0)
                .ForEach(x => Assert.IsTrue(x >= 0));
        }

        [Test]
        public void AllNaturesShouldReturnAtleastAZero()
        {
            Enum.GetValues(typeof(ENature)).OfType<ENature>().ToList()
                .ConvertAll(x => Tile.CreateNature(x) is ITileNature t ? t.CalculateWeight() : 0)
                .ForEach(x => Assert.IsTrue(x >= 0));
        }


    }
}
