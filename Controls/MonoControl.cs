/*
 * MonoControl - A Base Class for MonoGame Controls
 * By Paul F. McGinley
 * 18/12/2023   -   Initial Version
 * 19/12/2023   -   Fixed bug where mouse up was being called if mouse was released outside of control
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoControls.Controls
{
    public class MonoControl
    {
        #region Events

        // Mouse Events
        public event EventHandler MouseEnter;                                                               // MouseEnter event
        public event EventHandler MouseLeave;                                                               // MouseLeave event
        public event EventHandler MouseClick;                                                               // MouseClick event
        public event EventHandler MouseDown;                                                                // MouseDown event
        public event EventHandler MouseUp;                                                                  // MouseUp event

        // State Events
        public event EventHandler StateChanged;                                                             // StateChanged event

        #endregion

        #region Properties

        public System.Drawing.Size Size { get; set; }                                                       // Size of the control

        public Vector2 Position { get; set; }                                                               // Location of the control

        public Rectangle Bounds => new Rectangle(                                                           // Bounds of the control
            (int)Position.X,                                                                                // X position
            (int)Position.Y,                                                                                // Y position
            Size.Width,                                                                                     // Width
            Size.Height);                                                                                   // Height

        // Is the mouse over the control?
        bool isMouseOver = false;                                                                           // Is the mouse over the control?
        public bool IsMouseOver                                                                             // Property for isMouseOver
        {
            get => isMouseOver;                                                                             // Return the value of isMouseOver
            set
            {
                if (value != isMouseOver)                                                                   // If the value is different from isMouseOver
                {
                    isMouseOver = value;                                                                    // Set isMouseOver to the value

                    if (isMouseOver)                                                                        // If isMouseOver is true
                        MouseEnter?.Invoke(this, EventArgs.Empty);                                          // Call MouseEnter()
                    else                                                                                    // If isMouseOver is false
                        MouseLeave?.Invoke(this, EventArgs.Empty);                                          // Call MouseLeave()
                }
            }
        } // End of the IsMouseOver property

        // Is the mouse down on the control?
        bool isMouseDown = false;                                                                           // Is the mouse down on the control?
        public bool IsMouseDown                                                                             // Property for isMouseDown
        {
            get => isMouseDown;                                                                             // Return the value of isMouseDown
            set
            {
                if (value != isMouseDown)                                                                   // If the value is different from isMouseDown
                {
                    isMouseDown = value;                                                                    // Set isMouseDown to the value

                    if (isMouseDown)                                                                        // If isMouseDown is true
                        MouseDown?.Invoke(this, EventArgs.Empty);                                           // Call OnMouseDown()
                    else                                                                                    // If isMouseDown is false
                        MouseUp?.Invoke(this, EventArgs.Empty);                                             // Call OnMouseUp()
                }
            }
        } // End of the IsMouseDown property

        // Is the control checked?
        bool isChecked = false;                                                                             // Is the control checked?
        public bool IsChecked                                                                               // Property for isChecked
        {
            get => isChecked;                                                                               // Return the value of isChecked
            set
            {
                if (value != isChecked)                                                                     // If the value is different from isChecked
                {
                    isChecked = value;                                                                      // Set isChecked to the value
                    StateChanged?.Invoke(this, EventArgs.Empty);                                            // Call StateChanged()
                }
            }
        } // End of the IsChecked property
        public bool SetInitialState { set => isChecked = value; }                                           // Set the initial state of the control

        // Is the control visible?
        public bool Visible { get; private set; } = true;                                                   // Is the control visible? (Default is true)
        public void Hide() => Visible = false;                                                              // Hide the control
        public void Show() => Visible = true;                                                               // Show the control

        public bool Enabled { get; set; } = true;                                                           // Is the control enabled? (Default is true)

        // Is the control selected?
        bool selectedState { get; set; } = false;                                                           // Is the control selected?
        public bool SelectedState                                                                           // Property for selectedState
        {
            get => selectedState;                                                                           // Return the value of selectedState
            set
            {
                if (value != selectedState)                                                                 // If the value is different from selectedState
                {
                    selectedState = value;                                                                  // Set selectedState to the value
                    StateChanged?.Invoke(this, EventArgs.Empty);                                            // Call StateChanged()
                }
            }
        } // End of the SelectedState property

        public MouseState mouseState => Mouse.GetState();                                                   // MouseState of the control
        public KeyboardState keyboardState => Keyboard.GetState();                                          // KeyboardState of the control

        #endregion Properties

        #region virtual Functions

        public virtual void LoadContent() { }                                                               // Load the content for the control
        public virtual void UnloadContent() { }                                                             // Unload the content for the control

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="mouseState"></param>
        public virtual void Update()
        {
            if (!Visible) return;                                                                           // If the control is not visible, return
            if (!Enabled) return;                                                                           // If the control is not enabled, return

            // Mouse is over control
            if (Bounds.Contains(mouseState.Position) && !IsMouseOver)                                       // If the mouse is within the bounds of the control
                IsMouseOver = true;                                                                         // Set IsMouseOver to true
            // Mouse is not over control
            else if (!Bounds.Contains(mouseState.Position) && IsMouseOver)                                  // If the mouse is not within the bounds of the control
            {
                IsMouseOver = false;                                                                        // Set IsMouseOver to false

                if (mouseState.LeftButton == ButtonState.Released && isMouseDown)                           // If the left mouse button is released
                    IsMouseDown = false;                                                                    // Set IsMouseDown to false
            }

            // Mouse pressed inside of control
            if (Bounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && !isMouseDown)       // If the left mouse button is pressed
                IsMouseDown = true;                                                                         // Set IsMouseDown to true
            // Mouse released inside of control
            else if (Bounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Released && isMouseDown)  // If the left mouse button is released
            { 
                IsMouseDown = false;                                                                        // Set IsMouseDown to false
                MouseClick?.Invoke(this, EventArgs.Empty);                                                  // Call OnMouseClick()
            }
            // Mouse released outside of control
            else if (mouseState.LeftButton == ButtonState.Released && isMouseDown)                          // If the left mouse button is released
                IsMouseDown = false;                                                                        // Set IsMouseDown to false

        } // End of the Update method

        public virtual void Draw(SpriteBatch spriteBatch) { }                                               // Draw the control

        #endregion virtual Functions

    } // End of the MonoControl class
} // End of the MonoControls.Controls namespace
