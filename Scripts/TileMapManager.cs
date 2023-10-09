using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOB.Scripts
{

    /*The purpose of the tilemap manager is to manage the content being loaded from the game's tilemaps
     EXAMPLE: player has entered a new zone, this zone has several layers, some of these layers have walls, others have enemies (object layer)
    The manager will iterate through possible names, and instantiate the objects in the map
    The manager should also handle creating collision walls for possible wall layers in the given tilemap*/
    public sealed class TileMapManager
    {

        private List<GameObject> gameObjects = new List<GameObject>();

        private static readonly TileMapManager tilemapManager = new TileMapManager();
        static TileMapManager() { }
        private TileMapManager() { }

        public static TileMapManager TMM { get { return tilemapManager; } }

        public void LoadTileMapContents(TiledMap t) {
            foreach (var obj in t.TileLayers) {
                if (obj.Name == ("Wall Layer")) {
                    break;
                }
            }

            //iterate through all the object layers of the tilemap
            foreach (var l in t.ObjectLayers) {
                foreach (var obj in l.Objects) {
                    //set start position for player if the game has just started
                    dynamic spriteSheet;
                    switch (obj.Name) {
                        default:
                            break;
                        case ("Player"):
                            if (!OverworldPlayer.PLAYER.HasPlayerSpawned()) {
                                spriteSheet = Game1.contentManager.Load<SpriteSheet>("blueOverworld24-Sheet.sf", new JsonContentLoader());
                                OverworldPlayer.PLAYER.SetSprite(spriteSheet);
                                OverworldPlayer.PLAYER.SetPosition(new System.Numerics.Vector2(obj.Position.X, obj.Position.Y));
                                OverworldPlayer.PLAYER.PlayerHasSpawned();
                            }
                            gameObjects.Add(OverworldPlayer.PLAYER);
                            break;
                        //spawn enemies
                        case ("SnowmanThing"):
                            spriteSheet = Game1.contentManager.Load<SpriteSheet>("blueOverworld24-Sheet.sf", new JsonContentLoader());
                            var o = new SnowManThing(spriteSheet, obj.Position.X, obj.Position.Y);
                            gameObjects.Add(o);
                            break;
                    }

                }
            }

        }

        public void DrawTileMapContents(SpriteBatch spriteBatch, TiledMap t) {
            foreach (GameObject g in gameObjects) {
                spriteBatch.Draw(g.GetSprite(), g.GetPosition());

            }

        }
    }
}
