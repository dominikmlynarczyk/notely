<p align="center">
  <img src="https://i.postimg.cc/W4TWn8TS/notely-gh.png">
</p>

# Notely

The Notely application is a semester final project of the subject "Object-oriented programming in C#" at the College of Economics and Computer Science in Krakow.

## Purpose of the project

The main purpose of the application is to prepare a fully-fledged Markdown editor with the ability to generate a view for that format. The application goal is to give the end-user an equivalent of OneNote / Evernote applications, initially using local resources with the possibility of extension to store notes in the cloud (e.g. Azure).

## Project development team

1. [Dominik Młynarczyk](https://github.com/dominikmlynarczyk)
2. [Jakub Antosz](https://github.com/qhorinn?fbclid=IwAR1e2ONikpnInt_6yjzDDX4z_d2lDQ6AX-i6lHwsSfASIS5zubtnpiO1slg)
3. [Jakub Święch](https://github.com/CaptainOfPain) 

## Initial project assumptions

<u>**Preliminary**</u> assumptions as to the functionality of the application:

1. The interface will be composed of two columns, where the left column will represent a dynamic preview of the generated note, and the second column will be the editor part.
2. Basic use of a text editor - saving a note, loading notes into the editor (in .md format), deleting notes, giving a note title and the ability to change it
3. Full support for basic Markdown tags - paragraphs, headings, quotes, text formatting (emphasis, underline, bold), lists, links, graphics, code blocks, etc.
4. Simple note search system
5. Basic information properties of the note e.g. date of creation and last edition of the note

## Additional functionality

With the development of the project, some details of the project concept changed, and finally, new application functionalities were added to the project:

1. The ability to register new users and operate the login system using the *Entity Framework*
2. User panel dashboard enabling modification of his data, as well as password change and complete removal of the account from the database
