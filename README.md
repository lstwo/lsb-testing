# LS-B Testing
A unity game in a facility

## SETUP
To set up the development environment you have to follow these Steps:

  - Download and Install the GitHub Desktop App.
  - Log In or Sign up into GitHub.
  - Go to 'File > Clone Repository > URL'.
  - Go back to the Repository and Click 'Code > Clone > Copy' To Copy the URL.
  - Paste In The URL and select Where You Want the Repository to be Stored on your Computer.
  - Go Into the Unity Hub and click 'Add' and select where you cloned the Repository.

## USING IT
To use it do the following:

  - Do some changes in the Project
  - Go back into your GitHub Desktop App and Click th files you want to be added To the GitHub Repository
  - Add a name to the commit and a description (optional)
  - Now click the Push origin button to add push it to github

# TROUBLESHOOTING
Here are some common problems and ways to fix them!

  ### I can't commit it sais "Your branch is up to date with 'origin/main'."
  To fix it go to the project folder on your Computer and open the 'gitadd.bat' file.  

  This will run a command prompt command that will stage all changes.  
  This only works if 'Git' is installed on your computer!

# TESTING SCENE
# Setup
## Player Stuff
  ### Global Volume
  The Global Volume Object contains all the Post Processing Information of the Scene.  

  ### Player
  The Player Object Is the bean containing the Rigidbody and Movement Script.  
  Inside The Player Object is the Orientation and The Head.  
  These are just Transforms for the Script to Orientate along.  
  The Head determines where The Camera will be placed.  
  The Orientation allows for the Orientation of the Orientation.  
  
  ### Camera
  The Camera Object is the Transform of the Camera.  
  The Actual Camera is the 'Main Camera' Object.  
  In there is the Holding and Target point.  
  These are just used for the pickup script.  
  
## Dont Destroy On Load
This contains Objects that will be added to The Dont Destroy On load Scene.  
Basically this prevents Objects from getting unloaded when loading another Scene.  

  ### Canvas
  This contains the UI elements like crosshair etc.  
  
  ### Event System
  Just there for some Event detection for the Canvas.  
  Just ignore this.  

# Map
  ### Light
  The Directional Light for Lighting up the Scene.  
  
  ### Walls
  An Inside Out cube with the top and bottom faces removed.  
  Just for the Walls!  
  
  ### Ground
  ground.  
  
  ### PickupCube
  A Cube you can Pickup or push around.
  Used for testing the physics and pcikup system.
  
  
