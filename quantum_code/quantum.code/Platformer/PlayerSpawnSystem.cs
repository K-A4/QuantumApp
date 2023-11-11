using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Platformer
{
    public unsafe class PlayerSpawnSystem : SystemSignalsOnly, ISignalOnPlayerDataSet
    {
        public void OnPlayerDataSet(Frame f, PlayerRef player)
        {
            var data = f.GetPlayerData(player);

            var prototype = f.FindAsset<EntityPrototype>(data.CharacterPrototype.Id);

            var entity = f.Create(prototype);

            var playerLink = new PlayerLink() { Player = player};

            f.Add(entity, playerLink);

            if (f.Unsafe.TryGetPointer<Transform3D>(entity, out var transform))
            {
                transform->Position.X = 0 + player;
            }
        }
    }
}
