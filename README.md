# 3D Formations
#### Basic implementation
>At the start of the project, the first agent is promoted to the leader. All the other agents calculate their offset towards the leader. When the leader moves, the other agents try to stay in the offset.

##### Example
>Lets say the leader starts in the center (0,0). One of the agents could be spawned at (1,0). This means that the other agent is spawned 1 unit to the right of the leader. We set the target for our leader to (-3,3). At a certain point the leader will cross the point (-1,1). At this point in time the target for the agent will be set to (0,1). Once the leader has arrived at (-3,3), the target for the other agent will be set to (-2,3).
