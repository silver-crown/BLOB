using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLOB.Content.Scripts
{
    public class OverworldPlayer : GameObject
    {
        private PlayerOverworldController controller = new PlayerOverworldController();
        
        void Start() {

        }

        private void Update() {
            controller.GridMovement();
        }
    }
}
