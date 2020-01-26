<p align="center">
  <img src="https://i.postimg.cc/W4TWn8TS/notely-gh.png">
</p>

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

1. Interfejs będzie zbudowany z dwóch kolumn, gdzie lewa kolumna będzie reprezentowała dynamiczny podgląd wygenerowanej notatki, a druga kolumna będzie częścią edytorską.
2. Podstawowa obsługa edytora tekstu - zapisywanie notatki, wczytywanie notatek do edytora (w formacie `.md`), usuwanie notatek, nadawnie tytułu notatce oraz możliwość jej zmiany
3. Pełna obsługa podstawowych znaczników języka _Markdown_ - akapity, nagłówki, cytaty, formatowanie tekstu (emfaza, podkreślenie, pogrubienie), listy, linki, grafiki, bloki kodu itp.
4. Zaimplementowany prosty system wyszukiwania notatek
5. Podstawowe właściwości informacyjne notatki - data utworzenia i ostatniej edycji notatki

## Dodatkowe zaimplementowane funkcje

Wraz z rozwojem projektu pewne detale koncepcji projektu się zmieniały, a także ostatecznie do projektu zostały dodane kolejne funkcjonalności aplikacji:

1. Możliwość rejestracji nowych użytkowników i obsługi systemu logowania przy wykorzystaniu platformy *Entity Framework*
2. Panel użytkownika umożliwiający modyfikację jego danych, a także zmianę hasła i całkowite usunięcie konta z bazy