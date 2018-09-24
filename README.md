#Welcome to Battleship!

This is my implementation of the Battleship game.

##Building and Running

To run the application just build the solution in VisualStudio (or use MSBuild) and run the exe out of the console project.  As per the requirements document you can place one battle ship (size 3 cruiser) either horizontally or vertically.

Tests are currently all passing. I have covered a lot of sunny day scenarios as well as a bunch of edge cases and exceptions. Coverage for the entire solution is above 85%.  

##Architecture

I approached this application like other games I have worked on in the past. There is an executable layer that runs a game engine in the layer below it. Game state is managed independently from the UI. 

Dependencies are injected in using the a IoC container.

Board size and max number of players can be configured in the app.config of the UI layer.  Presently the game supports only two players as I don't know how you would play Battleship with three people.

There was no need for a repository or gateway layer in this application so the domain remained pretty flat. 

The GameState API allows you to use run the game in any situation where there is a fat client using it. It could, in theory, be ported over to WPF, WinForms or a mobile project very easily.

The approach to using the API is as follows...

1) Create a game state

2) Add boards to the game state with players names

3) Player 1 starts by passing in a shot coordinate

4) Tell the game state that Player 1's turn is over

5) Player 2 does their turn

6) Repeat

7) Display game results

I decided to use an orchestrator type class in the UI to manage the workflow for the input and output of the game. If this was a fat client, it would be handled asynchronously with a UI thread.

User input (because it is textual in this case) is translated to cartesian coordinates that can be represented in the grid with an int data type. There was no sense in maintaing two arrays when it could be calculated. To do this, I converted the alpha chars to their numeric representaion in the CoordinateTranslator.

Feedback to the UI thread for bad data entry is done via exceptions (and handling them). This might not be the best way of doing it for performance, but I think it worked well as it simplified what needed to be returned to the UI thread, and performance for this application is not a major requirment.

##Assumptions

1) As per the requirements, since there is no need to add a second ship to the board, I did not validate for intersects on placement.

2) We check that there are only 2 players and if we try to add more via the API (the UI prevents this from happening) there may be unexpected results.

3) There is only one type of ship right now. If we want to add more in the future there will be a UI change as well as the need to build a ship factory

4) For display, I left it so only the shots are recorded and displayed at the end, not the entire location of the ship.  This is how it would work in the real game, I believe.

##3rd party libraries used

Ninject

Moq

##Question

In the example screenshot, player 2 only makes 4 shots, but they sunk Player 1's ship with only one hit.  The ship would have required 3 shots, itself.  Shouldn't there have been 6 shots total?
