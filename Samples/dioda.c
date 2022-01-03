#include <stdio.h>
#include <unistd.h>

int main()
{

	//Deklaracja zmiennych użytkownika:
	char KL, LD, stan=1,tim;

    while (1)
    {
    	//Kod użytkownika:
    	
		 KL=aK1;
		switch(stan) {
			case 1: LD=0;
					if (KL) { tim=30; stan=2; } // timer: 3.0/0.1=30
					break;
			case 2: LD=1;
					if (!tim) stan=3; // skończył się czas -> 3
					else // albo
					if (!KL) stan=1; // puszczono klawisz -> 1
					break;
			case 3: LD=0;
					if (!KL) stan=1; // puszczono klawisz -> 1
				 	break;
		} // ---- koniec "switch"
		if (tim) --tim; // dekrementuj timer co cykl
		 // i ustaw wyjścia
		 L1=LD;

    }
}
