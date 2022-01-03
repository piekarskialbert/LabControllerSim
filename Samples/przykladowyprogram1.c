#include <stdio.h>
#include <unistd.h>
#include <inttypes.h>
#include <sys/time.h>
long long millis(void) {
    struct timeval tv;

    gettimeofday(&tv,NULL);
    return (((long long)tv.tv_sec)*1000)+(tv.tv_usec/1000);
}

int main()
{
	//Kod dołączany przy wgrywaniu na symulator:
	//Koniec kodu wgrywanego na symulator
	
	//Deklaracja zmiennych użytkownika:
	char KL, LD, stan=1;
	int tim;
	//Koniec deklaracji
	long long lastMillis = millis();
    while (1)
    {
   		//Kod dołączany przy wgrywaniu na symulator:


       //Koniec kodu wgrywanego na symulator
       
    	//Kod użytkownika:
    	
    	//if(millis() - lastMillis >=10){
    	lastMillis = millis();
		 // wczytaj wartości wejść
		 KL=aK1;
		switch(stan) {
			case 1: LD=0;
					if (KL) { tim=300; stan=2; } // timer: 3.0/0.1=30
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
		//}
		//Kod dołączany przy wgrywaniu na symulator:

       //Koniec kodu wgrywanego na symulator


    }
}
