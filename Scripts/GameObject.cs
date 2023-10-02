using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BLOB.Scripts
{
    /*The GameObject class is an all-encompassing class that contains everything an object needs 
     in order to exist in a game. Examples of game objects include 
    **A player character
    **Shop items
    **Enemies
    **A tree
    **Missile
    */
    public abstract class GameObject
    {
        HashSet<ObjectBehavior> behaviors;

        bool active = false;
        Vector2 position = new Vector2(0, 0);

        //returns the component attached to the game object
        public ObjectBehavior GetComponent(ObjectBehavior o)
        {
            return behaviors.Where(x => x == o).FirstOrDefault();
        }
        //adds component to the game object
        public void AddComponent(ObjectBehavior o)
        {
            behaviors.Add(o);
        }
        //sets the gameobject to being active or not
        public void SetActive(bool a) { active = a; }

        public void SetPosition(Vector2 a) => position = a;
        public Vector2 GetPosition() => position;
    }
}
