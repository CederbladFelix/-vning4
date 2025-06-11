Övning 1

•	När ökar listans kapacitet:

När man försöker lägga till ett till element som överskrider listans kapacitet.

•	Hur mycket ökar kapaciteten?

Den dubblas

•	Varför ökar inte listans kapacitet i samma takt som element läggs till?

Jag tror att det är för att då hade man behövt göra en ny underliggande array varje gång man lägger till ett element vilket hade varit ineffektivt.

•	Minskar kapaciteten när element tas bort ur listan?

Inte vad jag ser. NEJ

•	När är det fördelaktigt att använda en egendefinierad array istället för en lista?
När man vet ungefär hur många element man ska ha. Jag kan tänka mig att man kan göra en egen listimplementation som inte dubblar arraysizen också om man förväntar sig ett tak på elementen över sikt. Det blir ytterst problematisk om man har stora datamängder och så bestämmer sig listan för att dubbla. Då kan en egenimplementation vara smartare.

Övning 3

•	Varför är det inte så smart att använda en stack i det här fallet?

För att då får den sist i kön bli serverad först varje gång och den som är först i ledet kommer onekligen få vänta.

Övning 6

•	Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av ovanstående funktioner är mest minnesvänlig och varför?

Den iterativa. Rekursion håller alla anrop till den når basfallet i en stack vilket gör att det kan leda till stackoverflow om det blir för många. Iteration använder konstant mängd minne.
