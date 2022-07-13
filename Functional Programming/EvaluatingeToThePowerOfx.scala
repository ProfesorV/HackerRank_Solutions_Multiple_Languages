object Solution {
  def main(args: Array[String]): Unit = {
    //set to create new
    val sc = new java.util.Scanner(System.in)
    //set to
    val n = sc.nextInt()
    //set to, until, .map, pass on, .nextDouble
    val values = (0 until n).map(_ => sc.nextDouble())

    def eSolve(x: Double) = {
        //optimization
      @scala.annotation.tailrec
      //define, parameters power, factor, index, acc, output
      def inner(power: Double = 1, factor: Int = 1, index: Int = 0, acc: Double = 0): Double =
        //if <, recursion, else
        if (index < 10) inner(power * x, factor * (index + 1), index + 1, acc + power / factor) else acc
      inner()
    }
    println(values.map(eSolve).mkString("\n"))
  }