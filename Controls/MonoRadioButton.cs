/*
 * MonoCheckBox - An inherited Class for a MonoGame RadioButton Control
 * By Paul F. McGinley
 * 19/12/2023   -   Initial Version
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoControls.Controls
{
    public class MonoRadioButton : MonoControl
    {
        public Texture2D Normal { get; set; }                                                               // Normal texture
        public Texture2D Over { get; set; }                                                                 // Highlight texture
        public Texture2D Pressed { get; set; }                                                              // Pressed texture
        public Texture2D Selected { get; set; }                                                             // Selected texture
        public Texture2D SelectedOver { get; set; }                                                         // Selected highlight texture
        public Texture2D SelectedPressed { get; set; }                                                      // Selected pressed texture

        public string Group { get; set; } = "";                                                             // Group name

        /// <summary>
        /// Constructor
        /// </summary>
        public MonoRadioButton()
        {
            MouseClick += MonoRadioButton_MouseClick;                                                       // Subscribe to the MouseClick event
        } // End of the constructor

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="mouseState"></param>
        public override void Update()
        {
            if (Size.Width == 0 || Size.Height == 0)                                                        // If the width or height is 0
                Size = new System.Drawing.Size(Normal.Width, Normal.Height);                                // Set the size to the size of the texture

            base.Update();                                                                                  // Call the base Update method
        } // End of the Update method

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible) return;                                                                           // If the control is not visible, return

            if (SelectedState)                                                                              // If the control is selected
            {
                if (IsMouseDown)                                                                            // If the mouse is down
                    spriteBatch.Draw(SelectedPressed, Position, Color.White);                               // Draw the pressed texture
                else if (IsMouseOver)                                                                       // If the mouse is over
                    spriteBatch.Draw(SelectedOver, Position, Color.White);                                  // Draw the highlight texture
                else                                                                                        // If the mouse is not over
                    spriteBatch.Draw(Selected, Position, Color.White);                                      // Draw the normal texture
            }
            else                                                                                            // If the control is not selected
            {
                if (IsMouseDown)                                                                            // If the mouse is down
                    spriteBatch.Draw(Pressed, Position, Color.White);                                       // Draw the pressed texture
                else if (IsMouseOver)                                                                       // If the mouse is over
                    spriteBatch.Draw(Over, Position, Color.White);                                          // Draw the highlight texture
                else                                                                                        // If the mouse is not over
                    spriteBatch.Draw(Normal, Position, Color.White);                                        // Draw the normal texture
            }
        } // End of the Draw method

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonoRadioButton_MouseClick(object sender, EventArgs e)
        {
            if (!Visible) return;
            if (SelectedState) return;

            SelectedState = !SelectedState;           
        } // End of the MonoRadioButton_MouseClick method

        #endregion

    } // End of the MonoRadioButton class
} // End of the MonoControls.Controls namespace
