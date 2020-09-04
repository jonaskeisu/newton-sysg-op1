---
marp: false
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

# Programmering i team
</div>

---

<div class="title-page">

## Versionshantering
</div>

---

## Gemensamt kodbas

- Ett team bidrar utvecklare typiskt till en gemensam kodbas i ett repo
- Varje utvecklare arbetar lokalt i en klon av det gemensamma repot
- I klonen är det gemensamma repot en *remote* som heter  ``origin`` 

<div style="zoom: 50%">

<!-- 
```graphviz
digraph repo {
    nodesep=1
    shared [label = "Origin"]
    clone1 [label = "Klon", xlabel="Utvecklare 1"]
    clone2 [label = "Klon", xlabel="Utvecklare 2"]
    clone3 [label = "Klon", xlabel="Utvecklare 3"]
    clone1 -> shared [dir=both]
    clone2 -> shared [dir=both]
    clone3 -> shared [dir=both]
}
```
-->

</div>

---

## Kloning

- En lokal klon av ett repo kan skapas med Git-kommandot ``clone``

```sh
> git clone <url>
```

---

## Commit

- En *commit* är en ögonblicksbild av katalogerna och filerna i repot
- Varje commit har:
  - En (eller flera) föregående commits
  - Ett meddelande som dokumenterar:
    - Innehåll/syfte med förändringen i kodbasen
    - Författaren till förändringen
  - En identifierare

---

## Identifierare för commit
- I Git är identifierare för en commit en SHA-1 kontrollsumma
- T.ex. ``70460b4b4aece5915caf5c68d12f560a9fe3e4``
- Kan refereras i kortform: ``70460b4``

--- 

## Commit-historik

- Ett repo lagrar en historik över alla commits
- Historiken visas med kommandot ``git log``

<!-- 
```graphviz 
digraph history {
    rankdir=LR
    edge [dir = "back"]
    node [fixedsize=true, width=1]

    commit1 [label = "6b6be8a", xlabel="Initial commit"]
    commit2 [label = "0428486"]
    commit3 [label = "..", style="dashed"]
    commit4 [label = "d7e9249"]
    commit5 [label = "3d3adc5"]
    
    commit1 ->
    commit2 ->
    commit3 ->
    commit4 ->
    commit5
}
-->

--- 

--- 

## Återställning av commit

- En lokalt repo kan återställas till en tidigare commit med Git-kommandot ``checkout``

    ```sh
    > git checkout 0428486
    ```

- Den aktuellt utcheckade commiten har alias ``HEAD``
  
---

## Status på filer i repo

- Filer i ett repo kan ha fyra olika tillstånd

<!-- 

```graphviz
digraph file_status {
    nodesep=0.5
    node [fixedsize=true, width=1]
    untracked 
    staged
    unmodified
    modified

    untracked -> staged [label = "git add"]
    unmodified -> modified [label = "redigering"]
    staged -> unmodified [label = "git commit"]
    modified -> unmodified [label = "git checkout"]
    unmodified -> untracked [label = "git rm"]
    modified -> staged [label = "git add"]
}
```
-->

---

## Lokalt arbetsflöde

- Checka ut utgångs-commit (om inte  HEAD)
- Redigera filerna
- Arrangera ny commit med ``git add``
- Verställ commit

---

## Branch

- En branch är ett *spår* i utvecklingen
- Från en given commit kan utvecklingen dela upp sig i flera spår

```graphviz 
digraph branch 
{
  rankdir=LR
  node [fontsize=10,]
  c1 [label = "4414186"]
  c2 [label = "3484d6f"]
  c3 [label = "0f28ecc"]
  c4 [label = "84f9c6d"]
  c5 [label = "8f8afc2", xlabel="master"]
  c6 [label = "deb0935"]
  c7 [label = "859bc5d"]
  c8 [label = "7671515", xlabel="fixa-bugg"]


  c1 -> c2 -> c3 -> c4 -> c5
  c3 -> c6 -> c7  -> c8
}

4414186bf13844a85d1943af5baef08b34bca1f4
3484d6f2f8b66beb7ac0f01c2f66a04f4d36e115
0f28eccb8b9ca772abd8ee3a54014948546d65a6
84f9c6dbd9212aa285367c468d9d2cafbc1d47f1
8f8afc29036d37319bdad472792b18d950ed10b3
deb0935a1e647a51c2ecd8fc600ef99d5b1be725
859bc5d87ac7b1ba73ac66b15f880af2509c8ce7
7671515dfc7f12976c5b9ec372f551ffd73d428f
29b3ff74f3fe88058ce20c561bb919802a58580a
eae276a7121554b51d2a6b1279e052e6ef832623