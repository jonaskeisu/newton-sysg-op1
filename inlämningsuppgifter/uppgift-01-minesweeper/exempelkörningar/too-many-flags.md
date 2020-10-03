# För många flaggor

Om programmet körs enligt:

```sh
$ dotnet run 888
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

> f a0

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | X X X X X X X X X X
2 | X X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a1

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | X X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a2

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a3

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a4

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a5

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a6

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a7

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a8

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | X X X X X X X X X X

> f a9

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b0

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F X X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b1

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F X X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b2

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F X X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b3

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F X X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b4

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F X X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b5

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F X X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b6

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F X X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b7

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F X X X X X X X X X
9 | F X X X X X X X X X

> f b8

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F X X X X X X X X X

> f b9

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c0

    A B C D E F G H I J
  +--------------------
0 | F F F X X X X X X X
1 | F F X X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c1

    A B C D E F G H I J
  +--------------------
0 | F F F X X X X X X X
1 | F F F X X X X X X X
2 | F F X X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c2

    A B C D E F G H I J
  +--------------------
0 | F F F X X X X X X X
1 | F F F X X X X X X X
2 | F F F X X X X X X X
3 | F F X X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c3

    A B C D E F G H I J
  +--------------------
0 | F F F X X X X X X X
1 | F F F X X X X X X X
2 | F F F X X X X X X X
3 | F F F X X X X X X X
4 | F F X X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c4

    A B C D E F G H I J
  +--------------------
0 | F F F X X X X X X X
1 | F F F X X X X X X X
2 | F F F X X X X X X X
3 | F F F X X X X X X X
4 | F F F X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c5
not allowed

> f a0

    A B C D E F G H I J
  +--------------------
0 | X F F X X X X X X X
1 | F F F X X X X X X X
2 | F F F X X X X X X X
3 | F F F X X X X X X X
4 | F F F X X X X X X X
5 | F F X X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> f c5

    A B C D E F G H I J
  +--------------------
0 | X F F X X X X X X X
1 | F F F X X X X X X X
2 | F F F X X X X X X X
3 | F F F X X X X X X X
4 | F F F X X X X X X X
5 | F F F X X X X X X X
6 | F F X X X X X X X X
7 | F F X X X X X X X X
8 | F F X X X X X X X X
9 | F F X X X X X X X X

> q
```