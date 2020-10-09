# raceCondition

## Wat is multithreading?
Een thread van een proces voert één voor één de instructies uit die de programmeur heeft gespecificeerd. Elk programma heeft minstens één thread, de main thread, en kan meer threads starten om taken simultaan uit te voeren. Elke thread heeft zijn eigen stack, instruction pointer en cpu register, maar heap en static/global data is gedeeld.
In een computer met meerdere cpu cores kunnen processen en threads parallel worden uitgevoerd. In computers met maar één core wordt de cpu rekenkracht verdeeld door heel snel te switchen.

new Thread
new Task?


## Wanneer gebruik je meerdere threads?
Je kunt threads gebruiken om instructies op uit te voeren zonder de main thread te onderbreken.  Het voordeel ervan is dat een programma sneller kan zijn, door taken te verdelen over threads. Een ander voordeel is dat je programma meer responsive kan zijn, bijvoorbeeld in het geval dat je de event loop van een ui op een thread uitvoert die nooit geblokkeerd wordt door zware of lange taken. 

## Wat zijn drie veel voorkomende problemen bij mutithreaded applications? Waardoor ontstaan ze?
Het feit dat verschillende threads data uit de heap delen is een voor- en nadeel. Het is een voordeel omdat het communicatie tussen threads vergemakkelijkt. Het nadeel is dat ze elkaar in de weg kunnen zitten en crashes van het proces kunnen veroorzaken. Debuggen ervan is moeilijk, want bugs manifesteren vaak pas onder stressvolle condities. Problemen zijn:
1) Races: Races doen zich bijvoorbeeld voor als twee threads beide een counter willen ophogen. De threads hebben hun eigen register waar de waarde tijdelijk wordt opgeslagen (t.b.v. snelheid) en daarna wordt de waarde opgeslagen in de heap (bij object fields) of het data-segment van de RAM (globals en statics). Terwijl de waarde in een register zit heeft een andere thread er geen weet van. Als beide threads hun uiteindelijke waarde willen opslaan in RAM kan een ophoging zijn gemist. 
2) Deadlocks?
3) ...

## Hoe wordt het onderdeel genoemd waar objecten in het geheugen worden geplaatst?
Heap

## Hoe is dit verschillend in een multithreaded application?
Niet

## Hoe wordt het onderdeel genoemd waar methoden worden uitgevoerd en primitive types in het geheugen worden geplaatst?
Stack

## Hoe is dit verschillend in een multithreaded application?
Elke thread heeft zijn eigen stack

## Wat is in dit kader een racing condition? Hoe zou je dit kunnen voorkomen?
Dit zijn de condities waarbij een Race kan ontstaan:
1 memory locatie die te bereiken is vanuit meerdere threads (in of via global/static data)
2 eigenschap van de data in die locatie die van belang is voor juiste uitvoering van programma
3 de eigenschap klopt niet op elk moment
4 een andere thread krijgt toegang op dat moment

Beter voorkomen, dan genezen: 
- 1 en 2 voorkomen door globals en statics te vermijden
- 3 voorkomen door objecten immutable te maken, dus fields final (const) te maken. 
- 4 voorkomen door te werken met Locks:

	C#: lock(lockObject){}
	Under the hood worden in .NET methodes Enter en Exit van System.Threading.Monitor gebruikt. Deze laten weten of een thread toegang heeft. Andere threads wachten dan tot het Lock-object (Object class) vrijgegeven is, voordat zij toegang krijgen. De Monitor class heeft meer bruikbare methodes om threads te laten samenwerken. 
	
	Java: synchronized(lockOject){} 
	Dit doet hetzelfde in Java. Het lockObject moet een instantie van de Lock class zijn. Je kunt ook het synchronized keyword in de signatuur van een methode gebruiken, maar dan houd je niet de flexibliteit van een custom Lock. Daarnaast kun je in Java (vergelijkbaar met C#) werken met lockObject.lock() (C# Enter) en .unlock (C# Exit).
	

	Java: Semaphore??

	Locking brengt op zijn beurt weer het risico op een deadlock mee. Dat gebeurt als threads in een cyclus op elkaar wachten en dus nooit uit een lock komen.


## Maak een Proof of Concept met multithreading, een race condition en een valide oplossing
!!

### Bronnen
https://www.backblaze.com/blog/whats-the-diff-programs-processes-and-threads/
https://docs.microsoft.com/nl-nl/archive/blogs/vancem/encore-presentation-what-every-dev-must-know-about-multithreaded-apps
https://www.webucator.com/how-to/how-prevent-race-conditions-java-8.cfm
https://medium.com/swlh/race-conditions-locks-semaphores-and-deadlocks-a4f783876529
https://www.pluralsight.com/guides/lock-statement-access-data