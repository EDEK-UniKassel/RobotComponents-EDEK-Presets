# Robot Components EDEK Presets
![Banner](https://github.com/EDEK-UniKassel/RobotComponents-EDEK-Presets/blob/master/Utility/Figures/Banner.png)

This repository contains the preset components of the robots and external axes of [EDEK Uni Kassel](https://edek.uni-kassel.de/). The preset components are made for the Rhinoceros Grasshopper plugin [Robot Components]( https://github.com/EDEK-UniKassel/RobotComponents). The presets are compiled in one separate grasshopper plugin (.gha file) that is build on top Robot Components. Installation of Robot Components is required to be able to work with the defined presets.

## Getting started
The installation is the same as for Robot Components. Download the latest release with presets directly from this repository's [release page](https://github.com/EDEK-UniKassel/RobotComponents-EDEK-Presets/releases). Download and place the `RobotoComponentEDEK.gha` file in the Grasshopper Components folder (in GH, File > Special Folders > Components Folder). Make sure that all the files are unblocked (right-click on the file and select `properties` from the menu. Click `unblock` on the `general` tab). Restart Rhino and you are ready to go! Under the Robot Components tab an additional category should be available with the preset components. Please read the information below for a detailed explanation on how to use the presets.

Detailled explanations of several topics is given in the following pages:

- [Getting and checking position data](POSITION_DATA.md)
- [World coordinate space in Brandthaus](BRANDTHAUS_COORDINATE_SPACE.md)
- [Defining the position of work piece positioners (external rotational axes)](CALIBRATION_WORK_PIECE_POSITIONERS.md)
