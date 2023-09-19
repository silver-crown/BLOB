using BLOB.Content.Scripts;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// The script taking care of the very generalized specifications of the player
/// The pause menu, enemy, dialogue box, etc.
/// </summary>
public class PlayerOverworldController : ObjectBehavior
{
    Vector2 playerPosition = new Vector2(0, 0);
    float moveSpeed = 0.4f;
/*
    private void Awake() {
        //If a player doesn't already exist, make this the player
        if (Player == null) {
            DontDestroyOnLoad(gameObject);
            Player = gameObject;
        }
        //if there is a manager 
        else if (Player != this) {
            Destroy(gameObject);
        }
    }*/

    public void GridMovement() {
        var keyboardState = Keyboard.GetState();

        //holding down multiple movement keys will do absolutely nothing
        if (keyboardState.GetPressedKeys().Length == 1) {
            if (keyboardState.IsKeyDown(Keys.W)) {
                playerPosition.Y -= moveSpeed;
                //set the animation to walking up
            }
            if (keyboardState.IsKeyDown(Keys.S)) {
                playerPosition.Y += moveSpeed;
                //set the animation to walking down
            }
            if (keyboardState.IsKeyDown(Keys.A)) {
                playerPosition.X -= moveSpeed;
                //set the animation to walking left
            }
            if (keyboardState.IsKeyDown(Keys.D)) {
                playerPosition.X += moveSpeed;
                //set the animation to walking right
            }
        }
    }
    /* private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.CompareTag("Enemy")){

             //combat manager should take data from other
             CombatManager.CM.overworldEnemy = other.gameObject;
             CombatManager.CM.enemies.AddRange(other.gameObject.GetComponent<Entity>().enemyList);
             //transition into enemy combat
             TransitionManager.TM.transitionType = TransitionManager.TransitionType.Enemy;
             StartCoroutine(TransitionManager.TM.TransitionIntoCombat());
         }        
     }*/
}
