/*
 * MonoCheckBox - An inherited Class for a MonoGame CheckBox Control
 * By Paul F. McGinley
 * 19/12/2023   -   Initial Version
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoControls.Controls
{
    public class MonoCheckBox : MonoControl
    {
        public Texture2D Normal { get; set; }                                                               // Normal texture
        public Texture2D Over { get; set; }                                                                 // Highlight texture
        public Texture2D Down { get; set; }                                                                 // Pressed texture
        public Texture2D Checked { get; set; }                                                              // Checked texture
        public Texture2D CheckedOver { get; set; }                                                          // Checked highlight texture
        public Texture2D CheckedPressed { get; set; }                                                       // Checked pressed texture

        /// <summary>
        /// Constructor
        /// </summary>
        public MonoCheckBox()
        {
            MouseClick += MonoCheckBox_MouseClick;                                                          // Subscribe to the MouseClick event
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

            if (IsChecked)                                                                                  // If the control is checked
            {
                if (IsMouseDown)                                                                            // If the mouse is down
                    spriteBatch.Draw(CheckedPressed, Position, Color.White);                                // Draw the pressed texture
                else if (IsMouseOver)                                                                       // If the mouse is over
                    spriteBatch.Draw(CheckedOver, Position, Color.White);                                   // Draw the highlight texture
                else                                                                                        // If the mouse is not over
                    spriteBatch.Draw(Checked, Position, Color.White);                                       // Draw the normal texture
            }
            
            else                                                                                            // If the control is not checked
            {
                if (IsMouseDown)                                                                            // If the mouse is down
                    spriteBatch.Draw(Down, Position, Color.White);                                          // Draw the pressed texture
                else if (IsMouseOver)                                                                       // If the mouse is over
                    spriteBatch.Draw(Over, Position, Color.White);                                          // Draw the highlight texture
                else                                                                                        // If the mouse is not over
                    spriteBatch.Draw(Normal, Position, Color.White);                                        // Draw the normal texture
            }

            base.Draw(spriteBatch);                                                                         // Call the base Draw method
        } // End of the Draw method

        #region Events

        /// <summary>
        /// MouseClick event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonoCheckBox_MouseClick(object sender, EventArgs e)
        {
            if (!Visible) return;                                                                           // If the control is not visible, return

            IsChecked = !IsChecked;                                                                         // Call the CheckedStateChanged event

        } // End of the MonoCheckBox_MouseClick method

        #endregion

    } // End of the MonoCheckBox class
} // End of the MonoControls.Controls namespace