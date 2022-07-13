//define, parameters, pass on =>, .flatMap, until, .map
def f(num: Int, arr: List[Int]): List[Int] = arr.flatMap(v => (0 until num).map(_ => v))