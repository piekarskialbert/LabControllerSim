#include <stdio.h>
#include <unistd.h>

int main()
{

	//Deklaracja zmiennych użytkownika:
	char x1, x3, Z1, Z2, Z3, G, M, tim, T, stan=1; 
	
    while (1)
    {    
    	//Kod użytkownika:
    	x1=INPUT[0]; x3=INPUT[1]; T=INPUT[2]; // wczytaj wartości wejść
		switch(stan) {
			 case 1: Z1=1; Z2=1; Z3=0; G=0; M=0;
				 if (x1) { tim=30; stan=2; } // timer: 3.0/0.1=30
				 break;
			 case 2: Z1=1; Z2=0; Z3=0; G=0; M=0;
				 if (!tim) { tim=30; stan=3; } // skończył się czas -> 3
				 else // albo
				 if (x3) { tim=50; stan=4; } // napełniono zbiornik -> 4
				 break;
			 case 3: Z1=0; Z2=1; Z3=0; G=0; M=0;
				 if (!tim) { tim=30; stan=2; } // skończył się czas -> 2
				 else // albo
				 if (x3) { tim=50; stan=4; } // napełniono zbiornik -> 4
				 break;
			 case 4: Z1=0; Z2=0; Z3=0; G=1; M=0;
				 if (!tim&&!T) { tim=50; stan=7; } // skończył się czas 
				 								   // i temperatura nie osiągnięta -> 7
				 else // albo
				 if (!tim&&T) { tim=30; stan=5; } // skończył się czas 
				 								  // i temperatura osiągnięta -> 5
				 break;
			 case 5: Z1=0; Z2=0; Z3=1; G=0; M=1;
				 if (!tim) { tim=30; stan=6; } // skończył się czas -> 6
				 else
				 if (!x1) stan=1; // opróżniono zbiornik -> 1
				 break;
			 case 6: Z1=0; Z2=0; Z3=1; G=0; M=0;
				 if (!x1) stan=1; // opróżniono zbiornik -> 1
				 else
				 if (!tim) { tim=30; stan=5;} // skończył się czas -> 5
				 break;
			 case 7: Z1=0; Z2=0; Z3=0; G=1; M=0;
				 if (T || !tim) { tim=30; stan=5; } // // skończył się czas 
				 									   // lub temperatura osiągnięta -> 5
				 break;
		} // ---- koniec "switch"
		if (tim) --tim; // dekrementuj timer co cykl
		OUTPUT[0]=Z1; OUTPUT[1]=Z2; OUTPUT[2]=Z3; OUTPUT[3]=G; OUTPUT[4]=M; 
		
		
    }
}
