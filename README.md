In the repo there is two builds provided, one for Windows and and one for Mac.

In order to run the game you must have a camera connected. Use the "runGame.bat" file to start the game, which opens both the python colortracking script and the game. 

In OpenHouseDemoGame_Data\StreamingAssets\colors.json the HSV values (Hue,Saturiation,Value) used in the python script is stored. The values must be between 0-255 (Note that 255 wraps around to 0) . If the script is not picking up the colors it should you must increase the values between the upper and lower bound. If the script instead highlights colors it should not the difference between the lower and upper bound must shrink.

This link has some more info on HSV and how the values affects the color. Use this information to finetune the script for your camera and enviroment.
https://tinf2.vub.ac.be/~dvermeir/manual/gimp/Grokking-the-GIMP-v1.0/node51.html

Note that different lighting conditions will require different values for the script to work optimally.


