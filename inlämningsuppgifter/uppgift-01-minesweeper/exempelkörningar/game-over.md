# Game over

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

> f h0

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X F X X
1 | X X X X X X X X X X
2 | X X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f h1

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X F X X
1 | X X X X X X X F X X
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
0 | X X X X X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f i2

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f i4

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a0

    A B C D E F G H I J
  +--------------------
0 | F X X X X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f b0

    A B C D E F G H I J
  +--------------------
0 | F F X X X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f c0

    A B C D E F G H I J
  +--------------------
0 | F F F X X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f d0

    A B C D E F G H I J
  +--------------------
0 | F F F F X X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f e0

    A B C D E F G H I J
  +--------------------
0 | F F F F F X X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f f0

    A B C D E F G H I J
  +--------------------
0 | F F F F F F X F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f g0

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F X X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f i0

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F X
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f j0

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | X X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f a1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F X X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f b1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F X X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f c1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F X X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f d1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F X X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f e1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F X X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f f1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F F X F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f g1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F F F F X X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f i1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F F F F F X
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f j1

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F F F F F F
2 | F X X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f b2

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F F F F F F
2 | F F X X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f c2

    A B C D E F G H I J
  +--------------------
0 | F F F F F F F F F F
1 | F F F F F F F F F F
2 | F F F X X X X X F X
3 | X X X X X X X X X X
4 | X X X X X X X X F X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> r a5

    A B C D E F G H I J
  +--------------------
0 | Ⅎ Ⅎ Ⅎ Ⅎ Ⅎ Ⅎ Ⅎ ɯ Ⅎ Ⅎ
1 | Ⅎ Ⅎ Ⅎ Ⅎ Ⅎ Ⅎ Ⅎ ɯ Ⅎ Ⅎ
2 | ɯ Ⅎ Ⅎ . . . 1 2 ɯ 1
3 | 1 1 . . . . . 2 2 2
4 | 1 1 . . . . . 1 ɯ 1
5 | M 1 . . . . . 1 1 1
6 | 2 2 1 1 1 1 1 1 1 .
7 | 1 m 1 1 m 2 2 m 1 .
8 | 1 1 1 1 1 2 m 2 1 .
9 | . . . . . 1 1 1 . .

GAME OVER
```