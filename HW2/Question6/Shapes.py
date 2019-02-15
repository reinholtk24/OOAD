#Author: Kyle Reinholt
#Purpose: OOAD HW2 

# list of tuples simulating a database query
database = [(2,2,5,0,"circle"),
            (4, 4, 5, 1, "circle"),
            (2, 2, 10, 2, "square"),
           (5, 5, 5, 0, "triangle"),
            (2, 2, 10, 1, "circle"),
            (6, 6, 15, 2, "triangle"),
            (2, 2, 5, 0, "circle"),
            (7, 7, 5, 1, "square"),
            (2, 2, 5, 2, "square")]

def getShapesFromDB():
    shapes = []

    #instantiate shapes and put into list of Shape objects
    #Each instance inherits from the shape class. 
    for row in database:
        if(row[4] == "circle"):
            s = Circle(row[0],row[1],row[2],row[3],row[4])
            shapes.append(s)
        elif(row[4] == "square"):
            s = Square(row[0],row[1],row[2],row[3],row[4])
            shapes.append(s)
        elif(row[4] == "triangle"):
            s = Triangle(row[0],row[1],row[2],row[3],row[4])
            shapes.append(s)

    #sort shapes
    shapes.sort(key=lambda z: z.z)

    return shapes

# this is where the inheritance magic happens
def printList(l):
    for myshape in l:
        myshape.display()
        print(myshape.info())

def main():
    myShapes = getShapesFromDB()
    print("Number of shapes: " + str(len(myShapes)))
    printList(myShapes) 
    print("Number of shapes: " + str(len(myShapes)))

#Class Definitions 
class Shape:

    def __init__(self, x, y, length, z, shapeType):
        self.x = x
        self.y = y
        self.length = length
        self.z = z
        self.shapeType = shapeType

    def info(self):
        return "x: " + str(self.x) + " y: " + str(self.y) + "  size: " + str(self.length) + " z: " + str(self.z) + " shape: " + self.shapeType

    def shape(self):
        return self.shapeType

    def display(self):
        return "display" 

class Square(Shape):

    def __init__(self, x, y, length, z, shapeType):
        Shape.__init__(self,x,y,length,z,shapeType)

    def display(self): 
        for i in range(0,self.x): 
            for j in range(0,self.y):
                print(" ") 
            if(i + 1 == self.x): 
                break 
            else: 
                print " ",
                
        print("    ***    ")
        print("    * *   ")
        print("    ***    ")

class Circle(Shape):

    def __init__(self, x, y, length, z, shapeType):
        Shape.__init__(self,x,y,length,z,shapeType)

    def display(self): 
        for i in range(0,self.x): 
            for j in range(0,self.y):
                print(" ") 
            if(i + 1 == self.x): 
                break 
            else: 
                print " ",
                
        print("    ***    ")
        print("   *   *   ")
        print("    ***    ")

class Triangle(Shape):

    def __init__(self, x, y, length, z, shapeType):
        Shape.__init__(self,x,y,length,z,shapeType)

    def display(self): 
        for i in range(0,self.x): 
            for j in range(0,self.y):
                print(" ") 
            if(i + 1 == self.x): 
                break 
            else: 
                print " ",
                
        print("     *    ")
        print("   *   *   ")
        print("  * * * *  ")



main()

