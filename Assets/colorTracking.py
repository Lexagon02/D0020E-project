import numpy as np 
import cv2 
from shared_memory_dict import SharedMemoryDict
  
# Capturing video through webcam 
webcam = cv2.VideoCapture(0) 
smd_config = SharedMemoryDict(name='config', size=1024)  
# Start a while loop 
def getCoord():
    coordRed=0,0,0,0,0
    coordBlue=0,0,0,0,0
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
    red_lower = np.array([120, 80, 180], np.uint8) 
    red_upper = np.array([180, 255, 255], np.uint8) 
    red_mask = cv2.inRange(hsvFrame, red_lower, red_upper) 
  
    # Set range for green color and  
    # define mask 
    green_lower = np.array([115, 20, 99], np.uint8) 
    green_upper = np.array([120, 100, 100], np.uint8) 
    green_mask = cv2.inRange(hsvFrame, green_lower, green_upper) 
  
    # Set range for blue color and 
    # define mask 
    blue_lower = np.array([100, 95, 140], np.uint8) 
    blue_upper = np.array([120, 255, 255], np.uint8) 
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
            box = np.int0(box)
            imageFrame = cv2.drawContours(imageFrame,[box],0,(0,0,255),2)
            if(w<h):
                angle=angle+180
            else:
                angle=angle+90
            coordRed=x,y,w,h,angle
    
    # Creating contour to track green color 
    contours, hierarchy = cv2.findContours(green_mask, 
                                           cv2.RETR_TREE, 
                                           cv2.CHAIN_APPROX_SIMPLE) 
      
    for pic, contour in enumerate(contours): 
        area = cv2.contourArea(contour) 
        if(area > 1000): 
            x, y, w, h = cv2.boundingRect(contour) 
            imageFrame = cv2.rectangle(imageFrame, (x, y),  
                                       (x + w, y + h), 
                                       (0, 255, 0), 2) 
              
            cv2.putText(imageFrame, "Green Colour", (x, y), 
                        cv2.FONT_HERSHEY_SIMPLEX,  
                        1.0, (0, 255, 0))
            
  
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
            box = np.int0(box)
            imageFrame = cv2.drawContours(imageFrame,[box],0,(255,0,0),2)
            if(w<h):
                angle=angle+180
            else:
                angle=angle+90
            coordBlue=x,y,w,h,angle
              
    # Program Termination 
    cv2.imshow("Multiple Color Detection in Real-TIme", imageFrame) 
    if cv2.waitKey(10) & 0xFF == ord('q'): 
        cap.release() 
        cv2.destroyAllWindows() 
        return
    return coordRed+coordBlue


while(True):
    coords=getCoord()
    print(coords)
    smd_config["status"] = coords      #Store coordinates in shared memory
