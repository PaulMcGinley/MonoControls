/*
 * MonoButton - An inherited Class for a MonoGame Button Control
 * By Paul F. McGinley
 * 19/12/2023   -   Initial Version
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoControls.Controls
{
    public class MonoButton : MonoControl
    {
        public Texture2D Normal { get; set; }                                                               // Normal texture
        public Texture2D Over { get; set; }                                                                 // Highlight texture
        public Texture2D Pressed { get; set; }                                                              // Pressed texture

        /// <summary>
        /// Draw the control
        /// NOTE: SpriteBatch.Begin() must be called before this method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible) return;                                                                           // If the control is not visible, return

            if (IsMouseDown)                                                                                // If the mouse is down
                spriteBatch.Draw(Pressed, Position, Color.White);                                           // Draw the pressed texture
            else if (IsMouseOver)                                                                           // If the mouse is over the control
                spriteBatch.Draw(Over, Position, Color.White);                                              // Draw the highlight texture
            else                                                                                            // If the mouse is not over the control
                spriteBatch.Draw(Normal, Position, Color.White);                                            // Draw the normal texture

            base.Draw(spriteBatch);                                                                         // Call the base Draw method
        } // End of the Draw method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouseState"></param>
        public override void Update()
        {
            if (Size.Width == 0 || Size.Height == 0)                                                        // If the width or height is 0
                Size = new System.Drawing.Size(Normal.Width, Normal.Height);                                // Set the size to the normal texture size

            base.Update();                                                                                  // Call the base Update method
        } // End of the Update method
    }
}