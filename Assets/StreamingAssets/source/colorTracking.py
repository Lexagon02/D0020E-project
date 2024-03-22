import numpy as np 
import cv2
import json
import csv
import time
# Capturing video through webcam

webcam = cv2.VideoCapture(0)

#load data from color.json
f = open('color.json')

data = json.load(f)

#set lower and upper values
red_lower = np.array(data['colors']['red_lower'], np.uint8) 
red_upper = np.array(data['colors']['red_upper'], np.uint8)  

blue_lower = np.array(data['colors']['blue_lower'], np.uint8) 
blue_upper = np.array(data['colors']['blue_upper'], np.uint8) 

f.close()

# Start a while loop 
def getCoord():
    coordRed=0,0 #,0,0,0
    coordBlue=0,0 #,0,0,0
    # Reading the video from the 
    # webcam in image frames 
    _, imageFrame = webcam.read() 
  
    # Convert the imageFrame in  
    # BGR(RGB color space) to  
    # HSV(hue-saturation-value) 
    # color space 
    hsvFrame = cv2.cvtColor(imageFrame, cv2.COLOR_BGR2HSV) 
  
    # Set range for red color and  
    # define mask 

    red_mask = cv2.inRange(hsvFrame, red_lower, red_upper) 
  
    # Set range for green color and  
    # define mask q
    green_lower = np.array([115, 80, 99], np.uint8) 
    green_upper = np.array([120, 100, 100], np.uint8) 
    green_mask = cv2.inRange(hsvFrame, green_lower, green_upper) 
  
    # Set range for blue color and 
    # define mask 

    blue_mask = cv2.inRange(hsvFrame, blue_lower, blue_upper) 
      
    # Morphological Transform, Dilation 
    # for each color and bitwise_and operator 
    # between imageFrame and mask determines 
    # to detect only that particular color 
    kernel = np.ones((5, 5), "uint8") 
      
    # For red color 
    red_mask = cv2.dilate(red_mask, kernel) 
    res_red = cv2.bitwise_and(imageFrame, imageFrame,  
                              mask = red_mask) 
      
    # For green color 
    green_mask = cv2.dilate(green_mask, kernel) 
    res_green = cv2.bitwise_and(imageFrame, imageFrame, 
                                mask = green_mask) 
      
    # For blue color 
    blue_mask = cv2.dilate(blue_mask, kernel) 
    res_blue = cv2.bitwise_and(imageFrame, imageFrame, 
                               mask = blue_mask) 
   
    # Creating contour to track red color 
    contours, hierarchy = cv2.findContours(red_mask, 
                                           cv2.RETR_TREE, 
                                           cv2.CHAIN_APPROX_SIMPLE) 
      
    for pic, contour in enumerate(contours): 
        area = cv2.contourArea(contour) 
        if(area > 1000): 
            rect = cv2.minAreaRect(contour)
            ((x,y),(w,h),angle)=rect
            x=int(x)
            y=int(y)
            w=int(w)
            h=int(h)
            angle=int(angle)
            box=cv2.boxPoints(rect)
            box = np.intp(box)
            imageFrame = cv2.drawContours(imageFrame,[box],0,(0,0,255),2)
            if(w<h):
                angle=angle+180
            else:
                angle=angle+90
            coordRed=x,y,angle #,w,h
    

  
    # Creating contour to track blue color 
    contours, hierarchy = cv2.findContours(blue_mask, 
                                           cv2.RETR_TREE, 
                                           cv2.CHAIN_APPROX_SIMPLE) 
    for pic, contour in enumerate(contours): 
        area = cv2.contourArea(contour) 
        if(area > 1000):
            rect = cv2.minAreaRect(contour)
            ((x,y),(w,h),angle)=rect
            x=int(x)
            y=int(y)
            w=int(w)
            h=int(h)
            angle=int(angle)
            box=cv2.boxPoints(rect)
            box = np.intp(box)
            imageFrame = cv2.drawContours(imageFrame,[box],0,(255,0,0),2)
            if(w<h):
                angle=angle+180
            else:
                angle=angle+90
            coordBlue=x,y,angle #,w,h
    # Program Termination 
    cv2.imshow("Multiple Color Detection in Real-Time", imageFrame) 
    if cv2.waitKey(10) & 0xFF == ord('q'): 
        cap.release() 
        cv2.destroyAllWindows() 
        return
    return coordRed+coordBlue

   
        
while(True):
    try:#If camera is connected
        coords=getCoord()
    except:
        print("Please connect a camera and restart")
        break

    # save coords to .csv file
    try:#Try-catch for read/write permission exception
        with open('coordinates.csv', 'w', newline = '') as csvfile:
            for line in coords:
                csvfile.write(str(line) + '\n')
    except:
        continue

