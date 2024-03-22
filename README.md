There are two builds of this project, one for Windows and one for Mac.

Windows:https://drive.google.com/file/d/18YjD4ciJwGJMowzGv_h4kHs_6kNrVWmk/view?usp=sharing
Mac:https://drive.google.com/file/d/1HO-gjYRolhCKsl4tGTgjjv9avVX6NiU_/view?usp=sharing

WINDOWS:
In order to run the game you must have a camera connected. Use the "runGame.bat" file to start the game, which opens both the python colortracking script and the game. 
MAC:
In order to run the game you must start the colorTrackign executable that is located in Contents\Resources\Data\StreamingAssets\Mac\. After that the game can be started.


In OpenHouseDemoGame_Data\StreamingAssets\Windows\colors.json ( for mac Contents\Resources\Data\StreamingAssets\Mac\colors.json) the HSV values (Hue,Saturiation,Value) used in the python script is stored. The values must be between 0-255 (Note that 255 wraps around to 0) . If the script is not picking up the colors it should you must increase the values between the upper and lower bound. If the script instead highlights colors it should not the difference between the lower and upper bound must shrink.

This link has some more info on HSV and how the values affects the color. Use this information to finetune the script for your camera and enviroment.
https://tinf2.vub.ac.be/~dvermeir/manual/gimp/Grokking-the-GIMP-v1.0/node51.html

Note that different lighting conditions will require different values for the script to work optimally.

In order to build the unity project for mac you need to change the path in Sword.cs to Contents\Resources\Data\StreamingAssets\Mac\colors.json
