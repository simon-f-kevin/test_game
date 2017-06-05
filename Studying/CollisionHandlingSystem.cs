using System;
using Game_Engine.Mediator;
using Game_Engine.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Studying
{
    public class CollisionHandlingSystem : IUpdateableSystem, IMediatorReciever
    {
        private List<IMediatorMessage> Collisions { get; }
        public CollisionHandlingSystem()
        {
            Collisions = new List<IMediatorMessage>();
        }
        public void recieveMessage(IMediatorMessage message)
        {
            Collisions.Add(message);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}