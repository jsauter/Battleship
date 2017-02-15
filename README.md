#Welcome to Battleship!#

This is my implementation of the Battleship game.

##Building and Running

To run the application just build the solution (or use MSBuild) and run the exe out of the console project.  As per the requirements document you can place one battle ship (size 3 cruiser) either horizontally or vertically.

Tests are currently all passing. I have covered a lot of sunny day scenarios as well as a bunch of edge cases and exceptions.

##Architecture

I approached this application like games I have worked on in the past. There is an executable layer that runs a game engine in the layer below it. Dependencies are injected in using the ninject IoC container.

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

##3rd party libraries used

Ninject

