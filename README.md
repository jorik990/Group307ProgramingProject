  # Group307ProgramingProject
  
  README v0.0 / 02 DECEMBER 2016

# Group307ProgramingProject
## Introduction

We are group 307 and we decided to create the board game: Ludo. We created two repositories one for the server and one for the client.
This mini-project was created for academic purpose.

## Table of Contents

0. Introduction
1. Table of Content
2. Usage
3. Contributing
4. Help
5. Installation
6. Requirements
7.  Configuration
8. Communication protocol between the server and the client
9. UML class and sequence diagrams
10. Credits
11. Contact

 

## Usage

This application is for entertainment purposes. We made the traditional version that allows up to four players. The game is made in Unity and has the same rules as the traditional version.

## Contributing

This mini-project is a Programming Complex of Software System assignment for medialogy students in Aalborg University of Copenhagen. It is assigned for groups of medialogy students of third semester. 

## Help

To request help regarding the repository file Group307ProgramingProject, please contact our group members through moodle.aau.dk

### Requirements

To open the Group307ProgramingProject file, Unity is needed on every player’s computer (for networking reasons) and a github account (to get access to files).

### Installation

To install Group307ProgramingProject file go through described below steps:
1. Sign in GitHub account 
2. Go to site: https://github.com/jorik990/Group307ProgramingProject 
3. Click on the button ("Clone or download")
4. Clone repository to your GitHub desktop 
5. Open Unity and open the  Group307ProgramingProject file
6. Connect to the network (all players should be connected to the same network)
7. One player must be host and others must choose the host’s IP address and press “join”
8. When players join the lobby, the host should start game

### Communication protocol between the server and the client
We use TCP to send strings from the clients to the server
Each client is its own coroutine.

## UML class and sequence diagrams

 
 
## Configuration
The host press host and he will enter a lobby, to join his lobby the other players have to type in the host ipv4 address in the input field and then press join. the host can press start game to start the game for everyone in the lobby. When the game is playing only one person is able to roll at a time. If a player rolls six they will get a pawn out, he has 3 tries if he currently have no pawn out, if he do have a pawn out he can choose to move a pawn or get one out when rolling a 6, he will choose which pawn to move or get out with the mouse. The game automatically shift turns when the player have no more options, a small text field under the roll button gives instructions.


## Credits

307 group members: 
Magnus Håkon Petersen
Billie Sevelsted Berthelsen 
Marc Holst Christiansen
Keiran Richard Araza
Maria Sroka
Georgi Ivanov

## Contact

To contact us please write on forum for Medialogy students on moodle.aau.dk or write mail k16ml307@create.aau.dk
