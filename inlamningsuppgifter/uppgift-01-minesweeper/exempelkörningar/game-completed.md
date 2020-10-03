# Komplettering av spelet

Om programmet körs enligt:

```sh
$ dotnet run 666
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

> f h1

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X X X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f g2

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X X
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f j4

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X X X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f d5

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X X X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f i5

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X F X
6 | X X X X X X X X X X
7 | X X X X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f c7

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X F X
6 | X X X X X X X X X X
7 | X X F X X X X X X X
8 | X X X X X X X X X X
9 | X X X X X X X X X X

> f d8

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X F X
6 | X X X X X X X X X X
7 | X X F X X X X X X X
8 | X X X F X X X X X X
9 | X X X X X X X X X X

> f b9

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X F X
6 | X X X X X X X X X X
7 | X X F X X X X X X X
8 | X X X F X X X X X X
9 | X F X X X X X X X X

> f e9

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X F X
6 | X X X X X X X X X X
7 | X X F X X X X X X X
8 | X X X F X X X X X X
9 | X F X X F X X X X X

> f i9

    A B C D E F G H I J
  +--------------------
0 | X X X X X X X X X X
1 | X X X X X X X F X X
2 | X X X X X X F X X X
3 | X X X X X X X X X X
4 | X X X X X X X X X F
5 | X X X F X X X X F X
6 | X X X X X X X X X X
7 | X X F X X X X X X X
8 | X X X F X X X X X X
9 | X F X X F X X X F X

> r a0

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 X X X
1 | . . . . . 1 2 F X X
2 | . . . . . 1 F X X X
3 | . . . . . 1 1 1 X X
4 | . . 1 1 1 . . 1 X F
5 | . . 1 F 1 . . 1 F X
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r b0
not allowed

> r c0
not allowed

> r d0
not allowed

> r e0
not allowed

> r f0
not allowed

> r g0
not allowed

> r h0

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 X X
1 | . . . . . 1 2 F X X
2 | . . . . . 1 F X X X
3 | . . . . . 1 1 1 X X
4 | . . 1 1 1 . . 1 X F
5 | . . 1 F 1 . . 1 F X
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r i0

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 X
1 | . . . . . 1 2 F X X
2 | . . . . . 1 F X X X
3 | . . . . . 1 1 1 X X
4 | . . 1 1 1 . . 1 X F
5 | . . 1 F 1 . . 1 F X
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r j0

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F X 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 X F
5 | . . 1 F 1 . . 1 F X
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r a1
not allowed

> r b1
not allowed

> r c1
not allowed

> r d1
not allowed

> r e1
not allowed

> r f1
not allowed

> r g1
not allowed

> r i1
not allowed

> r j1
not allowed

> r a2
not allowed

> r b2
not allowed

> r c2
not allowed

> r d2
not allowed

> r e2
not allowed

> r f2
not allowed

> r h2

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 X F
5 | . . 1 F 1 . . 1 F X
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r i2
not allowed

> r j2
not allowed

> r a3
not allowed

> r b3
not allowed

> r c3
not allowed

> r d3
not allowed

> r e3
not allowed

> r f3
not allowed

> r g3
not allowed

> r h3
not allowed

> r i3
not allowed

> r j3
not allowed

> r a4
not allowed

> r b4
not allowed

> r c4
not allowed

> r d4
not allowed

> r e4
not allowed

> r f4
not allowed

> r g4
not allowed

> r h4
not allowed

> r i4

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F X
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r a5
not allowed

> r b5
not allowed

> r c5
not allowed

> r e5
not allowed

> r f5
not allowed

> r g5
not allowed

> r h5
not allowed

> r j5

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 X 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r a6
not allowed

> r b6
not allowed

> r c6
not allowed

> r d6

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F X 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r e6
not allowed

> r f6
not allowed

> r g6
not allowed

> r h6
not allowed

> r i6
not allowed

> r j6
not allowed

> r a7
not allowed

> r b7
not allowed

> r d7

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F 2 1 . . . . .
8 | 1 2 X F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r e7
not allowed

> r f7
not allowed

> r g7
not allowed

> r h7
not allowed

> r i7
not allowed

> r j7
not allowed

> r a8
not allowed

> r b8
not allowed

> r c8

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F 2 1 . . . . .
8 | 1 2 3 F 2 1 . 1 1 1
9 | X F X X F 1 . 1 F X

> r e8
not allowed

> r f8
not allowed

> r g8
not allowed

> r h8
not allowed

> r i8
not allowed

> r j8
not allowed

> r a9

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F 2 1 . . . . .
8 | 1 2 3 F 2 1 . 1 1 1
9 | 1 F X X F 1 . 1 F X

> r c9

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F 2 1 . . . . .
8 | 1 2 3 F 2 1 . 1 1 1
9 | 1 F 2 X F 1 . 1 F X

> r d9

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F 2 1 . . . . .
8 | 1 2 3 F 2 1 . 1 1 1
9 | 1 F 2 2 F 1 . 1 F X

> r f9
not allowed

> r g9
not allowed

> r h9
not allowed

> r j9

    A B C D E F G H I J
  +--------------------
0 | . . . . . . 1 1 1 .
1 | . . . . . 1 2 F 1 .
2 | . . . . . 1 F 2 1 .
3 | . . . . . 1 1 1 1 1
4 | . . 1 1 1 . . 1 2 F
5 | . . 1 F 1 . . 1 F 2
6 | . 1 2 2 1 . . 1 1 1
7 | . 1 F 2 1 . . . . .
8 | 1 2 3 F 2 1 . 1 1 1
9 | 1 F 2 2 F 1 . 1 F 1

WELL DONE!
```