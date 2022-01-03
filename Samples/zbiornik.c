#include <stdio.h>
#include <unistd.h>

int main()
{

	//Deklaracja zmiennych użytkownika:
	//Kod użytkownika:
	char x1, x2, Z1, Z2, Z3, stan=1, tim; // definicje, cykl 0.1 s
	
    while (1)
    {    
		
		x1=aK1; x2=aK2;
		switch(stan) {
		 case 1: Z1=1; Z2=1; Z3=0;
		 if (x1) { tim=30; stan=2; } // timer: 3.0/0.1=30
		 break;
		 case 2: Z1=1; Z2=0; Z3=0;
		 if (!tim) { tim=20; stan=3; } // skończył się czas -> 3
		 else // albo
		 if (x2) { tim=50; stan=4; } // napełniono zbiornik -> 4
		 break;
		 case 3: Z1=0; Z2=0; Z3=0;
		 if (!tim&&1) { tim=30; stan=2; } // koniec pauzy -> 2
		 break;
		 case 4: Z1=0; Z2=0; Z3=0;
		 if (!tim&&1) { tim=30; stan=5; } // oczekiwanie dokładnie 5 s
		 break;
		 case 5: Z1=0; Z2=0; Z3=1;
		 if (!tim) { tim=20; stan=6; } // skończył się czas -> 6
		 else // albo
		 if (!x1) stan=1; // opróżniono zbiornik -> 1
		 break;
		 case 6: Z1=0; Z2=0; Z3=0;
		 if (!tim&&1) { tim=30; stan=5; } // koniec pauzy -> 5
		 break;
		} // ---- koniec "switch"
		if (tim) --tim; // dekrementuj timer co cykl
		L1=Z1; L2=Z2; L3=Z3; 
		
		
    }
}
