# Anti-Grav
2-D Roguelite beat 'em up / "platformer" where the player will attempt to get as far as possible without dying. 
The player will be able to manipulate gravity so they can fall through the level while dodging enemies or 
move along the ground while fighting enemies.

The project was created in Unity with scripts written in C# as my end of Year 2 assignment for the Object 
Oriented Programming module while studying Computer Science (Hons) at the Dublin Institute of Technology.

Course Code: DT228/2, Student Number: C15332036.

The assignment was intentionally vague in its description to leave us students to choose what we would like to 
create. I chose to create a Unity game as it gave me a chance to learn both Unity, Game Design and basic C#

Link to video of the game running: (NOT YET CREATED)
 
[![Video](http://img.youtube.com/vi/rrI7ruHb1ws/0.jpg)](http://www.youtube.com/watch?v=rrI7ruHb1ws)

Given more time i would like to add more to this project and flesh out both the mechanics and graphics 
however due to the time constraints of the assignment I will have to leave it as it is. I may however come back 
to this at a later date once the assingment is corrected.

# Contents
The project consists of one relatively simple game that was inspired by several other games (e.g. Downwell, 
Gravity Rush, etc.), with all the scripts used being created by me.

It Contains:

1. A Main Menu screen where the player can begin or exit the game from.

2. Many assets and sprites, most of which were created by myself apart from the skybox being an image that I 
took from google. (The game was not created for profit)

3. Game itself which has been described briefly above.

4. A score system where the score is incremented each time the player kills an enemy and a score multiplier is 
also, incremented with each kill and when the player falls without colliding with any platforms.

5. Simple Randomly generated platforms to create a unique experience with each playthrough.

6. 2 types of randomly spawning enemies, one ground enemy which is simply a re-coloured player sprite and one 
and one flying bird enemy.

7. Scripts to clear enemies and platforms which are no-longer in view of the users’ camera to reduce the 
number of objects loaded at any one time.

8. A pause menu which stops the game running entirely, which allows the player to restart the game or return 
to the main menu.

9. A Game Over overlay which appears when the player dies, where the player can choose to restart the game or 
return to the main menu.

10. Health packs which the player can pick up to replenish lost health.

11. Several master manager scripts that are used to control most of the functionality of the game (such as 
pausing, restarting and health management), I was not made aware of the concept of these scripts until mid-way 
through development so they do not do everything I had hoped they would, this is due to time constraints and 
the difficulty associated with re-factoring already written code.

# Controls
Movement Controls can vary based on the current "gravity" that the player is experiencing.

* Left mouse click is used to punch.

* The Space bar is used to shift the gravity.

* Normal Gravity:

	* A and D are used to move left and right respectively.
	
	* W is used to jump.
	
* Altered Gravity:

	*W and S are used to move up and down respectively.
	
	* A is used to jump.
