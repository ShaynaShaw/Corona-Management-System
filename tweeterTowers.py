"""Twitter towers
By Shayna Shaw
4.5.2023"""


import math


def main():
    user_input = input("Choose tower:\n 1. Rectangle\n 2. Triangle\n 3. exit\n")
    while user_input != '3':
        try:#
            height, width = list(map(int, input("Please insert the height and width of the tower:\n").split()))
        except:#
            print('Not enough values, terminated program')
            exit(0)
        if user_input == '1':
            handleRectangle(height, width)
        elif user_input == '2':
            handleTriangle(height, width)
        #else: #invalid input
         #   print('Invalid input, try again...')  
        user_input = input("\nChoose tower:\n 1. Rectangle\n 2. Triangle\n 3. exit\n")


def handleRectangle(height, width):
    if height == width or abs(height-width)>5:
        print(f'The area of the tower is: {height*width}')
    else:
        print(f'The perimeter of the tower is: {2*height + 2*width}')


def handleTriangle(height, width):
    user_input = input("Choose an option:\n 1. Calculate tower perimeter\n 2. Print tower\n")
    if user_input == '1':
        side = math.sqrt(pow(height, 2) + pow(width/2, 2))
        print("The perimeter of the tower is: ", "{:.2f}".format(2*side + width))
    elif user_input == '2':
        if width%2 == 0 or width > 2*height:
            print(f'The tower cannot be printed, sorry:)')
        else:
            printTriangle(height, width)
            

def printTriangle(height, width):
    stars = 1
    spaces = (width - stars)//2
    print(' '*spaces, '*'*stars, ' '*spaces)
    if width != 3:
        rows = (height - 2) // (width//2 - 1) #number of rows that contain same number of stars
        extraRows = (height - 2) % (width//2 - 1) #number of extra rows to add on to top
    else:
        rows = height - 2
        extraRows = 0
    for i in range(extraRows):
        print(' '*(spaces-1), '*'*(stars+2), ' '*(spaces-1))
    for i in range((height-2-extraRows)//rows):
        stars += 2
        spaces -= 1
        for row in range(rows):
            print(' '*spaces, '*'*stars, ' '*spaces)            
    print(' '*(spaces-1), '*'*width, ' '*(spaces-1))

    
if __name__ == "__main__":
    main()