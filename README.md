# raceCondition

## Wat is multithreading?
Een thread van een proces voert één voor één de instructies uit die de programmeur heeft gespecificeerd. Elk programma heeft minstens één thread, de main thread, en kan meer threads starten om taken simultaan uit te voeren. Elke thread heeft zijn eigen stack, instruction pointer en cpu register, maar heap en static/global data is gedeeld.
In een computer met meerdere cpu cores kunnen processen en threads parallel worden uitgevoerd. In computers met maar één core wordt de cpu rekenkracht verdeeld door heel snel te switchen.


## Wanneer gebruik je meerdere threads?
Je kunt threads gebruiken om instructies op uit te voeren zonder de main thread te onderbreken.  Het voordeel ervan is dat een programma sneller kan zijn, door taken te verdelen over threads. Een ander voordeel is dat je programma meer responsive kan zijn, bijvoorbeeld in het geval dat je de event loop van een ui op een thread uitvoert die nooit geblokkeerd wordt door zware of lange taken. 

## Wat zijn drie veel voorkomende problemen bij mutithreaded applications? Waardoor ontstaan ze?
Het feit dat verschillende threads data uit de heap delen is een voor- en nadeel. Het is een voordeel omdat het communicatie tussen threads vergemakkelijkt. Het nadeel is dat ze elkaar in de weg kunnen zitten en crashes van het proces kunnen veroorzaken.
- Debuggen moeilijker, bugs manifesteren pas onder stressvolle condities
- Races
- Locks

## Hoe wordt het onderdeel genoemd waar objecten in het geheugen worden geplaatst?
Heap

## Hoe is dit verschillend in een multithreaded application?
Niet

## Hoe wordt het onderdeel genoemd waar methoden worden uitgevoerd en primitive types in het geheugen worden geplaatst?
Stack

## Hoe is dit verschillend in een multithreaded application?
Elke thread heeft zijn eigen stack

## Wat is in dit kader een racing condition? Hoe zou je dit kunnen voorkomen?
Races doen zich bijvoorbeeld voor als twee threads beide een globale counter willen ophogen. De threads hebben hun eigen register waar de waarde tijdelijk wordt opgeslagen (t.b.v. snelheid) en daarna wordt de waarde opgeslagen in het data-segment van de RAM. Terwijl de waarde in een register zit heeft een andere thread er geen weet van. Als beide threads hun uiteindelijke waarde willen opslaan in RAM kan een ophoging zijn gemist. Hetzelfde probleem doet zich voor met objecten op de heap die kunnen worden benaderd via global of static variabelen.

Dit zijn de condities van zo'n situatie:
- memory locatie die te bereiken is vanuit meerdere threads (in of via global/static data)
- eigenschap van de data in die locatie die van belang is voor juiste uitvoering van programma
- de eigenschap klopt niet op elk moment
- een andere thread krijgt toegang op dat moment

Een oplossing is door een Lock-object aan te maken en met methodes Enter en Exit (System.Threading.Monitor in .NET) te laten weten of een thread toegang heeft. Andere threads wachten dan tot het Lock-object vrijgegeven is, voordat zij toegang krijgen.



## Maak een Proof of Concept met multithreading, een race condition en een valide oplossing

### Bronnen
https://www.backblaze.com/blog/whats-the-diff-programs-processes-and-threads/
https://docs.microsoft.com/nl-nl/archive/blogs/vancem/encore-presentation-what-every-dev-must-know-about-multithreaded-apps