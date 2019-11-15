# Projekt semestralny - aplikacja Notely

Aplikacja Notely jest semestralnym projektem zaliczeniowym przedmiotu "Programowanie obiektowe C#" w Wyższej Szkole Ekonomii i Informatyki w Krakowie.

## Cel projektu

Głównym celem aplikacji jest przygotowanie pełnoprawnego edytora formatu Markdown z jednoczesnym generowaniem widoku dla tego formatu. Aplikacja ma być prostym odpowiednikiem aplikacji typu OneNote / Evernote, początkowo wykorzystująca zasoby lokalne z możliwością rozbudowy do przechowywania notatek w chmurze (np. Azure).

## Zespół tworzący projekt

1. [Dominik Młynarczyk](https://github.com/dominikmlynarczyk)
2. [Jakub Antosz](https://github.com/qhorinn?fbclid=IwAR1e2ONikpnInt_6yjzDDX4z_d2lDQ6AX-i6lHwsSfASIS5zubtnpiO1slg)
3. [Jakub Święch](https://github.com/CaptainOfPain) 

## Wstępne założenia projektu

<u>**Wstępne**</u> założenia co do funkcjonalności aplikacji:

1. Interfejs będzie zbudowany z dwóch kolumn, gdzie lewa kolumna będzie reprezentowała załadowane drzewo plików / listę notatek z otwartego folderu, a druga kolumna będzie częścią edytorską.
   - Część edytorska będzie obslugiwała dwa tryby, tryb "_Editor_", czyli standardowy tryb do wprowadzania tekstu, oraz tryb "_Preview_", czyli dynamicznie generowany, sformatowany widok notatki.
   - [OPCJONALNIE] Zostanie dodana możliwość zmiany widoku wyświetlania notatek w lewej kolumnie z drzewa plików na widok poszczególnych notatek.
2. Podstawowa obsługa edytora tekstu - zapisywanie notatki, wczytywanie notatek do edytora (w formacie `.md`), usuwanie notatek, nadawnie tytułu notatce oraz możliwość jej zmiany
3. Pełna obsługa podstawowych znaczników języka _Markdown_ - akapity, nagłówki, cytaty, formatowanie tekstu (emfaza, podkreślenie, pogrubienie), listy, linki, grafiki, bloki kodu itp.
4. Zaimplementowany prosty system wyszukiwania notatek
5. Podstawowe właściwości informacyjne notatki - data utworzenia i ostatniej edycji notatki
