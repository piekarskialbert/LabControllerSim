#include <stdio.h>
#include <unistd.h>

int main()
{

	//Deklaracja zmiennych użytkownika:
	char KL, LD, stan=1,tim,znak;

    while (1)
    {
    	znak=COM_recv(); // odczyt odebranego znaku (komunikacja)
		if (znak=='1') KL=1; // jeśli odebrano znak '1', ustaw KL na 1
		if (znak=='0') KL=0; // jeśli odebrano znak '0', ustaw KL na 0
		if (znak=='#'){ // jeśli odebrano znak '#', odeślij komunikat
			COM_send(':');
			COM_send(LD+'0');
			COM_send('#');
			COM_send('\n');
		}
    	//Kod użytkownika:
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
    }
}
