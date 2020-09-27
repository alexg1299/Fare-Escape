# Fare-Escape
An endless runner game similar to Temple Run.

-----------------------------------------------------------------------------------
Assignment 1: Endless Runner - Temple Run-Like Game README
-----------------------------------------------------------------------------------
Student Name: Alexandra Garcia
Student abc123: kgd962


-----------------------------------------------------------------------------------
Links to Project (if you used Google Drive, OneDrive, or Dropbox for submission)
-----------------------------------------------------------------------------------
Please provide your Google Drive, OneDrive, or Dropbox link here if you used it for 
your submission, otherwise you may skip this section if you just submitted your
assignment on Blackboard (zipped up). (Make sure the link does not expire and the 
link permissions allow us to download, otherwise you may receive a grade of 0 on 
your assignment submission if we cannot download it.)

Place this Link to Your Unity Project Here:

N/A

-----------------------------------------------------------------------------------
Version of Unity You Used for Your Game
-----------------------------------------------------------------------------------
Please write down the version of Unity you used when making your game here (e.g.
2019.4, 2020.1, 2020.2, etc...): 2020.1.2f1


-----------------------------------------------------------------------------------
Game Controls 
-----------------------------------------------------------------------------------
Please explain what your buttons do. (You do not have to use all of these buttons.
If you use buttons other than these, please mention them to let us know.)

Mouse Click: select the buttons on menu 
W or ↑ or Spacebar: Jump 
A or ←: move left
D or →: move right
S or ↓: reach ground faster when in the air
P: pause


-----------------------------------------------------------------------------------
Assets Downloaded for Game
-----------------------------------------------------------------------------------
Any assets that you downloaded and used from the Asset Store needs to be documented.
Please provide any links to these assets from the Asset Store you downloaded here:

Easy Primitive People: https://assetstore.unity.com/packages/3d/characters/easy-primitive-people-161846
Food Pack: https://assetstore.unity.com/packages/3d/props/food/free-casual-food-pack-mobile-vr-85884
SkyBox: https://assetstore.unity.com/packages/2d/textures-materials/sky/customizable-skybox-174576

-----------------------------------------------------------------------------------
Instructions for Students
-----------------------------------------------------------------------------------
Please make sure you place all of your written scripts within a folder called 
"Scripts" to make it easier for the professor and/or TA/grader to find your 
written code for grading.

The following sections are divided into each grading criteria for your assignment
submission. For each section where you must briefly describe something, a sentence
or two is all that is needed just to get your point across. If you did not
implement a particular feature (grading criteria), such as the extra credits, then 
simply mention "Did not do".


-----------------------------------------------------------------------------------
1. Character Automatically Moves Forward (10 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented getting your character to automatically move
forward. e.g. Which script did you write that implements this? (Mention whether 
this script was attached to any game object and which ones.)

In the Character Controller script in the update function I would transform the position of the character by adding the vector3 with updated position based on the speed and time. This script is attached to the Robber game object.
-----------------------------------------------------------------------------------
2. Character Can Move Side-to-Side with A/D or Left/Right Arrow Keys (10 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented giving your character the ability to move
side-to-side. e.g. Which script did you write that implements this? (Mention 
whether this script was attached to any game object and which ones.)

In the character controller script I implemented when the player presses the key down the character will move to the direction as specified by the key pressed. The script is attached to the player/robber game object
-----------------------------------------------------------------------------------
3. Character Can Jump with Space (10 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented giving your character the ability to jump.
e.g. Which script did you write that implements this? (Mention whether this script
was attached to any game object and which ones.)

In the character controller script when S, down arrow or spacebar is pressed the character will jump by adding force to go upward on the gameobject wich is the player. This script is attached to the player game object.
-----------------------------------------------------------------------------------
4. Character Dies When Falling in a Gap (20 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented giving your character the ability to die when
falling in a gap. e.g. Which script did you write that implements this? (Mention 
whether this script was attached to any game object and which ones.)

What happens when your character "dies"? e.g. Do you get Game Over, restart the
level, or lose some life?

In the character controller script when the player hits a net that is placed under each platform, the player loses -10 or -20 health and calls a function in the game controller script that restarts the level with the players current health status.
The character conroller is attached to the player game object and the game contoller script is attached to a game controller object.
-----------------------------------------------------------------------------------
5. Procedurally Generated Levels (20 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented procedurally generated levels, especially 
how you randomized the objects and placement of these objects or gaps. e.g. Which 
script did you write that implements this? (Mention whether this script was 
attached to any game object and which ones.)

The game controller script calls a function to change the level with increased speed and more obstacles. The platform generator script create the platform and objects at different xyz positions. Based on the level number more objects will be generated. The platform generator and game controller are attached to the game controller object.
-----------------------------------------------------------------------------------
6. Advancing Levels After Not Dying for 30 Seconds (20 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented your character advancing to the next level
after 30 seconds of not dying. e.g. Which script did you write that implements 
this? (Mention whether this script was attached to any game object and which ones.)

The game controller script starts a countdown timer at the start of each level, when the time is 0 the changeLevel function is called and also checks the health of the player throughout the game. The script is attached to the game controller object.

Briefly describe what pops up when you advance to the next level. If there is a 
script associated with this, what is it and what game object is it attached to?

When you complete a level a pop up says "Congrats you passed the level!". In the game controller script the congrats message panel is set to active when the time is 0 and deactivates it at the start of the new level. The script is attached to the game controller object with the panel assigned to it.

-----------------------------------------------------------------------------------
7. Current Level and Time Counter from 0 to 30 Seconds (20 pts)
-----------------------------------------------------------------------------------
Briefly describe how you implemented this being displayed somewhere on the screen. 
e.g. Which script did you write that implements this and how is the current level
updated? (Mention whether this script was attached to any game object and which 
ones.)

I used a text box that is at the top right of the screen. In the game controller script as the timer is updated the text is also update to show the current time. The script is attached to the game controller object.
-----------------------------------------------------------------------------------
8. Randomly Spawning Power-Ups (20 pts)
-----------------------------------------------------------------------------------
List the power-ups/downs that you implemented in your game (minimum of 3) and the
object associated with that power-up (such as a yellow coin, blue star, etc.):

     Power-Up/Down Object       |       Power-Up/Down Effect
1) red green pepper             |       jumps higher: +5 jump intensity
2) yellow taco                  |	run slower: -3 speed
3) red drink			|	run faster: +7 speed
4) green avocado		|	increase health: +20 health

Briefly describe how you implemented this being displayed somewhere on the screen,
especially how you randomized the objects and placement of these objects. e.g. 
Which script did you write that implements this? (Mention whether this script was 
attached to any game object and which ones.)

The platform generator script create the objects at different xyz positions. Based on the level number more objects will be generated. Level 1+ pepper and wall. Level 2+ taco and drink. Level 3+ Avocado and cop. The platform generator and game controller are attached to the game controller object.
-----------------------------------------------------------------------------------
9. Two Other Things Besides Falls That Can Kill You When You Hit Them (20 pts)
-----------------------------------------------------------------------------------
List the 2 other things besides falls that can kill you when you hit them that you 
implemented in your game (minimum of 2). Please mention what these things are:

     Thing that Can Kill You When You Hit It
1) gray wall	| 	-10 health                          
2) cop		|	-30 health                           

Briefly describe how you implemented this being displayed somewhere on the screen,
especially how you randomized these things and the random placement of these
things. e.g. Which script did you write that implements this? (Mention whether 
this script was attached to any game object and which ones.)

The platform generator script create the objects at different xyz positions. Based on the level number more objects will be generated. Level 1+ pepper and wall. Level 2+ taco and drink. Level 3+ Avocado and cop. The platform generator and game controller are attached to the game controller object.
-----------------------------------------------------------------------------------
Any Notes or Things the Professor or TA/Grader Should Be Aware Of
-----------------------------------------------------------------------------------
If there are any other concerns that you have about your submission or any known
bugs/glitches in your game that could potentially come up, please explain them here:

The level starts easy with only the wall and pepper objects. At level 2 the previous objects along with the taco and the drink are added. At level 3 the previous objects and the cop and avocado objects are added. The number of objects are random so some platforms may have many objects and some may have none.

