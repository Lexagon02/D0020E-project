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
    if(x!=0 or y!=0):       #Check if the camera sees the sword
        x=x/5-60-(angle-180)/2  #Fine tune coords to fit into screen
        x=-x
        y=-y/5+40
        
        if(1>h/260>-1):
            xAngle=math.degrees(math.acos(h/260))
        else:
            xAngle=0
        #UnityEngine.Debug.Log(xAngle)
        
        curpos=sword.GetComponent(Rigidbody).position  #Get the current pos from sword
        newAcc = Vector3(x-curpos.x,y-curpos.y,0)*speed #Calculate new vector
        sword.GetComponent(Rigidbody).velocity=newAcc   #Set new velocity
        sword.GetComponent(Rigidbody).MoveRotation(UnityEngine.Quaternion.Euler(xAngle,0,angle))#Set new rotation
        UnityEngine.Debug.Log(sword.GetComponent(Rigidbody).velocity)
    else:           #If not set velocity to zero
        sword.GetComponent(Rigidbody).velocity=Vector3.zero


#Update both swords
updateSword(redSword,redx,redy,redw,redh,redangle)
updateSword(blueSword,bluex,bluey,bluew,blueh,blueangle)
