using System.Collections.Generic;
using Game_Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_Engine.Components;

namespace Studying
{
    public class EntityManager
    {
        private List<int> IDs;
        private static EntityManager entityManager;
        
        public static EntityManager Instance
        {
            get
            {
                if (entityManager == null)
                {
                    return new EntityManager();
                }
                return entityManager;
            }
        }

        private EntityManager()
        {
            IDs = new List<int>();
        }

        public int CreateEntity()
        {
            int id = ComponentManager.Instance.getNewId();
            IDs.Add(id);
            return id;
        }
        
        public int CreatePlayer(Vector2 position, Vector2 velocity, Texture2D sprite)
        {
            int id = ComponentManager.Instance.getNewId();
            IDs.Add(id);
            PositionComponent posComp = new PositionComponent(id);
            posComp.X = position.X;
            posComp.Y = position.Y;
            ComponentManager.Instance.addComponent(posComp);

            VelocityComponent velComp = new VelocityComponent(id);
            velComp.VelX = velocity.X;
            velComp.VelY = velocity.Y;
            ComponentManager.Instance.addComponent(velComp);

            TextureComponent textComp = new TextureComponent(id);
            textComp.setValue(sprite);
            ComponentManager.Instance.addComponent(textComp);

            RectangleComponent rect = new RectangleComponent(id);
            rect.BoundingRectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            ComponentManager.Instance.addComponent(rect);

            CollisionComponent collComp = new CollisionComponent(id);
            collComp.CollisionType = 0;
            ComponentManager.Instance.addComponent(collComp);
            return id;
        }
    }
}
