# GPU-DB-Benchmark
Benchmark for GPU-accelerated Databases

## Kompilieren
Zur Kompilierung wird .NET 5 benötigt.
Das Projekt muss im "Release"-Modus gebaut werden.

## Nutzung
### Daten generieren
```GPU-DB-Benchmark generate <factor>```

```<factor>``` stellt hierbei die Größe der zu generierenden Daten in GB dar.

### Tabellen in OmniSci anlegen
Zur schneller Erstellung der Tabellen kann das mitgelieferte Skript ```omnisci_tablecreate.sql``` genutzt werden.
Die generierten ```.csv``` Dateien müssen dann in den import Ordner von OmniSci kopiert werden (siehe OmniSci Dokumentation)
und mittels

```
COPY <tablename> FROM '<filename>';
```

die Daten importiert werden.

### Pfade anpassen
Für BlazingSQL müssen die Pfade in den Skripten angepasst werden.
In den Dateien ```Queries/BlazingSQL/Query<1-5>.sql``` müssen die Pfade auf die generierten ```.csv``` Dateien zeigen.

### Benchmark ausführen
```GPU-DB-Benchmark benchmark```

Ergebnisse befinden sich im Ordner ```BenchmarkDotNet.Artifacts/results```.
