import math

delta_max = 0.0265919
h = 10 ** (-14)


def d2f(x):
    return -20 * (x ** 3)


x4 = -1
while x4 <= 10 ** (-14):
    delta_max += h
    x0 = -1
    a1 = abs(d2f(x0))
    h1 = math.sqrt((16 * delta_max) / a1)

    x1 = x0 + h1
    a2 = abs(d2f(x1))
    h2 = math.sqrt((16 * delta_max) / a2)

    x2 = x1 + h2
    a3 = abs(d2f(x2))
    h3 = math.sqrt((16 * delta_max) / a3)

    x3 = x2 + h3
    a4 = abs(d2f(x3))
    h4 = math.sqrt((8 * delta_max) / a4)

    x4 = x3 + h4
    print(x4)

print(delta_max)
