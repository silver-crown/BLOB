using BLOB;
using BLOB.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MonoGame.Extended.Screens;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// The netural state of the game world, where everything moves around in the overworld
/// </summary>
public partial class OverworldState : State
{
    public OverworldState() : base() {
    }
    /// <summary>
    /// Activate the grid movement system
    /// </summary>
    /// <returns></returns>
    /// 
    public override IEnumerator Start() {
        currentNumerator = new CurrentNumerator(Start);
        Debug.WriteLine("Starting Overworld State.");
        //PlayerController.Player.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
        //Game1.GAME._screenManager.LoadScreen(new DemoTown(Game1.GAME), new FadeTransition(Game1.GAME.GraphicsDevice, Color.Black));
        Game1._screenManager.LoadScreen(new DemoTown(Game1.GAME), new FadeTransition(Game1.graphicsDevice.GraphicsDevice, Color.Black));
        yield return Execute().MoveNext();
    }/*
    public override IEnumerator End() {
        ///<summary>stop executing the state</summary>
        Debug.Log("Ending PlayerWalking state");
        PlayerController.Player.GetComponent<PlayerGridMovement>().PauseAnimation();
        yield break;
    }
    */
    public override IEnumerator Execute() {
        currentNumerator = new CurrentNumerator(Execute);

        //player movement logic should happen here
        //pool the controls 

        if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardUP)) OverworldPlayer.PLAYER.Walk(OverworldPlayer.Direction.UP);
        else if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardDOWN)) OverworldPlayer.PLAYER.Walk(OverworldPlayer.Direction.DOWN);
        else if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardLEFT)) OverworldPlayer.PLAYER.Walk(OverworldPlayer.Direction.LEFT);
        else if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardRIGHT)) OverworldPlayer.PLAYER.Walk(OverworldPlayer.Direction.RIGHT);

        yield break;
    }
}


