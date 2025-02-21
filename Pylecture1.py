

from math import ceil
import math


a, b = map(str, input().split());
while (a != "Y" and b != "Y"):
    if (a.isdigit() and b.isdigit()):
        print(int(a) + int(b))
    a, b = map(str, input().split());



n = 10
for b in range(round(n/2)):
    if (b - (round(n/2) - b - 1) >= 1):
        print(" " * (round(n/2) - b - 1) + "*" * (b - (round(n/2) - b - 1)) + " " * (n - 2 * b) + "*" * (b - (round(n/2) - b - 1)) + " " * (round(n/2) - b - 1))
for a in range(n):
    if((n - (a) * 2) > 0):
        print(" " * (a)  + "*" * (n - (a) * 2) + " " * (a))             


n = 5
s = ""
c = 0
ma = len(str(math.ceil((n*n)/2)))

for i in range(n):
    for j in range(n):
        
        if((j + i) % 2 == 0):
            print("*", end = '');
        else:
            if(len(str(c + 1)) == 1):
                print(" " + str(c + 1) + " ", end = '');
            else:
                print(" " + str(c + 1), end = '');
            c += 1 
    print()


        