from UnityEngine import GameObject, PrimitiveType, Vector3, Rigidbody, ForceMode
from shared_memory_dict import SharedMemoryDict
smd_config = SharedMemoryDict(name='config', size=1024) #Pip install shared-memory-dict first
import UnityEngine,math

tracking=smd_config["status"] #Get coordinates from colortracking.py via shared memory


#Red sword input from colortracking.py
redx=tracking[0]
redy=tracking[1]
redw=tracking[2]
redh=tracking[3]
redangle=tracking[4]


#Blue sword input from colortracking.py
bluex=tracking[5]
bluey=tracking[6]
bluew=tracking[7]
blueh=tracking[8]
blueangle=tracking[9]

#Speed of the swords movement
speed=5

#Find gameObjects in unity
redSword = GameObject.Find("redSword")
blueSword = GameObject.Find("blueSword")


def updateSword(sword,x,y,w,h,angle):
    if(abs(w)>abs(h)):
        h=abs(w)
    else:
        h=abs(h)

    if(x!=0 and y!=0):       #Check if the camera sees the sword
        x=57-x/20 #Fine tune coords to fit into screen
        y=12-y/20
        if(1>h/260>-1):
            xAngle=math.degrees(math.acos(h/260))
        else:
            xAngle=0
        
        curpos=sword.GetComponent(Rigidbody).position  #Get the current pos from sword
        sword.GetComponent(Rigidbody).position=Vector3(curpos.x,curpos.y,9)
        newAcc = Vector3(x-curpos.x,y-curpos.y,0)*speed #Calculate new vector
        sword.GetComponent(Rigidbody).velocity=newAcc   #Set new velocity
        sword.GetComponent(Rigidbody).MoveRotation(UnityEngine.Quaternion.Euler(xAngle,0,angle))#Set new rotation
        
    else:           #If not set velocity to zero
        sword.GetComponent(Rigidbody).velocity=Vector3.zero
        #sword.GetComponent(Rigidbody).rotation=UnityEngine.Quaternion.Euler(0,0,0)


#Update both swords
updateSword(redSword,redx,redy,redw,redh,redangle)
updateSword(blueSword,bluex,bluey,bluew,blueh,blueangle)
