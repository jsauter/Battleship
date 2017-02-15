#Welcome to Battleship!#

This is my implementation of the Battleship game.

##Building and Running

To run the application just build the solution (or use MSBuild) and run the exe out of the console project.  As per the requirements document you can place one battle ship (size 3 cruiser) either horizontally or vertically.

Tests are currently all passing. I have covered a lot of sunny day scenarios as well as a bunch of edge cases and exceptions.

##Architecture

I approached this application like games I have worked on in the past. There is an executable layer that runs a game engine in the layer below it. Game state is managed independently from the UI. 

Dependencies are injected in using the a IoC container.

Board size and max number of players can be configured in the app.config of the UI layer.  Presently the game supports only two players as I don't know how you would play Battleship with three people.

There was no need for a repository or gateway layer in this application so the domain remained pretty flat. 

The GameState API allows you to use run the game in any situation where there is a fat client using it. It could, in theory, be ported over to WPF, WinForms or a mobile project very easily.

The approach to using the API is as follows...

1) Create a game state

2) Add boards to the game state with players names

3) Player 1 starts by passing in a shot coordinage

4) Tell the game state that Player 1's turn is over

5) Player 2 does their turn

6) Repeat

7) Display results

I decided to use an orchestrator type class in the UI to manage the workflow for the input and out of the game. If this was a fat client, it would be handled asynchronously with a UI thread.

User input (because it is textual in this case) is translated to cartesian cordinates that can be represented in the grid with ints. There was no sense in maintaing two arrays when it could be calculated. To do this, I converted the alpha chars to their numeric representaion in the CoordinateTranslator.

Feedback to the UI thread for bad data entry is done via exceptions (and handling them). This might not be the most performant way of doing it, but I think it worked well as it simplified what needed to be returned and performance for this application is not a major requirment.

##Assumptions

1) As per the requirements, since there is no need to add a second ship to the board, I did not validate for intersects on placement.

2) We check that there are only 2 players and if we try to add more, we throw an exceptions

3) There is only one type of ship right now. If we want to add more in the future there will be a UI change as well as the need to build a ship factory

##3rd party libraries used

Ninject

Moq