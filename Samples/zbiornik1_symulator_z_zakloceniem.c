#include <stdio.h>
#include <unistd.h>

int main()
{

	//Deklaracja zmiennych użytkownika:
	//Kod użytkownika:
	char x1, x2, Z1, Z2, Z3, stan=1, tim; // definicje, cykl 0.1 s
	
    while (1)
    {    
		

		// ----------------------------------
		x1=INPUT[0];x2=INPUT[1];
		switch(stan) {
		 case 1: Z1=1; Z2=1; Z3=0;
		 if (x1) { tim=50; stan=2; }
		 break;
		 case 2: Z1=1; Z2=0; Z3=0;
		 if (!tim||x2) { tim=20; stan=3; } else if (!x1) stan=1;
		 break;
		 case 3: Z1=0; Z2=0; Z3=1;
		 if (!tim) { tim=30; stan=4; } else if (!x1) stan=1;
		 break;
		 case 4: Z1=0; Z2=0; Z3=0;
		 if (!tim) { tim=30; stan=3; } else if (!x1) stan=1;
		 break;
		}
		if (tim) --tim; 
		OUTPUT[0]=Z1; OUTPUT[1]=Z2; OUTPUT[2]=Z3; 
		L1 = x1; L2=x2;
		
		
    }
}
