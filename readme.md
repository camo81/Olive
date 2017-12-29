# Olive app #

Olive app è fatta da Carlo Camagni e Davide Motti.
L'applicazione è sviluppata in C# tramite Xamarin ed il codice è liberamente scaricabile da http://gitlab.consortech.it:8080/explore/projects.
Siete liberi di scaricarla, modificarla, romperla, abbellirla e imbruttirla.
Grazie a Material Design Icons (https://materialdesignicons.com/) per le icone, Pixabay (https://pixabay.com/it/) per lo sfondo del menù, Smashicons di Flaticon (https://www.flaticon.com/authors/smashicons) per l'app icon.
E a mia figlia Olivia, questo lavoro è dedicato a te. <3

## Come è fatta ##

Per compilare l'applicazione è necessario Visual Studio e Xamarin. L'applicazione è sviluppata tramite Xamarin Forms Portable con alcuni Dependency Service sviluppati esclusivamente per la parte Android, non è previsto alcun supporto per la parte iOs nè ora nè mai.


## Cosa fa ##

Olive è sviluppata per interrogare via web una webcam mobotix con interfaccia pubblica o privata, nella pagina delle impostazioni potete inserire user, password e i due indirizzi (interno o esterno) sui quali interrogare. 
Permette di azionare il relè eventualmente collegato alla prima uscita della cam, quella appositamente creata per azionare il cancello.
Future release implementeranno (forse) gli altri 3 relè presenti sulla cam.

## To Do##

- Implementazione degli altri 3 comandi

## Bug Conosciuti ##

- Le entry nella pagina settings non si adattano al layout tablet.
- I bottoni del menù non occupano tutta la larghezza della pagina e vanno quindi tappato sulla scrtta.
