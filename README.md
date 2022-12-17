# CompsMaster
 
# Code Overview
Features:
- Kinematic Player Controller
- Raycast Hit Detection
- Advanced Gun System
- Procedural Recoil & Procedural Camera Shake
- Basic Enemy AI
- Progressive Enemy Spawner

The code can be a bit difficult to understand at first. It's best to start with the **Player** object in the scene and the **PlayerMovement** script. This script is especially simple. The Input method grabs keystrokes and assigns them to the corresponding variable 'x' or 'z'. In Unity whenever variables are initialized, the variables themselves can be assigned from the main view by dragging objects into the corresponding category, allowing us to assign variables to game objects outside of the script. If you're ever confused as to where a variable was assigned, it could be through this method.

The player character's position is then transformed with the x and z variables. Similarly, if the spacebar is hit, the player's position is transformed by our jumpHeight and gravity variable. All these variables allow us to fine tune things like the acceleration and the deceleration of our player character.

---

# Replication Instructions

1. This project was made with Unity, and thus requires Unity Hub in order to function. Which can be downloaded [here](https://unity.com/download).
2. This project was developed with Unity LTS *2021.3.14f1* and will work best in the corresponding version. Using a version earlier or later could cause it to break.
3. Clone this repository or download it as a zip.
4. Open up Unity and under the Projects tab, select *Open*, select *add project from disk*, then select where you installed this repository.
5. The project should now open and initialize.


