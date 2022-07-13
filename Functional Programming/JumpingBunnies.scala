import java.util.Scanner

object Solution {
    //optimization
  @scala.annotation.tailrec
  //define, parameters a,b, output, if == , else
  def greatestComDe(a: Long, b: Long): Long = if (b == 0) a else greatestComDe(b, a % b)
  //define, parameters a,b, output
  def leastComMul(a: Long, b: Long): Long = a / greatestComDe(a, b) * b

  def main(args: Array[String]): Unit = {
    //set to create new
    val sc = new Scanner(System.in)
    //set to
    val t = sc.nextInt
    //until, .map, pass on, .reduce
    println((0 until t).map(_ => sc.nextLong).reduce(leastComMul))
  }
}
Footer
