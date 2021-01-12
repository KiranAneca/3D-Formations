# 3D Formations
## Basic implementation 
At the start of the project, the first agent is promoted to the leader. All the other agents calculate their offset towards the leader. When the leader moves, the other agents try to stay in the offset.

### Example
Lets say the leader starts in the center (0,0). One of the agents could be spawned at (1,0). This means that the other agent is spawned 1 unit to the right of the leader. We set the target for our leader to (-3,3). At a certain point the leader will cross the point (-1,1). At this point in time the target for the agent will be set to (0,1). Once the leader has arrived at (-3,3), the target for the other agent will be set to (-2,3).

## Different modes
#### As fast as possible
Using the (ASAP) method all the agents will move with their maximum speed towards the target. Since some are faster then other so on the way the formation will be broken. Once arrived the formation will be remade however. 
#### To the slowest
The formation will move with the speed of the slowest agent. This will cause the group to move slower, but they will not break formation allong the way.

## Different formations
#### Square formation
The agents will form a square around the leader in the middle.
#### V-formation
The agents will form an upside down v formation, with the leader at the top.
#### Random formation
All the agents (except for the leader) gain a random offset to the leader.
