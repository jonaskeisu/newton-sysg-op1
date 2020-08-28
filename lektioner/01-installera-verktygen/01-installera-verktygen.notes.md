---
marp: true
theme: default
footer: © 2020 BIT ADDICT
style: | 
  section {
      @extend .markdown-body;
      display: block;
      flex-direction: column;
      font-size: 32px
  }

  @import '../css/lecture_slides.css'

---

<div class="title-page">

# Installera verktygen
</div>

---

## Ramverket

- Installera senaste versionen av ramverket - [.NET Core 3.1](https://dotnet.microsoft.com/download)

--- 

## Versionshantering

- Installera [Git](https://git-scm.com/downloads) för versionshantering
- Namn och e-post loggas vid ändring i versionhanterad kod
- Konfigurera namn och e-post från konsolen

```bash
> git config --global user.name "Jonas Keisu"
> git config --global user.email jonas.keisu@bitaddict.se
```

--- 

### Exempel


```sh
> git log
commit 9cd4704885f6af7e517778b134314565955ee22e
Author: Jonas Keisu <jonas.keisu@bitaddict.se>
Date:   Thu Aug 27 21:39:18 2020 +0200

    Lägg till mallprojekt

commit 4cd74c1990a4e3e132934d522dbdb78561cdef7e
Author: jonaskeisu <54109247+jonaskeisu@users.noreply.github.com>
Date:   Thu Aug 27 21:12:50 2020 +0200

    Initial commit
>
```

---

## GitHub

- Skapa konto på [GitHub](https://github.com/) (om du inte redan har ett)
- Skicka GitHub-användarnamn i PM till läraren

---

## Utvecklingsmiljön

- Installera [Visual Studio Code](https://code.visualstudio.com/download)
- Installera extensions i Visual Studio Code:
  - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) (Microsoft)
  - [Live Share](https://marketplace.visualstudio.com/items?itemName=MS-vsliveshare.vsliveshare) (Microsoft)
  - [SharpPad](https://marketplace.visualstudio.com/items?itemName=jmazouri.sharppad) (jmazouri)
- Logga in i Live Share med GitHub-kontot
---

<div class="title-page">

# Rundtur i utvecklingsverktygen
</div>

---

## Skapa repository på GitHub

- Skapa ett källkodsarkiv (***repo***) på GitHub
- Namn: ``hello-world``
- Beskrivning: *Min första app!*
- Synlighet: private
- Initera repot med .gitignore template *Visual Studio*

--- 

## Klona repot lokalt

- Skapa en katalog för källkodsarkiv lokalt på din dator
- Kopiera URL för det nya repot på GitHub
- Gå till katalogen skapad ovan i konsolen
- Klona repot med ``git clone`` och den kopierade URL:en
- En ny katalog vid namn ``~/src/hello-world`` är nu skapad lokalt 

---

### Exempel

```sh
> cd ~/src
> git clone https://github.com/jonaskeisu/hello-world.git
Cloning into 'hello-world'...
remote: Enumerating objects: 3, done.
remote: Counting objects: 100% (3/3), done.
remote: Compressing objects: 100% (2/2), done.
remote: Total 3 (delta 0), reused 0 (delta 0), pack-reused 0
Unpacking objects: 100% (3/3), done.
>
```

---

## Skapa en ny konsolapplikation

- Gå till katalogen för det klonade report i konsolen
- Använd kommandot ``dotnet new console`` för att skapa en ny .NET Core Console-applikation från mall

---

### Exempel

```bash
> cd hello-world
> dotnet new console
The template "Console Application" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on 
    /Users/jonaskeisu/src/hello-world/hello-world.csproj...
  Restore completed in 126.5 ms for 
    /Users/jonaskeisu/src/hello-world/hello-world.csproj.

Restore succeeded.
> ls
Program.cs         hello-world.csproj obj
```

---

## Kör applikationen

- Kör applikationen med kommandot ``dotnet run``

```bash
> dotnet run
Hello World!
```

--- 

## Lägg till nya projektfiler i repot

- Lägg till alla ändringar till med kommandot: ``git commit``

---

### Exempel

```bash
> git commit -a -m "Lägg till mallprojekt"
[master 9cd4704] Lägg till mallprojekt
 2 files changed, 21 insertions(+)
 create mode 100644 Program.cs
 create mode 100644 hello-world.csproj
>
```

--- 

## Synkronisera versioner med GitHub

- Synkronisera lokalt repo med GitHub med kommandot: ``git push`` 

---

### Exempel

```bash
> git push
Enumerating objects: 5, done.
Counting objects: 100% (5/5), done.
Delta compression using up to 8 threads
Compressing objects: 100% (4/4), done.
Writing objects: 100% (4/4), 630 bytes | 630.00 KiB/s, done.
Total 4 (delta 0), reused 0 (delta 0)
To https://github.com/jonaskeisu/hello-world.git
   4cd74c1..9cd4704  master -> master
>
```

Nya vesion av repot är nu tillgängliga på GitHub

---

## Uppdatera koden från Visual Studio Code

- Öppna katalogen ``hello-world`` från Visual Studio Code
- Öppna filen ``Program.cs`` från Explorer-panelen
- Ändra ``Console.WriteLine("Hello World!");`` till
    ``Console.WriteLine("Hello World from C# .NET Core!");``
- Testkör uppdaterad kod från Debug-panelen
- Skapa ny version av repot med alla ändringen från Source Control-panelen
- Synkronisera versioner med GitHub från Source Control-panelen






