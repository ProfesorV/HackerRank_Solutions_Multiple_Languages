//define, parameters delimiter, array, output, match
def f(delimiter: Int, arr: List[Int]): List[Int] = arr match {
    //case pass to
  case Nil => Nil
  //case, variable, pass to, if < :: else
  case x :: xs => if (x < delimiter) x :: f(delimiter, xs) else f(delimiter, xs)
}