# Felhantering

Om programmet körs enligt:

```sh
$ dotnet run 777
```

så är nedanstående en korrekt användarsession:

```text
    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X X X X
2 | X X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> r e4

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 2 X X X
1 | 1 1 . . . . 2 X X X
2 | X 1 . . . . 1 2 X X
3 | X 1 . . . . . 2 X X
4 | X 1 . . . . . 1 X X
5 | X 1 . . . . . 1 X X
6 | X 2 1 1 1 1 1 1 X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> r e4
not allowed

> f e4
not allowed

> r ee
syntax error

> r 44
syntax error

> f ee
syntax error

> f e4
not allowed

> r k9
syntax error

> f k9
syntax error

> f
unknown command

> r
unknown command

> b
unknown command

> 
syntax error

> !
syntax error

> a e5
unknown command

> a k9
syntax error

> f e6 r
syntax error

> kjas;lfja;sldfkja;lskdjf;alskjdf;lakjsfd;lakjsdf;lakjsfd;lkja;lsfdkja;lksjdf;lakjf;lkajf;akja;lksfja;kjf;akjfs;lakjf;kja;flkja;kljfa;lkjsf;lkajf;alskjdf
syntax error

> q
```