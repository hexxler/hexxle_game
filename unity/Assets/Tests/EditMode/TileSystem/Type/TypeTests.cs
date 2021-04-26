using Hexxle.Interfaces;
using Hexxle.TileSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexxle.Tests.TileSystem.Type
{
    public class TypeTests
    {
        ITile tile;

        [Test]
        public void ValueOfRelationship_AllRelationshipsAssigned()
        {
            var values = Enum.GetValues(typeof(EType)).Cast<EType>();
            foreach (EType type1 in values)
            {
                if (type1 == EType.None) continue;
                foreach (EType type2 in values)
                {
                    Assert.DoesNotThrow(() =>
                    {
                        tile = tile = Tile.CreateInstance(EState.None, type1, ENature.None, EBehaviour.None);
                        tile.Type.ValueOfRelationshipTo(type2);
                    }, $"Types: {type1} and {type2}");
                }
            }
        }
    }
}
