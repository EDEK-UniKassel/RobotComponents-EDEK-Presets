# Getting and checking position data

The position data of the external axes and the robots have to match with the data as defined in your Grasshopper file, the data in the (virtual or physical) controller and the physical setup. In this section it is explained how to get the position data from the controller in Robot Studio and how to use this data inside Grasshopper. The defined presets (especially the external linear axes) should already match with the position as how they defined in the physical controller, however, the user should always check this before using the physical setup. There is  one other important note and rule you have to know before you work with the physical controller:

***Guests and students are not allowed to change the position frames of the robots and external axes in the physical controller without permission of the EDEK staff members.***

Wants connected to a virtual or physical controller you can look up the robot and external axis positions as follows in Robot Studio:

- Robot positions: Go to the tab `Controller`. Select in the left menu the tab `Configuration`. Go to `Motion`. From the `Type` list you have to select `Robot`. Here you can look up the position data of the robot(s). Check [this figure](Utility/Figures/Robot_studio_robot_position.png) for a visual explanation. 

- External axis positions: Go to the tab `Controller`. Select in the left menu the tab `Configuration`. Go to `Motion`. From the Type list you have to select `Single`. Here you can look up the position data of the external axes. Check [this figure](Utility/Figures/Robot_studio_external_axis_position.png) for a visual explanation.

The position and its orientation are given as coordinates (`Base Frame x`, `Base Frame y` and `Base Frame z`) and quaternion values (`Base Frame q1`, `Base Frame q2`, `Base Frame q3`, `Base Frame q4`).  In grasshopper these values can be converted to a plane by using the [Quaternion to Plane](https://robotcomponents.github.io/RobotComponents-Documentation/docs/Utility/Quaternion%20to%20Plane/) component. A simple example is given below.

<img src="Utility/Figures/Construct_Quaternion_to_Plane.png" width="368" height="203" />

To check if an already defined robot or external axis is matching the position as defined in the physical or virtual controller the robot or external axis can be deconstructed with one of deconstruct components ([this](https://robotcomponents.github.io/RobotComponents-Documentation/docs/Deconstruct/Definitions/Deconstruct%20Robot/), [this](https://robotcomponents.github.io/RobotComponents-Documentation/docs/Deconstruct/Definitions/Deconstruct%20External%20Linear%20Axis/) or [this](https://robotcomponents.github.io/RobotComponents-Documentation/docs/Deconstruct/Definitions/Deconstruct%20External%20Rotational%20Axis/) component). The position or axis plane can be converted to quaternion values by using the [Plane to Quaternion](https://robotcomponents.github.io/RobotComponents-Documentation/docs/Utility/Plane%20to%20Quarternion/) component. Examples are given in the figure below.

<img src="Utility/Figures/Deconstruct_Plane_to_Quaternion.png" width="722" height="547" />
