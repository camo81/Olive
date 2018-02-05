# Olive #

Olive (https://play.google.com/store/apps/details?id=com.camo.olive) è fatta da Carlo Camagni e Davide Motti.
L'applicazione è sviluppata in C# tramite Xamarin ed il codice è liberamente scaricabile da https://github.com/camo81/Olive.
Siete liberi di scaricarla, modificarla, romperla, abbellirla e imbruttirla.
Grazie a Material Design Icons (https://materialdesignicons.com/) per le icone, Pixabay (https://pixabay.com/it/) per lo sfondo del menù, Smashicons di Flaticon (https://www.flaticon.com/authors/smashicons) per l'app icon.
E a mia figlia Olivia, questo lavoro è dedicato a te. <3

## Come è fatta ##

Per compilare l'applicazione è necessario Visual Studio e Xamarin. L'applicazione è sviluppata tramite Xamarin Forms Portable con alcuni Dependency Service sviluppati esclusivamente per la parte Android, non è previsto alcun supporto per la parte iOs nè ora nè mai.


## Cosa fa ##

Olive è sviluppata per interrogare via web una webcam mobotix con interfaccia pubblica o privata, nella pagina delle impostazioni potete inserire user, password e i due indirizzi (interno o esterno) sui quali interrogare. 
Permette di azionare il relè eventualmente collegato alla prima uscita della cam, quella appositamente creata per azionare il cancello.
Future release implementeranno (forse) gli altri 3 relè presenti sulla cam.

## To Do ##

- Implementazione degli altri 3 comandi

