Add a List of MonoControls:
```
  List<MonoControl> controls = new List<MonoControl>();
```

Add in the controls:
```
        MonoButton testButton;
```

Add in Initialize():
```
  // Button
  testButton = new MonoButton() {
    Normal = Content.Load<Texture2D>("Controls/Button/Normal"),                                 // Load the normal texture
    Over = Content.Load<Texture2D>("Controls/Button/Over"),                                     // Load the highlight texture (Mouse over)
    Pressed = Content.Load<Texture2D>("Controls/Button/Down"),                                  // Load the pressed texture (Mouse down)
    Position = new Vector2(100, 200),                                                           // Set the position
    // Size = new System.Drawing.Size(100, 50),                                                  // Set the size, if no size given, it assumes the size of the normal texture
  };
  testButton.MouseEnter += TestButton_MouseEnter;                                                 // Subscribe to the MouseEnter event
  testButton.MouseLeave += TestButton_MouseLeave;                                                 // Subscribe to the MouseLeave event
  testButton.MouseClick += TestButton_MouseClick;                                                 // Subscribe to the MouseClick event
  testButton.MouseDown += TestButton_MouseDown;                                                   // Subscribe to the MouseDown event
  testButton.MouseUp += TestButton_MouseUp;                                                       // Subscribe to the MouseUp event
  controls.Add(testButton);                                                                       // Add the control to the list of controls
```

Add in Update(GameTime gameTime):
```
  foreach (var control in controls)
    control.Update();
```

Add in Draw(GameTime gameTime):
```
  foreach (var control in controls)
    control.Draw(_spriteBatch);
```
