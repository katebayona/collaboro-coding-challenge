# collaboro-coding-challenge
This repository contains the following the solutions to the secret code challenges:

## SCRecoverImage
A console application that fixes the RGB values of a distorted image to recover the original, revealing the secret code. The image (secretcode.png) to be fixed can be found in the Image folder. 
After running the application, the recovered image is saved in the Bin\Debug folder as recoveredImage.png.
## SCCodeBox
A console application that takes a codebox and a set of code numbers as input. The codebox input takes [code][value] as a format. It will be displayed in the form (code,value), (code, value) and so on. The code values, on the other hand,takes input for a code as a comma delimited set of numbers. The output is the decoded message using the two inputs.

## SCCodeBoxTest
A unit test created for the SCCodeBox.
